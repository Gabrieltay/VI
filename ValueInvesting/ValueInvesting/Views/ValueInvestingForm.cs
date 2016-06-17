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
using BrightIdeasSoftware;

namespace ValueInvesting.Views
{
    public partial class ValueInvestingForm : Form
    {

        public ValueInvestingForm()
        {
            InitializeComponent();
            InitializeSearchEngine();
            WatchlistController.getInstance().Init();
            WatchlistObserver nObserver = new WatchlistObserver( this.watchlistOLV );
            WatchlistController.getInstance().Subscribe( nObserver );
            this.ActiveControl = this.tickTxtbox;
        }

        private void InitializeSearchEngine()
        {
            DescribedTaskRenderer nRenderer = new BrightIdeasSoftware.DescribedTaskRenderer();
            nRenderer.ImageList = this.CountryImageList;
            nRenderer.DescriptionAspectName = "Name";
            nRenderer.TitleFont = new Font( "Tahoma", 11, FontStyle.Bold );
            nRenderer.DescriptionFont = new Font( "Tahoma", 9 );
            nRenderer.ImageTextSpace = 8;
            nRenderer.TitleDescriptionSpace = 1;
            nRenderer.UseGdiTextRendering = true;
            this.olvStockColumn.Renderer = nRenderer;
            this.olvStockColumn.AspectName = "SymStr";
            this.olvStockColumn.ImageAspectName = "MktStr";
            this.olvStockColumn.CellPadding = new Rectangle( 4, 2, 4, 2 );

            this.SearchOLV.Height = 300;
            this.SearchOLV.AddObjects( SearchEngine.getInstance().Stocks );
            this.SearchOLV.Hide();
        }

        private async void StockQuery( StockProfile aStock, Boolean Editable = false, Boolean Save = false )
        {
            QueryController nController = new QueryController();
            bool nResult = await nController.QueryStock( aStock );

            if ( !nResult )
                return;

            //Temp Testing
            Random nRdm = new Random();
            aStock.ShortStrength = nRdm.Next( 1, 10 );
            aStock.LongStrength = nRdm.Next( 1, 10 );

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

        private void StockDownload( ref StockData aStockData )
        {
            QueryController nController = new QueryController();
            nController.QueryStockData( aStockData );
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

        private void RebuildFilters()
        {

            // Build a composite filter that unify the three possible filtering criteria

            List<IModelFilter> filters = new List<IModelFilter>();

            if ( !String.IsNullOrEmpty( this.tickTxtbox.Text ) )
                filters.Add( new TextMatchFilter( this.SearchOLV, this.tickTxtbox.Text ) );

            // Use AdditionalFilter (instead of ModelFilter) since AdditionalFilter plays well with any
            // extra filtering the user might specify via the column header
            this.SearchOLV.AdditionalFilter = filters.Count == 0 ? null : new CompositeAllFilter( filters );
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
            //if ( e.KeyChar == Convert.ToChar( Keys.Return ) )
            //{
            //    Enums.Market nMkt = Enums.Market.US;

            //    if ( this.sgRadioButton.Checked )
            //        nMkt = Enums.Market.SG;

            //    if ( WatchlistController.getInstance().isExist( this.tickTxtbox.Text ) )
            //    {
            //        this.StockQuery( WatchlistController.getInstance().GetStock( this.tickTxtbox.Text ), true );
            //    }
            //    else
            //    {
            //        StockProfile nStock = new StockProfile( this.tickTxtbox.Text );
            //        nStock.Market = nMkt;
            //        this.StockQuery( nStock, true );
            //    }
            //}
        }

        private void watchlistOLV_DoubleClick( object sender, EventArgs e )
        {
            if ( watchlistOLV.SelectedItems.Count == 1 )
            {
                StockProfile nStock = (StockProfile)watchlistOLV.SelectedObject;
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
                WatchlistController.getInstance().Delete( (ArrayList)watchlistOLV.SelectedObjects );
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
            List<StockProfile> nStocks = (List<StockProfile>)e.Argument;
            this.UpdateTitle( String.Format( "Value Investing - Update {0}/{1}", 0, nStocks.Count ) );

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
            this.UpdateTitle( String.Format( "Value Investing - Update {0}/{1}", e.ProgressPercentage, this.watchlistOLV.GetItemCount() ) );
        }

        private void updateWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            //this.watchlistOLV.Invalidate();
            this.UpdateTitle( String.Format( "Value Investing" ) );
            MessageBox.Show( "Update Completed!", "Value Investing Info", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private void watchlistOLV_MouseClick( object sender, MouseEventArgs e )
        {
            this.SearchOLV.Hide();
        }

        private void ValueInvestingForm_MouseDown( object sender, MouseEventArgs e )
        {
            this.SearchOLV.Hide();
        }

        private void tickTxtbox_TextChanged( object sender, EventArgs e )
        {
            if ( this.tickTxtbox.Text.Length >= 3 )
            {
                this.SearchOLV.Show();
                RebuildFilters();
                //List<Stock> nSearchResults = SearchEngine.getInstance().Search( this.tickTxtbox.Text );
            }
            else
            {
                this.SearchOLV.Hide();
            }
        }

        private void SearchOLV_Click( object sender, EventArgs e )
        {
            if ( this.SearchOLV.SelectedItems.Count == 1 )
            {
                Stock nStockObj = (Stock)this.SearchOLV.SelectedObject;
                this.SearchOLV.Hide();
                if ( WatchlistController.getInstance().isExist( nStockObj.Sym ) )
                {
                    this.StockQuery( WatchlistController.getInstance().GetStock( nStockObj.Sym ), true );
                }
                else
                {
                    StockProfile nStock = new StockProfile( nStockObj.Sym );
                    nStock.Market = nStockObj.Market;
                    this.StockQuery( nStock, true );
                }
            }
        }

        private void tickTxtbox_KeyDown( object sender, KeyEventArgs e )
        {
            if ( this.SearchOLV.Visible )
            {
                if ( e.KeyCode == Keys.Down )
                {
                    this.ActiveControl = this.SearchOLV;
                    this.SearchOLV.SelectedIndex = 0;
                }
            }
        }

        private void SearchOLV_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( e.KeyChar == Convert.ToChar( Keys.Return ) && this.SearchOLV.SelectedItems.Count == 1 )
            {
                Stock nStockObj = (Stock)this.SearchOLV.SelectedObject;
                this.SearchOLV.Hide();
                if ( WatchlistController.getInstance().isExist( nStockObj.Sym ) )
                {
                    this.StockQuery( WatchlistController.getInstance().GetStock( nStockObj.Sym ), true );
                }
                else
                {
                    StockProfile nStock = new StockProfile( nStockObj.Sym );
                    nStock.Market = nStockObj.Market;
                    this.StockQuery( nStock, true );
                }
            }
        }
    }
}
