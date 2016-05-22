using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Parsers
{
    public abstract class AbstractParser
    {
        public abstract Boolean StartCSV( String aCsvString );

        public abstract Boolean StartHTML( String aHtmlString );
    }
}
