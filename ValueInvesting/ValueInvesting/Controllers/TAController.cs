using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Algorithms;
using ValueInvesting.Models;

namespace ValueInvesting.Controllers
{
    public class TAController
    {
        public TAController( StockData aStockData )
        {
            this.mStockData = aStockData;
            this.UptrendRules = new List<UptrendRule>();
            this.UptrendRules.Add( new Ema20CrossEma40() );
            this.UptrendRules.Add( new Sma50Sma150Up() );
            this.UptrendRules.Add( new ParabolicSarBull() );
            this.UptrendRules.Add( new MacdCrossSignal() );
            this.UptrendRules.Add( new MacdCrossAboveZero() );
            this.UptrendRules.Add( new MacdHistogramBull() );
            this.UptrendRules.Add( new StochasticCrossAbove() );
            this.UptrendRules.Add( new StochasticOverSold() );

            this.DowntrendRules = new List<DowntrendRule>();
            this.DowntrendRules.Add( new Ema40CrossEma20() );
            this.DowntrendRules.Add( new Sma50Sma150Down() );
            this.DowntrendRules.Add( new ParabolicSarBear() );
            this.DowntrendRules.Add( new SignalCrossMacd() );
            this.DowntrendRules.Add( new MacdCrossBelowZero() );
            this.DowntrendRules.Add( new MacdHistogramBear() );
            this.DowntrendRules.Add( new StochasticCrossBelow() );
            this.DowntrendRules.Add( new StochasticOverBought() );
        }

        public void Compute()
        {
            int nTotalBullIndicators = 0;
            int nTotalBearIndicators = 0;

            foreach ( UptrendRule nUptrendRule in UptrendRules )
            {
                nUptrendRule.Compute( this.mStockData );

                if ( nUptrendRule.Signal )
                    nTotalBullIndicators += nUptrendRule.Score;
            }

            foreach ( DowntrendRule nDowntrendRule in DowntrendRules )
            {
                nDowntrendRule.Compute( this.mStockData );

                if ( nDowntrendRule.Signal )
                    nTotalBearIndicators += nDowntrendRule.Score;
            }

            this.BullStrength = nTotalBullIndicators * 10 / UptrendRules.Count ;
            this.BearStrength = nTotalBearIndicators * 10 / DowntrendRules.Count ;
        }

        private StockData mStockData
        {
            get; set;
        }

        public int BullStrength
        {
            get; set;
        }

        public int BearStrength
        {
            get; set;
        }

        public List<UptrendRule> UptrendRules
        {
            get; set;
        }

        public List<DowntrendRule> DowntrendRules
        {
            get; set;
        }
    }
}
