using HtmlAgilityPack;
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
using ValueInvesting.Parsers;
using ValueInvesting.Views;

namespace ValueInvesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click( object sender, EventArgs e )
        {
            StockProfile nStock = new StockProfile( textBox1.Text );
            String nYahooQueryStr = YahooFinanceParser.QUERY_STR;
            nYahooQueryStr = nYahooQueryStr.Replace( "@TICK", textBox1.Text );

            String nYahooCsvStr = RESTController.GetREST( nYahooQueryStr );
            YahooFinanceParser nYahooParser = new YahooFinanceParser( nStock );
            if ( !nYahooParser.StartCSV( nYahooCsvStr ) )
                return;

            nYahooQueryStr = YahooFinanceParser.PROFILE_STR;
            nYahooQueryStr = nYahooQueryStr.Replace( "@TICK", textBox1.Text );

            String nYahooHtmlStr = RESTController.GetREST( nYahooQueryStr );
            if ( !nYahooParser.StartHTML( nYahooHtmlStr ) )
                return;

            String nMorningQueryStr = MorningStarParser.QUERY_STR;
            nMorningQueryStr = nMorningQueryStr.Replace( "@TICK", textBox1.Text );
            String nMorningOutStr = RESTController.GetREST( nMorningQueryStr );
            MorningStarParser nMorningParser = new MorningStarParser( nStock );
            if ( !nMorningParser.StartCSV( nMorningOutStr ) )
                return;

            

            
            textBox2.AppendText( "Name - " + nStock.Name + "\n" );
            textBox2.AppendText( "Price - $" + nStock.Last + "\n" );
            textBox2.AppendText( "Summary - " + nStock.Summary + "\n" );

            textBox2.AppendText( "\n" );

            textBox2.AppendText( "ENTRY PRICE \n" );
            textBox2.AppendText( "Growth Entry Price - $" + nStock.GEP + "\n" );
            textBox2.AppendText( "Dividend Entry Price - $" + nStock.DEP + "\n" );
            textBox2.AppendText( "Asset Play Entry Price - $" + nStock.AEP + "\n" );

            textBox2.AppendText( "\n" );

            //textBox2.AppendText( "Dividend - $" + nStock.Dividend + "\n" );
            //textBox2.AppendText( "Yield - " + nStock.DivYield + "%\n" );
            //textBox2.AppendText( "P/B - " + nStock.BookValue + "\n" );
            //textBox2.AppendText( "EPS - " + nStock.EPS + "\n" );
            //textBox2.AppendText( "PE Ratio - " + nStock.PERatio + "\n" );

            textBox2.AppendText( "PIEC\n" );
            // PIEC
            textBox2.AppendText( "Profitability - " + nStock.Profitability + "\n" );
            textBox2.AppendText( "Inflow Cash - " + nStock.InFlowCash + "\n" );
            textBox2.AppendText( "Effiency > " + Params.ROE_THRESHOLD + " - " + nStock.Efficiency + "\n" );
            textBox2.AppendText( "Conservative < " + Params.DOE_THRESHOLD + " - " + nStock.Conservative + "\n" );
            //    textBox2.AppendText( "Upcoming EPS - " + nStock.NextEPS + "\n" );

            //    if ( nStock.ComputeAssetPrice() )
            //        textBox2.AppendText( "Asset Entry Price - " + nStock.AEP + "\n" );
            //}

            StockProfilingForm nForm = new StockProfilingForm( nStock );
            nForm.Show();
        }
    }
}
