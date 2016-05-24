using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Models
{
    [Serializable]
    public class StockData : Stock
    {
        public StockData()
        {
            this.DataPoints = new List<CandleStick>();
        }

        public DateTime StartDate
        {
            get; set;
        }

        public DateTime LastDate
        {
            get; set;
        }

        public List<CandleStick> DataPoints
        {
            get; set;
        }
    }
}
