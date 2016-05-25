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
using ZedGraph;

namespace ValueInvesting.Views
{
    public partial class ChartingForm : Form
    {
        public ChartingForm( StockData aStock )
        {
            this.Stock = aStock;
            this.SPList = new StockPointList();
            for ( int i = 0; i < this.Stock.DataPoints.Count; i++ )
            {
                CandleStick nCandleStick = this.Stock.DataPoints[i];
                XDate xDate = new XDate( nCandleStick.Date );
                StockPt nPoint = new StockPt( xDate.XLDate, nCandleStick.High, nCandleStick.Low, nCandleStick.Open, nCandleStick.Close, nCandleStick.Volume );
                this.SPList.Add( nPoint );
            }

            InitializeComponent();
            InitializeZedGraph();
            DrawCandleStickGraph();
        }

        private void InitializeZedGraph()
        {
            this.CandleStickGraph.IsAntiAlias = true;
            this.CandleStickGraph.IsEnableVPan = false;
            this.CandleStickGraph.IsEnableVZoom = false;

            GraphPane myPane = this.CandleStickGraph.GraphPane;

            myPane.Chart.Fill = new Fill( this.BgColor );
            myPane.Fill = new Fill( this.BgColor );

            // Title
            myPane.Title.Text = this.Stock.Name;
            myPane.Title.FontSpec.FontColor = this.FnColor;
            myPane.Title.FontSpec.Family = "Century Gothic";

            // Legend
            myPane.Legend.IsVisible = false;

            // XAxis
            myPane.XAxis.Title.Text = "";
            myPane.XAxis.Scale.Format = "dd-MMM-yy";
            myPane.XAxis.Scale.FontSpec.Size = 8f;
            myPane.XAxis.Scale.FontSpec.FontColor = this.FnColor;
            myPane.XAxis.Scale.MaxAuto = true;
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
        }

        private void DrawCandleStickGraph()
        {
            GraphPane myPane = this.CandleStickGraph.GraphPane;

            JapaneseCandleStickItem myCurve = myPane.AddJapaneseCandleStick( "Trades", this.SPList );
            myCurve.Stick.IsAutoSize = true;
            myCurve.Stick.RisingFill = new Fill( RiseColor );
            myCurve.Stick.RisingBorder = new Border( RiseColor, 1 );
            myCurve.Stick.FallingFill = new Fill( FallColor );
            myCurve.Stick.FallingBorder = new Border( FallColor, 1 );
            myCurve.Stick.Color = RiseColor;
            myCurve.Stick.FallingColor = FallColor;

            this.CandleStickGraph.AxisChange(); 
            myPane.XAxis.Scale.Min = myPane.XAxis.Scale.Max - 50;
            this.AutoAxisScale();
        }

        private void AutoAxisScale()
        {
            GraphPane myPane = this.CandleStickGraph.GraphPane;
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

            myPane.AxisChange();
            this.CandleStickGraph.Refresh();
        }

        private StockData Stock
        {
            get; set;
        }

        private StockPointList SPList
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
            this.AutoAxisScale();
        }
    }
}
