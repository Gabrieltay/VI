using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Algorithms
{
    public class Ema20CrossEma40 : UptrendRule, IRuleInterface
    {
        public override void Compute( StockData aStockData )
        {
            double[] n20Ema = TAUtil.EMA( aStockData, 20 );
            double[] n40Ema = TAUtil.EMA( aStockData, 40 );

            double nPrev20Ema = n20Ema[n20Ema.Length - 2];
            double nPrev40Ema = n40Ema[n40Ema.Length - 2];

            double nCur20Ema = n20Ema[n20Ema.Length - 1];
            double nCur40Ema = n40Ema[n40Ema.Length - 1];

            if ( ( nCur20Ema >= nPrev20Ema ) &&
                ( nCur40Ema >= nPrev40Ema ) &&
                ( nPrev40Ema > nPrev20Ema ) &&
                ( nCur20Ema > nCur40Ema ) )
            {
                this.Score = 1;
                this.Signal = true;
            }
        }

        public override string GetDescription()
        {
            return "20EMA Crosses Over 40EMA";
        }
    }
}
