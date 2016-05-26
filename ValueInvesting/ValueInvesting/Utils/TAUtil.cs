using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacTec.TA.Library;
using ValueInvesting.Models;

namespace ValueInvesting.Utils
{
    public static class TAUtil
    {
        public static double[] SMA( StockData nStock, int nPeriod )
        {
            int nStartIndex = 0;
            int nEndIndex = nStock.DataPoints.Count - 1;
            double[] nInReal = getCloseValues( nStock );
            int nOutBegIdx;
            int nOutNBElement;
            double[] nOutReal = new double[nEndIndex - nStartIndex - nPeriod + 2];

            TicTacTec.TA.Library.Core.Sma( nStartIndex, nEndIndex, nInReal, nPeriod, out nOutBegIdx, out nOutNBElement, nOutReal );

            double[] nOuput = new double[nEndIndex - nStartIndex + 1];
            nOutReal.CopyTo( nOuput, nPeriod - 1 );
            return nOuput;
        }

        private static double[] getCloseValues( StockData nStock )
        {
            return nStock.DataPoints.Select( x => x.Close ).ToArray();
        }
    }
}
