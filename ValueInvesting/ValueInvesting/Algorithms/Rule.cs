using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;

namespace ValueInvesting.Algorithms
{
    public class Rule : IRuleInterface
    {
        public int Score
        {
            get; set;
        }

        public bool Signal
        {
            get; set;
        }

        void IRuleInterface.Compute( StockData aStockData )
        {
            throw new NotImplementedException();
        }

        string IRuleInterface.GetDescription()
        {
            throw new NotImplementedException();
        }

        public virtual void Compute( StockData aStockData ) { }

        public virtual String GetDescription() { return ""; }
    }

    public class UptrendRule : Rule
    {
    }

    public class DowntrendRule : Rule
    {
    }

}
