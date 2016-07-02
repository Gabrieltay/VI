using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Algorithms
{
    public class CandlestickBearishReversal : DowntrendRule, IRuleInterface
    {
        public override void Compute( StockData aStockData )
        {
            if ( TAUtil.HangingMan( aStockData ) ||
                TAUtil.ShootingStar( aStockData ) ||
                TAUtil.DarkCloud( aStockData ) ||
                TAUtil.Engulfing( aStockData ) < 0 ||
                TAUtil.HaramiCross( aStockData ) < 0 ||
                TAUtil.Harami( aStockData ) < 0 ||
                TAUtil.CounterAttack( aStockData ) < 0 )
            {
                this.Score = 1;
                this.Signal = true;
            }
        }

        public override string GetDescription()
        {
            return "Candlestick Bearish Reversal";
        }
    }
}
