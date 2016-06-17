using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Algorithms
{
    public class Sma50Sma150Up : UptrendRule, IRuleInterface
    {
        public override void Compute( StockData aStockData )
        {
            double[] n50Sma = TAUtil.SMA( aStockData, 50 );
            double[] n150Sma = TAUtil.SMA( aStockData, 150 );

            double nPrev50Sma = n50Sma[n50Sma.Length - 2];
            double nPrev150Sma = n150Sma[n150Sma.Length - 2];

            double nCur50Sma = n50Sma[n50Sma.Length - 1];
            double nCur150Sma = n150Sma[n150Sma.Length - 1];

            if (( nCur50Sma > nPrev50Sma ) &&
                ( nCur150Sma > nPrev150Sma ) &&
                ( nCur50Sma > nCur150Sma ) )
            {
                this.Score = 1;
                this.Signal = true;
            }
        }

        public override string GetDescription()
        {
            return "50SMA Above 150SMA";
        }
    }
}
