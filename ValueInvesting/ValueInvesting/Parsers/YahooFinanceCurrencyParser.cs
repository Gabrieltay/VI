using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Parsers
{
    public class YahooFinanceCurrencyParser : AbstractParser
    {
        public const String QUERY_STR = "http://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s=@FRCUR@TOCUR=X";

        public YahooFinanceCurrencyParser()
        {
            this.Rate = 1.0;
        }

        public override bool StartCSV( string aCsvString )
        {
            string[] nCols = aCsvString.Split( ',' );
            this.Rate = Double.Parse( nCols[1] );
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

        public override bool StartJson( string aJsonString )
        {
            throw new NotImplementedException();
        }

        public double Rate
        {
            get;set;
        }
    }
}
