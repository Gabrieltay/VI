using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Algorithms
{
    public class StochasticOverSold : UptrendRule, IRuleInterface
    {
        public override void Compute( StockData aStockData )
        {
            List<Stoch> nStochs = TAUtil.Stochastic( aStockData, 14, 3, 3 );

            Stoch nCurStoch = nStochs[nStochs.Count - 1];

            if ( nCurStoch.SlowK < 20 ) 
            {
                this.Score = 1;
                this.Signal = true;
            }
        }

        public override string GetDescription()
        {
            return "Stochastic Oversold";
        }
    }
}
