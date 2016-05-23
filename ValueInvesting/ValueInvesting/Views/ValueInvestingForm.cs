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

        private void StockQuery(Stock aStock, Enums.Market aMkt = Enums.Market.US)
        {
            String nYahooQueryStr = YahooFinanceParser.QUERY_STR;
            String nYahooSymbol = aStock.Sym;
            String nMorningSymbol = aStock.Sym;

            if ( aMkt == Enums.Market.SG )
            {
                nYahooSymbol = nYahooSymbol + ".SI";
                nMorningSymbol = "XSES:" +  nMorningSymbol;
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

            StockProfilingForm nForm = new StockProfilingForm( aStock );
            nForm.Show();
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

                Serializer.SaveListToFile<Stock>( WatchlistController.getInstance().GetModel().GetList(),this.Filename );

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
                        WatchlistController.getInstance().Add( Serializer.GetListFromFile<Stock>( openFileDialog.FileName ));
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

        private void tickTxtbox_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( e.KeyChar == Convert.ToChar( Keys.Return ) )
            {
                Enums.Market nMkt = Enums.Market.US;

                if ( this.sgRadioButton.Checked )
                    nMkt = Enums.Market.SG;

                if ( WatchlistController.getInstance().isExist( this.tickTxtbox.Text ) )
                {
                    this.StockQuery( WatchlistController.getInstance().GetStock( this.tickTxtbox.Text ), nMkt );
                }
                else
                {
                    this.StockQuery( new Stock( this.tickTxtbox.Text ), nMkt );
                }
            }
        }

        private void watchlistOLV_DoubleClick( object sender, EventArgs e )
        {
            if ( watchlistOLV.SelectedItems.Count == 1 )
            {
                Stock nStock = (Stock) watchlistOLV.SelectedObject;
                this.StockQuery( nStock, Translator.MarketStringToEnum(nStock.Mkt) );
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

        }

        private void trashButton_Click( object sender, EventArgs e )
        {

        }

        private void chartButton_Click( object sender, EventArgs e )
        {

        }

        private void infoButton_Click( object sender, EventArgs e )
        {

        }
    }
}
