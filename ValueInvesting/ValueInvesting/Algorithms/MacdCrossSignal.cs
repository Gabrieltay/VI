using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Algorithms
{
    public class MacdCrossSignal : UptrendRule, IRuleInterface
    {
        public override void Compute( StockData aStockData )
        {
            List<MacdPoint> nMacds = TAUtil.MACD( aStockData, 12, 26, 9 );

            MacdPoint nPrevMacd = nMacds[nMacds.Count - 2];
            MacdPoint nCurMacd = nMacds[nMacds.Count - 1];

            double nPrevMacdLine = nPrevMacd.Macd;
            double nPrevSignalLine = nPrevMacd.Signal;

            double nCurMacLine = nCurMacd.Macd;
            double nCurSignalLine = nCurMacd.Signal;

            if ((nPrevMacdLine < nPrevSignalLine) &&
                (nCurMacLine > nCurSignalLine))
            {
                this.Score = 1;
                this.Signal = true;
            }
        }

        public override string GetDescription()
        {
            return "MACD Line Crossover Signal Line";
        }
    }
}
