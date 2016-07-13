using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ValueInvesting.Commons;
using ValueInvesting.Controllers;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Parsers
{
    public class MorningStarParser : AbstractParser
    {
        public const String QUERY_STR = "http://financials.morningstar.com/ajax/exportKR2CSV.html?t=@TICK";

        private Regex CSVParser = new Regex( ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))" );

        public MorningStarParser( StockProfile aStock )
        {
            this.mStock = aStock;
            this.mCurrencyRate = 1;
            this.mCfg = ConfigManager.getInstance().Config;
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

            String nCurrency = nCols[0].Replace( "Earnings Per Share", "" ).Trim();
            if ( !nCurrency.Equals( "USD" ) && this.mStock.Market == Enums.Market.US )
            {
                String nYahooCsvStr = RESTController.GetREST( YahooFinanceCurrencyParser.QUERY_STR.Replace( "@FRCUR", nCurrency ).Replace( "@TOCUR", "USD" ) );
                YahooFinanceCurrencyParser nParser = new YahooFinanceCurrencyParser();
                nParser.StartCSV( nYahooCsvStr );
                this.mCurrencyRate = nParser.Rate;
            }
            else if ( !nCurrency.Equals( "SGD" ) && this.mStock.Market == Enums.Market.SG )
            {
                String nYahooCsvStr = RESTController.GetREST( YahooFinanceCurrencyParser.QUERY_STR.Replace( "@FRCUR", nCurrency ).Replace( "@TOCUR", "SGD" ) );
                YahooFinanceCurrencyParser nParser = new YahooFinanceCurrencyParser();
                nParser.StartCSV( nYahooCsvStr );
                this.mCurrencyRate = nParser.Rate;
            }

            List<Point> nEpsList = new List<Point>();

            for ( int i = 6; i < 11; i++ )
            {
                nEpsList.Add( new Point() { X = ( i - 5 ), Y = String.IsNullOrEmpty( nCols[i] ) ? 0 : Double.Parse( nCols[i] ) } );
            }
            double nGradient, nIntercept;
            MathUtil.GenerateLinearBestFit( nEpsList, out nGradient, out nIntercept );
            this.mStock.Profitability = ( nGradient > mCfg.Profitability ? true : false );

            this.mStock.EPS = String.IsNullOrEmpty( nCols[11] ) ? 0 : Double.Parse( nCols[11] ) * this.mCurrencyRate;

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
            this.mStock.BookValue = String.IsNullOrEmpty( nCols[11] ) ? 0 : Double.Parse( nCols[11] ) * this.mCurrencyRate;
            this.mStock.AEP = this.mStock.BookValue * mCfg.BookValue;
        }

        private void parseCashFlow( String aRow )
        {

            string[] nCols = CSVParser.Split( aRow );
            if ( nCols.Length != 12 )
            {
                return;
            }

            for ( int i = 6; i < 11; i++ )
            {
                String nValue = nCols[i].Replace( ",", "" ).Replace( "\"", "" );
                double nInFlow = String.IsNullOrEmpty( nCols[i] ) ? 0 : Double.Parse( nValue );
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

            this.mStock.ROE = String.IsNullOrEmpty( nCols[11] ) ? 0 : Double.Parse( nCols[11] );
            this.mStock.Efficiency = this.mStock.ROE > mCfg.ROE ? true : false;
        }

        private void parseDebtToEquity( String aRow )
        {
            string[] nCols = aRow.Split( ',' );
            if ( nCols.Length != 12 )
            {
                return;
            }

            this.mStock.DOE = String.IsNullOrEmpty( nCols[11] ) ? 0 : Double.Parse( nCols[11] );
            this.mStock.Conservative = this.mStock.DOE > mCfg.DOE ? false : true;
        }

        private void parseEpsGrowth( String aRow3, String aRow5, String aRow10 )
        {
            double nSum3 = 0.0;
            double nSum5 = 0.0;
            double nSum10 = 0.0;
            double nMinGrowth = 10000;

            string[] nCols3 = aRow3.Split( ',' );

            nSum3 = String.IsNullOrEmpty( nCols3[10] ) ? 0.0 : double.Parse( nCols3[10] );
            if ( nSum3 != 0.0 )
                nMinGrowth = nSum3;

            string[] nCols5 = aRow5.Split( ',' );

            nSum5 = String.IsNullOrEmpty( nCols5[10] ) ? 0.0 : double.Parse( nCols5[10] );
            if ( nSum5 != 0.0 )
            {
                nMinGrowth = Math.Min( nSum5, nMinGrowth) ;
            }

            string[] nCols10 = aRow10.Split( ',' );

            nSum10 = String.IsNullOrEmpty( nCols10[10] ) ? 0.0 : double.Parse( nCols10[10] );
            if ( nSum10 != 0.0 )
            {
                nMinGrowth = Math.Min( nSum10, nMinGrowth );
            }
            
            //nMinGrowth = Math.Min( nSum3, nSum5 );
            //nMinGrowth = Math.Min( nMinGrowth, nSum10 );
            if ( nMinGrowth == 10000 )
            {
                nMinGrowth = 0;
            }

            if ( nMinGrowth != 0 )
            {
                this.mStock.PEG = this.mStock.PERatio / nMinGrowth;
                this.mStock.GEP = this.mStock.EPS * nMinGrowth;
            }
            else
            {
                this.mStock.GEP = this.mStock.PERatio / this.mStock.PEG * this.mStock.EPS;
            }

        }

        private void parseDividend( String aRow )
        {
            string[] nCols = aRow.Split( ',' );
            if ( nCols.Length != 12 )
            {
                return;
            }
            this.mStock.Dividend = String.IsNullOrEmpty( nCols[11] ) ? 0 : Double.Parse( nCols[11] ) * this.mCurrencyRate;
            this.mStock.DivYield = this.mStock.Dividend / this.mStock.Last;

            this.mStock.DEP = this.mStock.Dividend / mCfg.Dividend;
        }

        public override bool StartTXT( string aTxtString )
        {
            throw new NotImplementedException();
        }

        public override bool StartJson( string aJsonString )
        {
            throw new NotImplementedException();
        }

        private StockProfile mStock
        {
            get; set;
        }

        private Config mCfg
        {
            get; set;
        }

        private double mCurrencyRate
        {
            get; set;
        }
    }
}
