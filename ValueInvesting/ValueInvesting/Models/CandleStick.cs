using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Models
{
    [Serializable]
    public class CandleStick
    {
        public CandleStick()
        {

        }

        public CandleStick(DateTime aDate, double aOpen, double aHigh, double aLow, double aClose, long aVolume, double aAdjClose)
        {
            this.Date = aDate;
            this.Open = aOpen;
            this.High = aHigh;
            this.Low = aLow;
            this.Close = aClose;
            this.Volume = aVolume;
            this.AdjClose = aAdjClose;
        }

        public DateTime Date
        {
            get; set;
        }

        public double High
        {
            get; set;
        }

        public double Low
        {
            get; set;
        }

        public double Open
        {
            get; set;
        }

        public double Close
        {
            get; set;
        }

        public long Volume
        {
            get; set;
        }

        public double AdjClose
        {
            get; set;
        }
    }
}
