using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Algorithms
{
    public class WilliamROverSold : UptrendRule, IRuleInterface
    {
        public override void Compute( StockData aStockData )
        {
            double[] nFastWillR = TAUtil.WilliamR( aStockData, 10 );

            double[] nSlowWillR = TAUtil.WilliamR( aStockData, 260 );

            if ( nFastWillR[nFastWillR.Length - 1] < -80 && nSlowWillR[nSlowWillR.Length -1] < -80 )
            {
                this.Score = 1;
                this.Signal = true;
            }
        }

        public override string GetDescription()
        {
            return "William %R Oversold";
        }
    }
}
