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
        public static double[] SMA( StockData aStock, int aPeriod )
        {
            int nStartIndex = 0;
            int nEndIndex = aStock.DataPoints.Count - 1;
            double[] nInReal = getCloseValues( aStock );
            int nOutBegIdx;
            int nOutNBElement;
            double[] nOutReal = new double[nEndIndex - nStartIndex - aPeriod + 2];

            TicTacTec.TA.Library.Core.Sma( nStartIndex, nEndIndex, nInReal, aPeriod, out nOutBegIdx, out nOutNBElement, nOutReal );

            double[] nOuput = new double[nEndIndex - nStartIndex + 1];
            nOutReal.CopyTo( nOuput, aPeriod - 1 );
            return nOuput;
        }

        public static List<MacdPoint> MACD( StockData aStock, int aFastPeriod, int aSlowPeriod, int aSignalPeriod )
        {
            List<MacdPoint> nMacRes = new List<MacdPoint>();
            int nStartIndex = 0;
            int nEndIndex = aStock.DataPoints.Count - 1;
            double[] nInReal = getCloseValues( aStock );
            int nOutBegIdx;
            int nOutNBElement;
            double[] nOutMACD = new double[nEndIndex - nStartIndex + 1];
            double[] nOutMACDSignal = new double[nEndIndex - nStartIndex + 1];
            double[] nOutMACDHist = new double[nEndIndex - nStartIndex + 1];

            TicTacTec.TA.Library.Core.Macd( nStartIndex, nEndIndex, nInReal, aFastPeriod, aSlowPeriod, aSignalPeriod, out nOutBegIdx, out nOutNBElement, nOutMACD, nOutMACDSignal, nOutMACDHist );

            for ( int i = nStartIndex; i < nEndIndex - nStartIndex + 1;  i++)
            {
                MacdPoint nMacdPt = new MacdPoint();
                nMacdPt.Index = i;
                nMacdPt.Macd = nOutMACD[i];
                nMacdPt.Signal = nOutMACDSignal[i];
                nMacdPt.MacdHistogram = nOutMACDHist[i];
                if ( i > 0 )
                    nMacdPt.Bullish = ( nOutMACDHist[i] > nOutMACDHist[i - 1] ) ? 1 : 0;
                nMacRes.Add( nMacdPt );
                 
            }
            nMacRes.RemoveRange( nEndIndex - 32, 33 );

            List<MacdPoint> nOutput = new List<MacdPoint>();
            for (int j = 0; j < 33; j++ )
            {
                nOutput.Add( new MacdPoint() );
            }

            nOutput.AddRange( nMacRes );
            return nOutput;
        }

        private static double[] getCloseValues( StockData nStock )
        {
            return nStock.DataPoints.Select( x => x.Close ).ToArray();
        }
    }
}
