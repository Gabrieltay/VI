using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;

namespace ValueInvesting.Parsers
{
    public class JittaParser : AbstractParser
    {
        public const String QUERY_STR = "https://www.jitta.com/api/v1/stocks?id=@MKT:@TICK";

        public JittaParser(StockProfile aStock)
        {
            this.mStock = aStock;
        }

        public override bool StartCSV( string aCsvString )
        {
            throw new NotImplementedException();
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
            dynamic dynObj = JsonConvert.DeserializeObject( aJsonString );
            if ( aJsonString.ToLower().Contains( "error" ) || aJsonString.Equals( "{}" ))
                return false;
            this.mStock.JittaScore = dynObj.jitta_score;
            this.mStock.JittaLine = dynObj.jitta_line;
            this.mStock.JEP = dynObj.price.close * ( 1 - ( this.mStock.JittaLine / 100 ) );
            return true;
        }

        private StockProfile mStock
        {
            get; set;
        }
    }
}
