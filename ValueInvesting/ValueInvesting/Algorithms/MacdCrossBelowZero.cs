using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Algorithms
{
    public class MacdCrossBelowZero : DowntrendRule, IRuleInterface
    {
        public override void Compute( StockData aStockData )
        {
            List<MacdPoint> nMacds = TAUtil.MACD( aStockData, 12, 26, 9 );

            MacdPoint nPrevMacd = nMacds[nMacds.Count - 2];
            MacdPoint nCurMacd = nMacds[nMacds.Count - 1];

            double nPrevMacdLine = nPrevMacd.Macd;
            double nCurMacLine = nCurMacd.Macd;


            if ( ( nPrevMacdLine > 0 ) &&
                ( nCurMacLine < 0 ) )
            {
                this.Score = 1;
                this.Signal = true;
            }
        }

        public override string GetDescription()
        {
            return "MACD Line Cross Below Zero";
        }
    }
}
