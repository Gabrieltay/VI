using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ValueInvesting.Models;

namespace ValueInvesting.Parsers
{
    public class YahooFinanceDownloader : AbstractParser
    {
        public const String QUERY_PARTIAL_STR = "http://ichart.finance.yahoo.com/table.csv?d=@EM&e=@ED&f=@EY&g=d&a=@SM&b=@SD&c=@SY&ignore=.csv&s=@TICK";

        public const String QUERY_FULL_STR = "http://ichart.finance.yahoo.com/table.csv?d=@EM&e=@ED&f=@EY&g=d&ignore=.csv&s=@TICK";

        public YahooFinanceDownloader( StockData aStockData )
        {
            this.mStockData = aStockData;
        }

        public override bool StartCSV( string aCsvString )
        {

            string[] nRows = aCsvString.Replace( "\r", "" ).Split( '\n' );
            for ( int i = nRows.Length-1; i > 0; i-- )
            {
                if ( String.IsNullOrEmpty( nRows[i] ) )
                    continue;

                Regex CSVParser = new Regex( ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))" );
                string[] nDataArray = CSVParser.Split( nRows[i] );

                CandleStick nData = new CandleStick();
                nData.Date = DateTime.Parse( nDataArray[0] );
                nData.Open = double.Parse( nDataArray[1] );
                nData.High = double.Parse( nDataArray[2] );
                nData.Low = double.Parse( nDataArray[3] );
                nData.Close = double.Parse( nDataArray[4] );
                nData.Volume = long.Parse( nDataArray[5] );
                nData.AdjClose = double.Parse( nDataArray[6] );

                if ( this.mStockData.StartDate == default(DateTime) || this.mStockData.StartDate.Date.CompareTo( nData.Date.Date ) > 0 )
                    this.mStockData.StartDate = nData.Date;

                if ( this.mStockData.LastDate == default( DateTime ) || this.mStockData.LastDate.Date.CompareTo( nData.Date.Date ) < 0 )
                {
                    this.mStockData.DataPoints.Add( nData );
                    this.mStockData.LastDate = nData.Date;
                }
                    
            }
            return true;
        }

        public override bool StartHTML( string aHtmlString )
        {
            throw new NotImplementedException();
        }

        public override bool StartTXT( string aTxtString )
        {
            throw new NotImplementedException();
        }

        private StockData mStockData
        {
            get; set;
        }
    }
}
