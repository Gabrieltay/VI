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

        private void StockQuery(Stock aStock)
        {
            String nYahooQueryStr = YahooFinanceParser.QUERY_STR;
            String nYahooSymbol = aStock.Sym;
            String nMorningSymbol = aStock.Sym;

            if ( this.sgRadioButton.Checked )
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

        private void tickTxtbox_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( e.KeyChar == Convert.ToChar( Keys.Return ) )
            {
                if ( WatchlistController.getInstance().isExist( this.tickTxtbox.Text ) )
                {
                    this.StockQuery( WatchlistController.getInstance().GetStock( this.tickTxtbox.Text ) );
                }
                else
                {
                    this.StockQuery( new Stock( this.tickTxtbox.Text ) );
                }
            }
        }

        private void watchlistOLV_DoubleClick( object sender, EventArgs e )
        {
            if ( watchlistOLV.SelectedItems.Count == 1 )
            {
                this.StockQuery( (Stock)watchlistOLV.SelectedObject );
            }
        }
    }
}
