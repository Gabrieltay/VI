using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Algorithms
{
    public class HangingManReversal : DowntrendRule, IRuleInterface
    {
        public override void Compute( StockData aStockData )
        {
            if ( TAUtil.HangingMan( aStockData ) || TAUtil.ShootingStar( aStockData ) )
            {
                this.Score = 1;
                this.Signal = true;
            }
        }

        public override string GetDescription()
        {
            return "Candlestick HangingMan Reversal";
        }
    }
}
