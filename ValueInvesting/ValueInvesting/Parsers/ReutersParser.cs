using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;

namespace ValueInvesting.Parsers
{
    public class ReutersParser : AbstractParser
    {
        public const String QUERY_STR = "http://www.reuters.com/finance/stocks/companyProfile?symbol=@TICK";

        private const String PROFILE_XPATH = "//*[@id=\"companyNews\"]/div/div[2]/p[1]";

        public ReutersParser( StockProfile aStock )
        {
            this.mStock = aStock;
        }

        public override bool StartCSV( string aCsvString )
        {
            throw new NotImplementedException();
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

        public override bool StartJson( string aJsonString )
        {
            throw new NotImplementedException();
        }

        public override bool StartTXT( string aTxtString )
        {
            throw new NotImplementedException();
        }

        private StockProfile mStock
        {
            get; set;
        }
    }
}
