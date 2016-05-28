using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueInvesting.Models;
using ValueInvesting.Utils;
using ZedGraph;

namespace ValueInvesting.Views
{
    public partial class ChartingForm : Form
    {
        private GraphPane mCandleStickPane;

        private GraphPane mMacdPane;

        private GraphPane mStochasticPane;

        public ChartingForm( StockData aStock )
        {
            this.Stock = aStock;
            this.SPList = new StockPointList();
            this.MACDList = new List<MacdPoint>();

            for ( int i = 0; i < this.Stock.DataPoints.Count; i++ )
            {
                CandleStick nCandleStick = this.Stock.DataPoints[i];
                XDate xDate = new XDate( nCandleStick.Date );
                StockPt nPoint = new StockPt( xDate.XLDate, nCandleStick.High, nCandleStick.Low, nCandleStick.Open, nCandleStick.Close, nCandleStick.Volume );
                this.SPList.Add( nPoint );
            }

            InitializeComponent();

            this.ZedGraphControl.MasterPane = new MasterPane();
            this.mCandleStickPane = new GraphPane();
            this.mMacdPane = new GraphPane();
            this.mStochasticPane = new GraphPane();

            InitializeZedGraph();
            DrawSmaGraph( this.mCandleStickPane, 20, Color.Red );
            DrawSmaGraph( this.mCandleStickPane, 50, Color.Blue );
            DrawCandleStickGraph( this.mCandleStickPane );
            DrawMacdGraph( this.mMacdPane, 12, 26, 9, Color.Blue, Color.Red );
            DrawStochPane( this.mStochasticPane, 14, 3, 3, Color.Blue, Color.Red );

            this.ZedGraphControl.AxisChange();
            this.ZedGraphControl.Dock = DockStyle.Fill;
            this.ZedGraphControl.Refresh();
        }

        private void InitializeZedGraph()
        {
            this.ZedGraphControl.IsAntiAlias = true;
            this.ZedGraphControl.IsEnableVPan = false;
            this.ZedGraphControl.IsEnableVZoom = false;
            this.ZedGraphControl.IsSynchronizeXAxes = true;
            
            this.ZedGraphControl.MasterPane.Add( this.mCandleStickPane );
            this.ZedGraphControl.MasterPane.Add( this.mMacdPane );
            this.ZedGraphControl.MasterPane.Add( this.mStochasticPane );
            this.ZedGraphControl.MasterPane.Fill = new Fill( this.BgColor );

            using ( Graphics g = ZedGraphControl.CreateGraphics() )
            {
                this.ZedGraphControl.MasterPane.SetLayout( g, true, new int[] { 1, 1, 1 }, new float[] { 6f, 2f, 2f } );
                //this.ZedGraphControl.MasterPane.SetLayout( g, PaneLayout.SingleColumn );
                this.ZedGraphControl.MasterPane.InnerPaneGap = 3f;
                this.ZedGraphControl.MasterPane.ReSize( g, new RectangleF( 0, 0, this.ZedGraphControl.Width, this.ZedGraphControl.Height ) );
            }
        }

        private void InitializeGraphPane( GraphPane myPane, String aGraphName )
        {

            myPane.Chart.Fill = new Fill( this.BgColor );
            myPane.Fill = new Fill( this.BgColor );

            // Title
            myPane.Title.Text = aGraphName;
            myPane.Title.FontSpec.FontColor = this.FnColor;
            myPane.Title.FontSpec.Family = "Century Gothic";

            // Legend
            myPane.Legend.IsVisible = true;
            myPane.Legend.FontSpec.FontColor = this.FnColor;
            myPane.Legend.Fill = new Fill( this.BgColor );

            // XAxis
            myPane.XAxis.Title.Text = "";
            myPane.XAxis.Scale.Format = "dd-MMM-yy";
            myPane.XAxis.Scale.FontSpec.Size = 8f;
            myPane.XAxis.Scale.FontSpec.FontColor = this.FnColor;
            myPane.XAxis.Scale.MaxAuto = false;
            myPane.XAxis.Scale.MinAuto = false;
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MinorGrid.IsVisible = true;
            myPane.XAxis.Type = AxisType.DateAsOrdinal;

            // YAxis
            myPane.YAxis.Title.Text = "";
            myPane.YAxis.Scale.Format = "0.##";
            myPane.YAxis.Scale.FontSpec.Size = 8f;
            myPane.YAxis.Scale.FontSpec.FontColor = this.FnColor;
            myPane.YAxis.Scale.MaxAuto = false;
            myPane.YAxis.Scale.MinAuto = false;
            myPane.YAxis.MajorGrid.IsVisible = true;

            myPane.Border.IsVisible = false;
        }

        private void AdjustSmallerPane( GraphPane myPane )
        {
            myPane.Title.FontSpec.Size = 24f;
            myPane.Legend.FontSpec.Size = 24f;
            myPane.YAxis.Scale.FontSpec.Size = 24f;
            myPane.XAxis.IsVisible = false;
            myPane.Margin.Left *= 4.5f;
            myPane.Margin.Right *= 9.5f;
        }

        private void DrawCandleStickGraph( GraphPane myPane )
        {
            InitializeGraphPane( myPane, this.Stock.Name );
            JapaneseCandleStickItem myCurve = myPane.AddJapaneseCandleStick( "", this.SPList );
            myCurve.Stick.IsAutoSize = true;
            myCurve.Stick.RisingFill = new Fill( RiseColor );
            myCurve.Stick.RisingBorder = new Border( RiseColor, 1 );
            myCurve.Stick.FallingFill = new Fill( FallColor );
            myCurve.Stick.FallingBorder = new Border( FallColor, 1 );
            myCurve.Stick.Color = RiseColor;
            myCurve.Stick.FallingColor = FallColor;

            this.OriginalXAxisScale( myPane );
            this.AutoCandlestickAxisScale( myPane );
        }

        private void DrawSmaGraph( GraphPane myPane, int aPeriod, Color aLineColor )
        {
            InitializeGraphPane( myPane, this.Stock.Name );

            double[] nSma = TAUtil.SMA( this.Stock, aPeriod );

            PointPairList list = new PointPairList();
            for ( int i = 0; i < nSma.Length; i++ )
            {
                double x = (double)new XDate( this.Stock.DataPoints[i].Date );
                double y = nSma[i];

                list.Add( x, y );
            }

            LineItem myCurve = myPane.AddCurve( "SMA" + aPeriod.ToString(), list, aLineColor );
            myCurve.Symbol.IsAntiAlias = true;
            myCurve.Symbol.IsVisible = false;

            this.OriginalXAxisScale( myPane );
            this.AutoCandlestickAxisScale( myPane );
        }

        private void DrawMacdGraph( GraphPane myPane, int aFastPeriod, int aShortPeriod, int aSignalPeriod, Color aMacdColor, Color aSignalColor )
        {
            InitializeGraphPane( myPane, "MACD Histogram" );
            this.MACDList = TAUtil.MACD( this.Stock, aFastPeriod, aShortPeriod, aSignalPeriod );

            PointPairList nMacdList = new PointPairList();
            PointPairList nSignalList = new PointPairList();
            PointPairList nHistoList = new PointPairList();
            for ( int i = 0; i < this.MACDList.Count; i++ )
            {
                double x = (double)new XDate( this.Stock.DataPoints[i].Date );
                double y = this.MACDList[i].Macd;
                double z = this.MACDList[i].Signal;
                double v = this.MACDList[i].MacdHistogram;
                double w = this.MACDList[i].Bullish;
                nMacdList.Add( x, y );
                nSignalList.Add( x, z );
                nHistoList.Add( x, v, w );
            }

            LineItem myCurve = myPane.AddCurve( "MACD(" + aShortPeriod.ToString() + "," + aFastPeriod.ToString() + ")", nMacdList, aMacdColor );
            LineItem myCurve2 = myPane.AddCurve( "Signal(" + aSignalPeriod.ToString() + ")", nSignalList, aSignalColor );
            BarItem myBar = myPane.AddBar( "MACD Histogram", nHistoList, Color.BlueViolet );

            myCurve.Symbol.IsAntiAlias = true;
            myCurve.Symbol.IsVisible = false;

            myCurve2.Symbol.IsAntiAlias = true;
            myCurve2.Symbol.IsVisible = false;

            Fill nFillColors = new Fill( new Color[] { this.FallColor, this.RiseColor } );
            nFillColors.RangeMin = 0.5;
            nFillColors.RangeMax = 0.6;
            myBar.Bar.Fill = nFillColors;
            myBar.Bar.Fill.Type = FillType.GradientByZ;

            this.AdjustSmallerPane( myPane );

            this.OriginalXAxisScale( myPane );
            this.AutoMacdAxisScale( myPane );
        }

        private void DrawStochPane( GraphPane myPane, int aFastKPeriod, int aSlowKPeriod, int aSlowDPeriod, Color aSlowKColor, Color aSlowDColor )
        {
            InitializeGraphPane( myPane, "Stochastic" );

            myPane.YAxis.Scale.Max = 100;
            myPane.YAxis.Scale.Min = 0;

            this.StochList = TAUtil.Stochastic( this.Stock, aFastKPeriod, aSlowKPeriod, aSlowDPeriod );
            PointPairList nSlowKList = new PointPairList();
            PointPairList nSlowDList = new PointPairList();
            PointPairList nHalfList = new PointPairList();
            for ( int i = 0; i < this.StochList.Count; i++ )
            {
                double x = (double)new XDate( this.Stock.DataPoints[i].Date );
                double y = this.StochList[i].SlowK;
                double z = this.StochList[i].SlowD;
                nSlowKList.Add( x, y );
                nSlowDList.Add( x, z );
                nHalfList.Add( x, 50 );
            }

            LineItem myCurve = myPane.AddCurve( "Slow K(" + aSlowKPeriod.ToString() + ")", nSlowKList, aSlowKColor );
            LineItem myCurve2 = myPane.AddCurve( "Smoothed D(" + aSlowDPeriod.ToString() + ")", nSlowDList, aSlowDColor );
            LineItem myCurve3 = myPane.AddCurve( "", nHalfList, Color.LightGray );

            myCurve.Symbol.IsAntiAlias = true;
            myCurve.Symbol.IsVisible = false;

            myCurve2.Symbol.IsAntiAlias = true;
            myCurve2.Symbol.IsVisible = false;

            myCurve3.Symbol.IsAntiAlias = true;
            myCurve3.Symbol.IsVisible = false;
            myCurve3.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            myCurve3.Line.DashOn = 10;
            myCurve3.Line.DashOff = 5;

            this.AdjustSmallerPane( myPane );

            this.OriginalXAxisScale( myPane );
        }

        private void OriginalXAxisScale( GraphPane myPane )
        {
            myPane.XAxis.Scale.Max = this.SPList.Count + 0.5;
            myPane.XAxis.Scale.Min = myPane.XAxis.Scale.Max - 50;
        }

        private void AutoCandlestickAxisScale( GraphPane myPane )
        {
            int nXAxisMax = Math.Min( (int)myPane.XAxis.Scale.Max, this.SPList.Count - 1 );
            int nXAxisMin = Math.Max( (int)myPane.XAxis.Scale.Min, 0 );

            double nYAxisMin = double.MaxValue;
            double nYAxisMax = double.MinValue;

            for ( int i = nXAxisMin; i <= nXAxisMax; i++ )
            {
                nYAxisMin = Math.Min( nYAxisMin, this.SPList.GetAt( i ).Low );
                nYAxisMax = Math.Max( nYAxisMax, this.SPList.GetAt( i ).High );
            }

            myPane.YAxis.Scale.Max = nYAxisMax * 1.05;
            myPane.YAxis.Scale.Min = nYAxisMin * 0.95;

            double nRange = myPane.YAxis.Scale.Max - myPane.YAxis.Scale.Min;

            if ( nRange < 1.0 )
            {
                myPane.YAxis.Scale.MajorStep = 0.05;
            }
            else if ( nRange < 10 )
            {
                myPane.YAxis.Scale.MajorStep = 0.5;
            }
            else if ( nRange < 100 )
            {
                myPane.YAxis.Scale.MajorStep = 5.0;
            }
            else if ( nRange < 1000 )
            {
                myPane.YAxis.Scale.MajorStep = 50.0;
            }
        }

        private void AutoMacdAxisScale( GraphPane myPane )
        {
            int nXAxisMax = Math.Min( (int)myPane.XAxis.Scale.Max, this.SPList.Count - 1 );
            int nXAxisMin = Math.Max( (int)myPane.XAxis.Scale.Min, 0 );

            double nYAxisMin = double.MaxValue;
            double nYAxisMax = double.MinValue;

            for ( int i = nXAxisMin; i <= nXAxisMax; i++ )
            {
                nYAxisMin = Math.Min( nYAxisMin, this.MACDList[i].Macd );
                nYAxisMin = Math.Min( nYAxisMin, this.MACDList[i].Signal );
                nYAxisMin = Math.Min( nYAxisMin, this.MACDList[i].MacdHistogram );
                nYAxisMax = Math.Max( nYAxisMax, this.MACDList[i].Macd );
                nYAxisMax = Math.Max( nYAxisMax, this.MACDList[i].Signal );
                nYAxisMax = Math.Max( nYAxisMax, this.MACDList[i].MacdHistogram );
            }

            if ( nYAxisMax >= 0 && nYAxisMin >= 0 )
            {
                myPane.YAxis.Scale.Max = nYAxisMax * 1.05;
                myPane.YAxis.Scale.Min = nYAxisMax * -1.05;
            }
            else if ( nYAxisMax >= 0 && nYAxisMin < 0 )
            {
                nYAxisMax = Math.Max( nYAxisMax, nYAxisMin * -1 );
                myPane.YAxis.Scale.Max = nYAxisMax * 1.05;
                myPane.YAxis.Scale.Min = nYAxisMax * -1.05;
            }
            else if ( nYAxisMax < 0 && nYAxisMin < 0 )
            {
                myPane.YAxis.Scale.Max = nYAxisMax * -1.05;
                myPane.YAxis.Scale.Min = nYAxisMax * 1.05;
            }
        }

        private StockData Stock
        {
            get; set;
        }

        private StockPointList SPList
        {
            get; set;
        }

        private List<MacdPoint> MACDList
        {
            get; set;
        }

        private List<Stoch> StochList
        {
            get; set;
        }

        #region Colors
        private Color FallColor
        {
            get
            {
                return Color.FromArgb( 255, 95, 95 );
            }
        }

        private Color RiseColor
        {
            get
            {
                return Color.FromArgb( 0, 197, 49 );
            }
        }

        private Color BgColor
        {
            get
            {
                return Color.FromArgb( 64, 64, 64 );
            }
        }

        private Color FnColor
        {
            get
            {
                return Color.WhiteSmoke;
            }
        }

        #endregion

        private void CandleStickGraph_ZoomEvent( ZedGraphControl sender, ZoomState oldState, ZoomState newState )
        {
            this.AutoCandlestickAxisScale( this.mCandleStickPane );
            this.AutoMacdAxisScale( this.mMacdPane );
            this.ZedGraphControl.Invalidate();
        }


        //PointPairList userClickrList = new PointPairList();
        //int index = 0;
        //double xVal;
        //double yVal;
        //object nearestobject = null;
        //PointF clickedPoint = new PointF( e.X, e.Y );
        //this.mCandleStickPane.FindNearestObject( clickedPoint, this.CreateGraphics(), out nearestobject, out index );
        //this.mCandleStickPane.ReverseTransform( e.Location, out xVal, out yVal );
        //userClickrList.Add( xVal, mCandleStickPane.YAxis.Scale.Max );
        //userClickrList.Add( xVal, mCandleStickPane.YAxis.Scale.Min );
        //this.mCandleStickPane.AddCurve( "", userClickrList, Color.LightYellow, SymbolType.None );
        //this.ZedGraphControl.Refresh();

    }
}
