﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Commons;

namespace ValueInvesting.Models
{
    [Serializable]
    public class Stock
    {
        public String Name
        {
            get; set;
        }

        public String Mkt
        {
            get; set;
        }

        public Enums.Market Market
        {
            get; set;
        }

        public String Sym
        {
            get; set;
        }
    }
}
