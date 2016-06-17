using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;

namespace ValueInvesting.Algorithms
{
    public interface IRuleInterface
    {
        void Compute(StockData aStockData);

        String GetDescription();
    }
}
