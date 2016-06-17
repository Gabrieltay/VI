using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Algorithms
{
    public class MacdHistogramBull : UptrendRule, IRuleInterface
    {
        public override void Compute( StockData aStockData )
        {
            List<MacdPoint> nMacds = TAUtil.MACD( aStockData, 12, 26, 9 );

            MacdPoint nPrevMacd4 = nMacds[nMacds.Count - 5];
            MacdPoint nPrevMacd3 = nMacds[nMacds.Count - 4];
            MacdPoint nPrevMacd2 = nMacds[nMacds.Count - 3];
            MacdPoint nPrevMacd1 = nMacds[nMacds.Count - 2];
            MacdPoint nCurMacd = nMacds[nMacds.Count - 1];

            if (( nPrevMacd4.Bullish == 0 ) &&
                ( nPrevMacd3.Bullish == 0 ) &&
                ( nPrevMacd2.Bullish == 0 ) &&
                ( nPrevMacd1.Bullish == 0 ) &&
                ( nCurMacd.Bullish == 1 ))
            {
                this.Score = 1;
                this.Signal = true;
            }
        }

        public override string GetDescription()
        {
            return "MACD Histogram 4 RED 1 GREEN";
        }
    }
}
