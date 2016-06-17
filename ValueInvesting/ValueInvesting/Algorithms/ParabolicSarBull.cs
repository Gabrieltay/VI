using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;
using ValueInvesting.Utils;

namespace ValueInvesting.Algorithms
{
    public class ParabolicSarBull : UptrendRule, IRuleInterface
    {
        public override void Compute( StockData aStockData )
        {
            double[] nSar = TAUtil.SAR( aStockData, 0.02, 0.2 );

            double nCurSar = nSar[nSar.Length - 1];
            double nCurClose = aStockData.DataPoints[nSar.Length - 1].Close;

            if ( nCurClose > nCurSar )
            {
                this.Score = 1;
                this.Signal = true;
            }
        }

        public override string GetDescription()
        {
            return "Bullish Parabolic SAR";

        }
    }
}
