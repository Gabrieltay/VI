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

        private void StockQuery( Stock aStock, Boolean Editable = false, Boolean Save = false )
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

                Serializer.SaveListToFile<Stock>( WatchlistController.getInstance().GetModel().GetList(), this.Filename );

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
                        WatchlistController.getInstance().Add( Serializer.GetListFromFile<Stock>( openFileDialog.FileName ) );
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
                    Stock nStock = new Stock( this.tickTxtbox.Text );
                    nStock.Market = nMkt;
                    this.StockQuery( nStock, true );
                }
            }
        }

        private void watchlistOLV_DoubleClick( object sender, EventArgs e )
        {
            if ( watchlistOLV.SelectedItems.Count == 1 )
            {
                Stock nStock = (Stock) watchlistOLV.SelectedObject;
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
            MessageBox.Show( "Chart Not Available for this version!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
        }

        private void infoButton_Click( object sender, EventArgs e )
        {
            InfoForm nForm = new InfoForm();
            nForm.ShowDialog();
        }

        private void updateWorker_DoWork( object sender, DoWorkEventArgs e )
        {
            List<Stock> nStocks = (List<Stock>) e.Argument;
            this.UpdateTitle( String.Format( "Value Investing - Update {0}/{1}", 0, nStocks.Count ));

            int i = 0;
            foreach ( Stock nStock in nStocks )
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
