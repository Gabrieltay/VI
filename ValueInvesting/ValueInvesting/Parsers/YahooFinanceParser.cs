using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ValueInvesting.Models;

namespace ValueInvesting.Parsers
{
    public class YahooFinanceParser : AbstractParser
    {
        /*
            n - name
            p - previous close
            d - dividend per share
            y - dividend yield
            p6 - book value per share
            e - EPS
            e8 - Upcoming Year EPS
            r - P/E ratio
            r5 - PEG
            s - symbol
            x - exchange
        */

        public const String QUERY_STR = "http://finance.yahoo.com/d/quotes.csv?s=@TICK&f=npsx";

        public const String PROFILE_STR = "https://finance.yahoo.com/q/pr?s=@TICK+profile";

        private const String PROFILE_XPATH = "//div[@id=\"screen\"]/div[@id=\"rightcol\"]/table[2]/tr[2]/td[1]/p[1]";

        public YahooFinanceParser( Stock aStock )
        {
            this.mStock = aStock;
        }

        public override bool StartCSV( string aCsvString )
        {
            //if (aRawString.Contains("N/A"))
            //    return false;

            Regex CSVParser = new Regex( ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))" );
            string[] nDataArray = CSVParser.Split( aCsvString );

            if ( nDataArray[0] == "N/A" )
            {
                return false;
            }

            this.mStock.Name = nDataArray[0].Replace( "\"", "" );

            if ( nDataArray[1] != "N/A" )
                this.mStock.Last = Double.Parse( nDataArray[1] );
            if ( nDataArray[2] != "N/A" )
                this.mStock.Sym = nDataArray[2].ToUpper().Replace( "\"", "" );
            if ( nDataArray[3] != "N/A" )
                this.mStock.Mkt = MarketTranslate(nDataArray[3].Replace( "\"", "" ).Replace("\n",""));
            //if ( nDataArray[4] != "N/A" )
            //    this.mStock.BookValue = Double.Parse( nDataArray[4] );
            //if ( nDataArray[5] != "N/A" )
            //    this.mStock.EPS = Double.Parse( nDataArray[5] );
            //if ( nDataArray[6] != "N/A" )
            //    this.mStock.NextEPS = Double.Parse( nDataArray[6] );
            return true;
        }

        public override bool StartHTML( string aHtmlString )
        {
            HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml( aHtmlString );
            HtmlNode nNode = doc.DocumentNode.SelectSingleNode( PROFILE_XPATH );

            if ( nNode == null )
                return false;

            this.mStock.Summary = nNode.InnerText;
            return true;
        }


        private String MarketTranslate(String aCode)
        {
            if ( aCode == "NMS" )
                return "NASDAQ";
            else if ( aCode == "NYQ" )
                return "NYSE";
            else if ( aCode == "SES" )
                return "SGX";
            return aCode;
        }

        private Stock mStock
        {
            get; set;
        }
    }
}
