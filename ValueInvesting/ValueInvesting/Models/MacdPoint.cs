using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Models
{
    public class MacdPoint
    {
        public int Index
        {
            get; set;
        }

        public double Macd
        {
            get; set;
        }

        public double Signal
        {
            get; set;
        }

        public double MacdHistogram
        {
            get; set;
        }

        public int Bullish
        {
            get; set;
        }
    }
}
