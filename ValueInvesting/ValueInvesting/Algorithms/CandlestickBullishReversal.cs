using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Algorithms
{
    public class CandlestickBullishReversal : UptrendRule, IRuleInterface
    {
        public override void Compute( StockData aStockData )
        {
            if ( TAUtil.Hammer( aStockData ) ||
                TAUtil.InvertedHammer( aStockData ) ||
                TAUtil.Piercing( aStockData ) ||
                TAUtil.Engulfing( aStockData ) > 0 ||
                TAUtil.HaramiCross(aStockData) > 0 || 
                TAUtil.Harami(aStockData) > 0 ||
                TAUtil.CounterAttack(aStockData) > 0 )
            {
                this.Score = 1;
                this.Signal = true;
            }
        }

        public override string GetDescription()
        {
            return "Candlestick Bullish Reversal";
        }
    }
}
