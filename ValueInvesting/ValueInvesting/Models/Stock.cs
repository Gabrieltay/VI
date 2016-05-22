using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Models
{
    public class Stock
    {
        public Stock(String aSymbol)
        {
            this.Sym = aSymbol;
            this.Moat = 0;
            this.BizConf = 0;
            this.Regulatory = true;
            this.Inflation = true;
            this.ScienceTech = true;
            this.KeyPeople = true;
        }

        public String Name
        {
            get; set;
        }

        public String Mkt
        {
            get; set;
        }

        public String Sym
        {
            get; set;
        }

        public String Summary
        {
            get; set;
        }

        // Last Update Time
        public DateTime LastUpdate
        {
            get; set;
        }

        // Last done Price
        public double Last
        {
            get; set;
        }

        // Change in Percentage
        public double Change
        {
            get; set;
        }

        // Growth Entry Price
        public double GEP
        {
            get; set;
        }

        // Dividend Entry Price
        public double DEP
        {
            get; set;
        }

        // Asset Entry Price
        public double AEP
        {
            get; set;
        }

        // Business Confidence
        public double BizConf
        {
            get; set;
        }

        // Current EPS
        public double EPS
        {
            get; set;
        }

        // EPS Upcoming Year
        public double NextEPS
        {
            get; set;
        }

        // Current PE Ratio
        public double PERatio
        {
            get; set;
        }

        // PE / Growth
        public double PEG
        {
            get; set;
        }

        // Dividend
        public double Dividend
        {
            get; set;
        }

        // Dividend Yield
        public double DivYield
        {
            get; set;
        }

        // Book Value Per Share
        public double BookValue
        {
            get; set;
        }

        // Return on Equity
        public double ROE
        {
            get; set;
        }

        // Debt to Equity Ratio
        public double DOE
        {
            get; set;
        }

        public int Moat
        {
            get; set;
        }

        // PIEC
        public Boolean Profitability
        {
            get; set;
        }

        public Boolean InFlowCash
        {
            get; set;
        }

        public Boolean Efficiency
        {
            get; set;
        }

        public Boolean Conservative
        {
            get; set;
        }

        // RISK
        public Boolean Regulatory
        {
            get; set;
        }

        public Boolean Inflation
        {
            get; set;
        }

        public Boolean ScienceTech
        {
            get; set;
        }

        public Boolean KeyPeople
        {
            get; set;
        }

        public void Compute()
        {

        }

        public Boolean ComputeAssetPrice()
        {
            this.AEP = this.Last / this.BookValue * 0.8;
            return true;
        }
    }
}
