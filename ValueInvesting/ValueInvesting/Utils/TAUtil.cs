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
            double[] nOutReal = new double[nEndIndex - nStartIndex + 1];

            TicTacTec.TA.Library.Core.Sma( nStartIndex, nEndIndex, nInReal, aPeriod, out nOutBegIdx, out nOutNBElement, nOutReal );

            double[] nOutput = new double[nEndIndex - nStartIndex + 1];
            Array.Copy( nOutReal, 0, nOutput, nOutBegIdx, nEndIndex - nOutBegIdx + 1 );

            return nOutput;
        }

        public static List<MacdPoint> MACD( StockData aStock, int aFastPeriod, int aSlowPeriod, int aSignalPeriod )
        {
            int nStartIndex = 0;
            int nEndIndex = aStock.DataPoints.Count - 1;
            double[] nInReal = getCloseValues( aStock );
            int nOutBegIdx;
            int nOutNBElement;
            double[] nOutMACD = new double[nEndIndex - nStartIndex + 1];
            double[] nOutMACDSignal = new double[nEndIndex - nStartIndex + 1];
            double[] nOutMACDHist = new double[nEndIndex - nStartIndex + 1];

            TicTacTec.TA.Library.Core.Macd( nStartIndex, nEndIndex, nInReal, aFastPeriod, aSlowPeriod, aSignalPeriod, out nOutBegIdx, out nOutNBElement, nOutMACD, nOutMACDSignal, nOutMACDHist );

            List<MacdPoint> nOutput = new List<MacdPoint>();
            for ( int j = 0; j < nOutBegIdx; j++ )
            {
                nOutput.Add( new MacdPoint() );
            }

            for ( int i = nStartIndex; i < nEndIndex - nStartIndex + 1 - nOutBegIdx; i++ )
            {
                MacdPoint nMacdPt = new MacdPoint();
                nMacdPt.Index = i;
                nMacdPt.Macd = nOutMACD[i];
                nMacdPt.Signal = nOutMACDSignal[i];
                nMacdPt.MacdHistogram = nOutMACDHist[i];
                if ( i > 0 )
                    nMacdPt.Bullish = ( nOutMACDHist[i] > nOutMACDHist[i - 1] ) ? 1 : 0;
                nOutput.Add( nMacdPt );
            }
            return nOutput;
        }

        public static List<Stoch> Stochastic( StockData aStock, int aFastKPeriod, int aSlowKPeriod, int aSlowDPeriod )
        {
            int nStartIndex = 0;
            int nEndIndex = aStock.DataPoints.Count - 1;
            double[] nInHigh = getHighValues( aStock );
            double[] nInLow = getLowValues( aStock );
            double[] nInClose = getCloseValues( aStock );
            int nOutBegIdx;
            int nOutNBElement;
            double[] nOutSlowK = new double[nEndIndex - nStartIndex + 1]; 
            double[] nOutSlowD = new double[nEndIndex - nStartIndex + 1]; 
            TicTacTec.TA.Library.Core.Stoch( nStartIndex, nEndIndex, nInHigh, nInLow, nInClose,
                aFastKPeriod, aSlowKPeriod, Core.MAType.Sma, aSlowDPeriod, Core.MAType.Sma, out nOutBegIdx, out nOutNBElement, nOutSlowK, nOutSlowD );

            List<Stoch> nOutput = new List<Stoch>();

            for ( int j = 0; j < nOutBegIdx; j++ )
            {
                nOutput.Add( new Stoch() );
            }

            for ( int i = nStartIndex; i < nEndIndex - nStartIndex + 1 - nOutBegIdx; i++ )
            {
                Stoch nStoch = new Stoch();
                nStoch.SlowK = nOutSlowK[i];
                nStoch.SlowD = nOutSlowD[i];
                nOutput.Add( nStoch );
            }

            return nOutput;
        }

        public static double[] EMA(StockData aStock, int aTimePeriod)
        {
            int nStartIndex = 0;
            int nEndIndex = aStock.DataPoints.Count - 1;
            double[] nInClose = getCloseValues( aStock );
            int nOutBegIdx;
            int nOutNBElement;
            double[] nOutReal = new double[nEndIndex - nStartIndex + 1]; 
            TicTacTec.TA.Library.Core.Ema( nStartIndex, nEndIndex, nInClose, aTimePeriod, out nOutBegIdx, out nOutNBElement, nOutReal );

            double[] nOutput = new double[nEndIndex - nStartIndex + 1];
            Array.Copy( nOutReal, 0, nOutput, nOutBegIdx, nEndIndex - nOutBegIdx + 1 );

            return nOutput;
        }

        public static double[] SAR(StockData aStock, double aAcceleration, double aMaxAcceleration)
        {
            int nStartIndex = 0;
            int nEndIndex = aStock.DataPoints.Count - 1;
            double[] nInHigh = getHighValues( aStock );
            double[] nInLow = getLowValues( aStock );
            int nOutBegIdx;
            int nOutNBElement;
            double[] nOutReal = new double[nEndIndex - nStartIndex + 1];
            TicTacTec.TA.Library.Core.Sar( nStartIndex, nEndIndex, nInHigh, nInLow, aAcceleration, aMaxAcceleration, out nOutBegIdx, out nOutNBElement, nOutReal );

            double[] nOutput = new double[nEndIndex - nStartIndex + 1];
            Array.Copy( nOutReal, 0, nOutput, nOutBegIdx, nEndIndex - nOutBegIdx + 1 );

            return nOutput;
        }

        public static void HangingMan(StockData aStock)
        {
            int nStartIndex = 0;
            int nEndIndex = aStock.DataPoints.Count - 1;
            double[] nInOpen = getOpenValues( aStock );
            double[] nInClose = getCloseValues( aStock );
            double[] nInHigh = getHighValues( aStock );
            double[] nInLow = getLowValues( aStock );
            int nOutBegIdx;
            int nOutNBElement;
            int[] nOutInteger = new int[nEndIndex - nStartIndex + 1];
            TicTacTec.TA.Library.Core.CdlHangingMan( nStartIndex, nEndIndex, nInOpen, nInHigh, nInLow, nInClose, out nOutBegIdx, out nOutNBElement, nOutInteger );

            int[] nOutput = new int[nEndIndex - nStartIndex + 1];
            Array.Copy( nOutInteger, 0, nOutput, nOutBegIdx, nEndIndex - nOutBegIdx + 1 );

            for ( int i = nEndIndex; i >= 0; i-- )
            {
                int nn;
                if ( nOutput[i] != 0 )
                {
                    nn = nOutput[i];
                    DateTime mm = aStock.DataPoints[i].Date;
                }
            }
        }

        public static void Hammar( StockData aStock )
        {
            int nStartIndex = 0;
            int nEndIndex = aStock.DataPoints.Count - 1;
            double[] nInOpen = getOpenValues( aStock );
            double[] nInClose = getCloseValues( aStock );
            double[] nInHigh = getHighValues( aStock );
            double[] nInLow = getLowValues( aStock );
            int nOutBegIdx;
            int nOutNBElement;
            int[] nOutInteger = new int[nEndIndex - nStartIndex + 1];
            TicTacTec.TA.Library.Core.CdlHammer( nStartIndex, nEndIndex, nInOpen, nInHigh, nInLow, nInClose, out nOutBegIdx, out nOutNBElement, nOutInteger );

            int[] nOutput = new int[nEndIndex - nStartIndex + 1];
            Array.Copy( nOutInteger, 0, nOutput, nOutBegIdx, nEndIndex - nOutBegIdx + 1 );

            for ( int i = nEndIndex; i >= 0; i-- )
            {
                int nn;
                if ( nOutput[i] != 0 )
                {
                    nn = nOutput[i];
                    DateTime mm = aStock.DataPoints[i].Date;
                }
            }
        }

        public static void Doji( StockData aStock )
        {
            int nStartIndex = 0;
            int nEndIndex = aStock.DataPoints.Count - 1;
            double[] nInOpen = getOpenValues( aStock );
            double[] nInClose = getCloseValues( aStock );
            double[] nInHigh = getHighValues( aStock );
            double[] nInLow = getLowValues( aStock );
            int nOutBegIdx;
            int nOutNBElement;
            int[] nOutInteger = new int[nEndIndex - nStartIndex + 1];
            TicTacTec.TA.Library.Core.CdlDoji( nStartIndex, nEndIndex, nInOpen, nInHigh, nInLow, nInClose, out nOutBegIdx, out nOutNBElement, nOutInteger );

            int[] nOutput = new int[nEndIndex - nStartIndex + 1];
            Array.Copy( nOutInteger, 0, nOutput, nOutBegIdx, nEndIndex - nOutBegIdx + 1 );

            for ( int i = nEndIndex; i >= 0; i-- )
            {
                int nn;
                if ( nOutput[i] != 0 )
                {
                    nn = nOutput[i];
                    DateTime mm = aStock.DataPoints[i].Date;
                }
            }
        }

        private static double[] getOpenValues( StockData aStock)
        {
            return aStock.DataPoints.Select( x => x.Open ).ToArray();
        }

        private static double[] getCloseValues( StockData aStock )
        {
            return aStock.DataPoints.Select( x => x.Close ).ToArray();
        }

        private static double[] getHighValues( StockData aStock )
        {
            return aStock.DataPoints.Select( x => x.High ).ToArray();
        }

        private static double[] getLowValues( StockData aStock )
        {
            return aStock.DataPoints.Select( x => x.Low ).ToArray();
        }
    }
}
