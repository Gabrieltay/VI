using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Commons;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Parsers
{
    public class MorningStarParser : AbstractParser
    {
        public const String QUERY_STR = "http://financials.morningstar.com/ajax/exportKR2CSV.html?t=@TICK";

        public MorningStarParser( StockProfile aStock )
        {
            this.mStock = aStock;
        }

        public override bool StartCSV( string aCsvString )
        {
            string[] nRows = aCsvString.Replace( "\r", "" ).Split( '\n' );
            {
                //foreach ( String nRow in nRows )
                for ( int i = 0; i < nRows.Length; i++ )
                {
                    String nRow = nRows[i];

                    if ( nRow.Contains( "Earnings Per Share" ) )
                    {
                        parseEPS( nRow );
                        continue;
                    }

                    if ( nRow.Contains( "Dividends" ) )
                    {
                        parseDividend( nRow );
                        continue;
                    }

                    if ( nRow.Contains( "Book Value Per Share" ) )
                    {
                        parseBookValue( nRow );
                        continue;
                    }

                    if ( nRow.Contains( "Operating Cash Flow" ) && !nRow.Contains( "Growth" ) )
                    {
                        parseCashFlow( nRow );
                        continue;
                    }

                    if ( nRow.Contains( "Return on Equity" ) )
                    {
                        parseReturnOnEquity( nRow );
                        continue;
                    }

                    if ( nRow.Contains( "Debt/Equity" ) )
                    {
                        parseDebtToEquity( nRow );
                        continue;
                    }

                    if ( nRow.Contains( "EPS %" ) )
                    {
                        parseEpsGrowth( nRows[i + 2], nRows[i + 3], nRows[i + 4] );
                        continue;
                    }
                }
            }
            return true;
        }

        public override bool StartHTML( string aHtmlString )
        {
            throw new NotImplementedException();
        }

        private void parseEPS( String aRow )
        {
            string[] nCols = aRow.Split( ',' );
            if ( nCols.Length != 12 )
            {
                return;
            }
            List<Point> nEpsList = new List<Point>();

            for ( int i = 6; i < 11; i++ )
            {
                nEpsList.Add( new Point() { X = ( i - 5 ), Y = String.IsNullOrEmpty( nCols[i] ) ? 0 : Double.Parse( nCols[i] ) } );
            }
            double nGradient, nIntercept;
            MathUtil.GenerateLinearBestFit( nEpsList, out nGradient, out nIntercept );
            this.mStock.Profitability = ( nGradient > Params.PROFITABILITY_THRESHOLD ? true : false );

            this.mStock.EPS = String.IsNullOrEmpty( nCols[11] ) ? 0 :  Double.Parse( nCols[11] );

            if ( this.mStock.EPS != 0 )
            {
                this.mStock.PERatio = this.mStock.Last / this.mStock.EPS;
            }
        }

        private void parseBookValue( String aRow )
        {
            string[] nCols = aRow.Split( ',' );
            if ( nCols.Length != 12 )
            {
                return;
            }
            this.mStock.BookValue = String.IsNullOrEmpty( nCols[11] ) ? 0 : Double.Parse( nCols[11] );
            this.mStock.AEP = this.mStock.BookValue * Params.BOOKVALUE_THRESHOLD;
        }

        private void parseCashFlow( String aRow )
        {
            string[] nCols = aRow.Split( ',' );
            if ( nCols.Length != 12 )
            {
                return;
            }

            for ( int i = 6; i < 11; i++ )
            {
                double nInFlow = String.IsNullOrEmpty( nCols[i] ) ? 0 : Double.Parse( nCols[i] );
                if ( nInFlow < 0 )
                {
                    this.mStock.InFlowCash = false;
                    return;
                }
            }
            this.mStock.InFlowCash = true;
        }

        private void parseReturnOnEquity( String aRow )
        {
            string[] nCols = aRow.Split( ',' );
            if ( nCols.Length != 12 )
            {
                return;
            }

            this.mStock.ROE = String.IsNullOrEmpty( nCols[11] ) ? 0 :  Double.Parse( nCols[11] );
            this.mStock.Efficiency = this.mStock.ROE > Params.ROE_THRESHOLD ? true : false;
        }

        private void parseDebtToEquity( String aRow )
        {
            string[] nCols = aRow.Split( ',' );
            if ( nCols.Length != 12 )
            {
                return;
            }

            this.mStock.DOE = String.IsNullOrEmpty(nCols[11])? 0 : Double.Parse( nCols[11] );
            this.mStock.Conservative = this.mStock.DOE > Params.DOE_THRESHOLD ? false : true;
        }

        private void parseEpsGrowth( String aRow3, String aRow5, String aRow10 )
        {
            double nSum3 = 0.0;
            double nSum5 = 0.0;
            double nSum10 = 0.0;
            double nMinGrowth = 0.0;

            string[] nCols3 = aRow3.Split( ',' );
            if ( String.IsNullOrEmpty( nCols3[5] ) && String.IsNullOrEmpty( nCols3[6] ) )
                nSum3 = 0.0;
            else
                for ( int i = 6; i < 11; i++ )
                {
                    nSum3 += String.IsNullOrEmpty( nCols3[i] ) ? 0.0 : double.Parse( nCols3[i] );
                }

            string[] nCols5 = aRow5.Split( ',' );
            if ( String.IsNullOrEmpty( nCols5[5] ) && String.IsNullOrEmpty( nCols5[6] ) )
                nSum5 = 0.0;
            else
                for ( int i = 6; i < 11; i++ )
                {
                    nSum5 += String.IsNullOrEmpty( nCols5[i] ) ? 0.0 : double.Parse( nCols5[i] );
                }

            string[] nCols10 = aRow10.Split( ',' );
            if ( String.IsNullOrEmpty( nCols10[5] ) && String.IsNullOrEmpty( nCols10[6] ) )
                nSum10 = 0.0;
            else
                for ( int i = 6; i < 11; i++ )
                {
                    nSum10 += String.IsNullOrEmpty( nCols10[i] ) ? 0.0 : double.Parse( nCols10[i] );
                }

            if ( nSum3/5 != 0.0 )
                nMinGrowth = nSum3/5;
            if ( nSum5/5 != 0.0 && nSum5/5 < nMinGrowth )
                nMinGrowth = nSum5/5;
            if ( nSum10/5 != 0.0 && nSum10/5 < nMinGrowth )
                nMinGrowth = nSum10/5;

            this.mStock.PEG = this.mStock.PERatio / nMinGrowth;

            this.mStock.GEP = this.mStock.EPS * nMinGrowth;
        }

        private void parseDividend(String aRow)
        {
            string[] nCols = aRow.Split( ',' );
            if ( nCols.Length != 12 )
            {
                return;
            }
            this.mStock.Dividend = String.IsNullOrEmpty( nCols[11] ) ? 0 : Double.Parse( nCols[11] );
            this.mStock.DivYield = this.mStock.Dividend / this.mStock.Last;

            this.mStock.DEP = this.mStock.Dividend / Params.DIVIDEND_THRESHOLD;
        }

        private StockProfile mStock
        {
            get; set;
        }
    }
}
