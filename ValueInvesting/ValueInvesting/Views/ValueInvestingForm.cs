using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueInvesting.Commons;
using ValueInvesting.Controllers;
using ValueInvesting.Models;
using ValueInvesting.Observers;
using ValueInvesting.Parsers;
using ValueInvesting.Views;
using ValueInvesting.Utils;
using System.IO;
using System.Collections;

namespace ValueInvesting.Views
{
    public partial class ValueInvestingForm : Form
    {
        public ValueInvestingForm()
        {
            InitializeComponent();
            WatchlistController.getInstance().Init();
            WatchlistObserver nObserver = new WatchlistObserver( this.watchlistOLV );
            WatchlistController.getInstance().Subscribe( nObserver );
            this.ActiveControl = this.tickTxtbox;
        }

        private void StockQuery( StockProfile aStock, Boolean Editable = false, Boolean Save = false )
        {
            String nYahooQueryStr = YahooFinanceParser.QUERY_STR;
            String nYahooSymbol = aStock.Sym;
            String nMorningSymbol = aStock.Sym;

            if ( aStock.Market == Enums.Market.SG )
            {
                nYahooSymbol = nYahooSymbol + ".SI";
                nMorningSymbol = "XSES:" + nMorningSymbol;
            }

            nYahooQueryStr = nYahooQueryStr.Replace( "@TICK", nYahooSymbol );

            String nYahooCsvStr = RESTController.GetREST( nYahooQueryStr );
            YahooFinanceParser nYahooParser = new YahooFinanceParser( aStock );
            if ( !nYahooParser.StartCSV( nYahooCsvStr ) )
                return;

            nYahooQueryStr = YahooFinanceParser.PROFILE_STR;
            nYahooQueryStr = nYahooQueryStr.Replace( "@TICK", nYahooSymbol );

            String nYahooHtmlStr = RESTController.GetREST( nYahooQueryStr );
            if ( !nYahooParser.StartHTML( nYahooHtmlStr ) )
                return;

            String nMorningQueryStr = MorningStarParser.QUERY_STR;
            nMorningQueryStr = nMorningQueryStr.Replace( "@TICK", nMorningSymbol );
            String nMorningOutStr = RESTController.GetREST( nMorningQueryStr );
            MorningStarParser nMorningParser = new MorningStarParser( aStock );
            if ( !nMorningParser.StartCSV( nMorningOutStr ) )
                return;

            aStock.LastUpdate = DateTime.Now;

            if ( Editable )
            {
                StockProfilingForm nForm = new StockProfilingForm( aStock );
                nForm.Show();
            }

            if ( Save )
            {
                WatchlistController.getInstance().Add( aStock );
            }
        }

        private void StockDownload(ref StockData aStockData)
        {
            String nYahooDownloadStr = "";

            String nDatafile = aStockData.Sym + "-" + aStockData.Market.ToString() + ".bin";

            Boolean nExists = false;

            if ( !Directory.Exists( @"data" ) )
                Directory.CreateDirectory( @"data" );

            if ( !File.Exists( @"data/" + nDatafile ) )
            {
                nYahooDownloadStr = YahooFinanceDownloader.QUERY_FULL_STR; 
            }
            else
            {
                aStockData = Serializer.GetObjectFromFile<StockData>( @"data/" + nDatafile );

                nYahooDownloadStr = YahooFinanceDownloader.QUERY_PARTIAL_STR;

                if ( aStockData.LastDate.Date == DateTime.Now.Date )
                {
                    return; // No need update again
                }

                DateTime nStartDate = aStockData.LastDate;//.AddDays( 1 );
                nYahooDownloadStr = nYahooDownloadStr.Replace( "@SD", nStartDate.Day.ToString() );
                nYahooDownloadStr = nYahooDownloadStr.Replace( "@SM", (nStartDate.Month-1).ToString() );
                nYahooDownloadStr = nYahooDownloadStr.Replace( "@SY", nStartDate.Year.ToString() );
            }

            nYahooDownloadStr = nYahooDownloadStr.Replace( "@ED", (DateTime.Now.Day).ToString() );
            //nYahooDownloadStr = nYahooDownloadStr.Replace( "@ED", "2" );
            nYahooDownloadStr = nYahooDownloadStr.Replace( "@EM", (DateTime.Now.Month-1).ToString() );
            nYahooDownloadStr = nYahooDownloadStr.Replace( "@EY", DateTime.Now.Year.ToString() );

            String nYahooSymbol = aStockData.Sym;
            if ( aStockData.Market == Enums.Market.SG )
            {
                nYahooSymbol = nYahooSymbol + ".SI";
            }

            nYahooDownloadStr = nYahooDownloadStr.Replace( "@TICK", nYahooSymbol );

            String nYahooOutStr = RESTController.GetREST( nYahooDownloadStr );
            YahooFinanceDownloader nDownloader = new YahooFinanceDownloader( aStockData );
            nDownloader.StartCSV( nYahooOutStr );

            Serializer.SaveObjectToFile<StockData>( aStockData, @"data/" + nDatafile );
        }

        private void New()
        {
            WatchlistController.getInstance().Clear();
            this.Filename = "";
        }

        private bool SaveFile( bool aSaveAs = false )
        {
            try
            {
                if ( this.watchlistOLV.Items.Count <= 0 )
                {
                    MessageBox.Show( "Nothing to save!" );
                    return false;
                }

                if ( String.IsNullOrEmpty( this.Filename ) || aSaveAs )
                {
                    DialogResult nResult = this.saveFileDialog.ShowDialog();
                    if ( nResult == DialogResult.OK )
                    {
                        this.Filename = this.saveFileDialog.FileName;
                    }
                    else
                    {
                        return false;
                    }
                }

                Serializer.SaveListToFile<StockProfile>( WatchlistController.getInstance().GetModel().GetList(), this.Filename );

                return true;
            }
            catch ( IOException )
            {
                return false;
            }
        }

        private bool OpenFile( String aFilename = "" )
        {
            try
            {
                if ( String.IsNullOrEmpty( aFilename ) )
                {
                    DialogResult nResult = this.openFileDialog.ShowDialog();
                    if ( nResult == DialogResult.OK )
                    {
                        WatchlistController.getInstance().Clear();
                        WatchlistController.getInstance().Add( Serializer.GetListFromFile<StockProfile>( openFileDialog.FileName ) );
                        this.Filename = openFileDialog.FileName;
                        return true;
                    }
                }
                return false;
            }
            catch ( IOException )
            {
                return false;
            }
        }

        #region Properties
        private String Filename
        {
            get; set;
        }
        #endregion

        #region Delegates
        delegate void UpdateTitleDelegate( String aText );

        private void UpdateTitleSafe( String aText )
        {
            this.Text = aText;
        }

        public void UpdateTitle( String aText )
        {
            UpdateTitleDelegate updateTextDelegate = new UpdateTitleDelegate( UpdateTitleSafe );
            this.Invoke( updateTextDelegate, new object[] { aText } );
        }
        #endregion

        private void tickTxtbox_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( e.KeyChar == Convert.ToChar( Keys.Return ) )
            {
                Enums.Market nMkt = Enums.Market.US;

                if ( this.sgRadioButton.Checked )
                    nMkt = Enums.Market.SG;

                if ( WatchlistController.getInstance().isExist( this.tickTxtbox.Text ) )
                {
                    this.StockQuery( WatchlistController.getInstance().GetStock( this.tickTxtbox.Text ), true );
                }
                else
                {
                    StockProfile nStock = new StockProfile( this.tickTxtbox.Text );
                    nStock.Market = nMkt;
                    this.StockQuery( nStock, true );
                }
            }
        }

        private void watchlistOLV_DoubleClick( object sender, EventArgs e )
        {
            if ( watchlistOLV.SelectedItems.Count == 1 )
            {
                StockProfile nStock = (StockProfile) watchlistOLV.SelectedObject;
                if ( nStock.LastUpdate.Date == DateTime.Now.Date )
                {
                    StockProfilingForm nForm = new StockProfilingForm( nStock );
                    nForm.Show();
                }
                else
                    this.StockQuery( nStock, true );
            }
        }

        private void newButton_Click( object sender, EventArgs e )
        {
            this.New();
        }

        private void openButton_Click( object sender, EventArgs e )
        {
            this.OpenFile();
        }

        private void saveButton_Click( object sender, EventArgs e )
        {
            this.SaveFile();
        }

        private void updateButton_Click( object sender, EventArgs e )
        {
            if ( WatchlistController.getInstance().GetModel().Size() > 0 )
            {
                updateWorker.RunWorkerAsync( WatchlistController.getInstance().GetModel().GetList() );
            }
        }

        private void trashButton_Click( object sender, EventArgs e )
        {
            if ( watchlistOLV.SelectedItems.Count > 0 )
            {
                WatchlistController.getInstance().Delete( (ArrayList) watchlistOLV.SelectedObjects );
            }
        }

        private void chartButton_Click( object sender, EventArgs e )
        {
            //MessageBox.Show( "Chart Not Available for this version!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            if ( watchlistOLV.SelectedItems.Count == 1 )
            {
                StockProfile nStock = (StockProfile)watchlistOLV.SelectedObject;
                StockData nStockData = new StockData();
                nStockData.Name = nStock.Name;
                nStockData.Sym = nStock.Sym;
                nStockData.Mkt = nStock.Mkt;
                nStockData.Market = nStock.Market;
                this.StockDownload( ref nStockData );

                if ( nStockData.DataPoints.Count > 0 )
                {
                    ChartingForm nForm = new ChartingForm( nStockData );
                    nForm.Show();
                }
            }
        }

        private void infoButton_Click( object sender, EventArgs e )
        {
            InfoForm nForm = new InfoForm();
            nForm.ShowDialog();
        }

        private void updateWorker_DoWork( object sender, DoWorkEventArgs e )
        {
            List<StockProfile> nStocks = (List<StockProfile>) e.Argument;
            this.UpdateTitle( String.Format( "Value Investing - Update {0}/{1}", 0, nStocks.Count ));

            int i = 0;
            foreach ( StockProfile nStock in nStocks )
            {
                if ( nStock.LastUpdate.Date != DateTime.Now.Date )
                    this.StockQuery( nStock );
                this.updateWorker.ReportProgress( ++i, nStock );
            }
        }

        private void updateWorker_ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
            this.watchlistOLV.RefreshObject( e.UserState );
            this.UpdateTitle(String.Format( "Value Investing - Update {0}/{1}", e.ProgressPercentage, this.watchlistOLV.GetItemCount() ));
        }

        private void updateWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            //this.watchlistOLV.Invalidate();
            this.UpdateTitle( String.Format( "Value Investing"));
            MessageBox.Show( "Update Completed!", "Value Investing Info", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }
    }
}
