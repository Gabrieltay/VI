using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;
using ValueInvesting.Parsers;

namespace ValueInvesting.Parsers
{
    public class EodDataSymbolsParser : AbstractParser
    {
        public EodDataSymbolsParser(Stock aStock)
        {
            this.mStocks = aStock;
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
            int nDelimiter = aTxtString.IndexOf( '\t' );
            String nSym = aTxtString.Substring( 0, nDelimiter );
            String nName = aTxtString.Substring( nDelimiter+1, aTxtString.Length - nDelimiter - 1 );
            this.mStocks.Sym = nSym;
            this.mStocks.Name = nName;
            return true;                   
        }

        public Stock mStocks
        {
            get; set;
        }
    }
}
