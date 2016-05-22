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
using ValueInvesting.Controllers;

namespace ValueInvesting.Views
{
    public partial class StockProfilingForm : Form
    {
        public StockProfilingForm(Stock aStock)
        {
            this.mStock = aStock;
            InitializeComponent();
            this.populateValues();
        }

        private void populateValues()
        {
            this.stockNameLabel.Text = this.mStock.Name;
            this.symLabel.Text = this.mStock.Sym + " - " + this.mStock.Mkt;
            this.bizConLabel.Text = this.mStock.BizConf.ToString();
            this.sumTxtbox.Text = this.mStock.Summary;

            if ( this.mStock.Last < 1.0 )
                this.priceLabel.Text = String.Format( "{0:C3}", this.mStock.Last );
            else
                this.priceLabel.Text = String.Format( "{0:C2}", this.mStock.Last );

            if ( this.mStock.GEP < 1.0 )
                this.GepLabel.Text = String.Format( "{0:C3}", this.mStock.GEP );
            else
                this.GepLabel.Text = String.Format( "{0:C2}", this.mStock.GEP );

            if ( this.mStock.DEP < 1.0 )
                this.DepLabel.Text = String.Format( "{0:C3}", this.mStock.DEP );
            else
                this.DepLabel.Text = String.Format( "{0:C2}", this.mStock.DEP );

            if ( this.mStock.AEP < 1.0 )
                this.AepLabel.Text = String.Format( "{0:C3}", this.mStock.AEP );
            else
                this.AepLabel.Text = String.Format( "{0:C2}", this.mStock.AEP );

            this.moatCombobox.Text = (String)this.moatCombobox.Items[4-this.mStock.Moat];
            this.regComboBox.Text = this.mStock.Regulatory ? "HIGH" : "LOW";
            this.infComboBox.Text = this.mStock.Inflation ? "HIGH" : "LOW";
            this.sciComboBox.Text = this.mStock.ScienceTech ? "HIGH" : "LOW";
            this.keyComboBox.Text = this.mStock.KeyPeople ? "HIGH" : "LOW";
        }

        private void calculateBizConf()
        {
            double nBizConf = 0.0;
            nBizConf += this.mStock.Moat;
            nBizConf += this.mStock.Regulatory ? 0.0 : 0.5;
            nBizConf += this.mStock.Inflation ? 0.0 : 0.5;
            nBizConf += this.mStock.ScienceTech ? 0.0 : 0.5;
            nBizConf += this.mStock.KeyPeople ? 0.0 : 0.5;
            nBizConf += this.mStock.Profitability ? 1.0 : 0.0;
            nBizConf += this.mStock.InFlowCash ? 1.0 : 0.0;
            nBizConf += this.mStock.Efficiency ? 1.0 : 0.0;
            nBizConf += this.mStock.Conservative ? 1.0 : 0.0;
            this.mStock.BizConf = nBizConf;
            this.bizConLabel.Text = nBizConf.ToString();
        }

        private Stock mStock
        {
            get; set;
        }

        private void moatCombobox_SelectedIndexChanged( object sender, EventArgs e )
        {
            this.mStock.Moat = 4 - this.moatCombobox.SelectedIndex;
            this.calculateBizConf();
        }

        private void regComboBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            this.mStock.Regulatory = this.regComboBox.Text == "HIGH" ? true : false;
            this.calculateBizConf();
        }

        private void infComboBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            this.mStock.Inflation = this.infComboBox.Text == "HIGH" ? true : false;
            this.calculateBizConf();
        }

        private void sciComboBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            this.mStock.ScienceTech = this.sciComboBox.Text == "HIGH" ? true : false;
            this.calculateBizConf();
        }

        private void keyComboBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            this.mStock.KeyPeople = this.keyComboBox.Text == "HIGH" ? true : false;
            this.calculateBizConf();
        }

        private void GepLabel_MouseHover( object sender, EventArgs e )
        {
            String nDisplay = String.Format( "PE Ratio - {0:0.0#}\nPE/G - {1:0.0#}", this.mStock.PERatio, this.mStock.PEG );
            this.infoTooltip.Show( nDisplay, this.GepLabel );
        }

        private void GepLabel_MouseLeave( object sender, EventArgs e )
        {
            this.infoTooltip.Hide( this.GepLabel ); 
        }

        private void DepLabel_MouseHover( object sender, EventArgs e )
        {
            String nDisplay = String.Format( "Dividend - {0:C2}\nDividend Yield - {1:P2}", this.mStock.Dividend, this.mStock.DivYield );
            this.infoTooltip.Show( nDisplay, this.DepLabel );
        }

        private void DepLabel_MouseLeave( object sender, EventArgs e )
        {
            this.infoTooltip.Hide( this.DepLabel );
        }

        private void AepLabel_MouseHover( object sender, EventArgs e )
        {
            String nDisplay = String.Format( "Price/Book Value - {0:0.0#}",  this.mStock.Last / this.mStock.BookValue );
            this.infoTooltip.Show( nDisplay, this.AepLabel );
        }

        private void AepLabel_MouseLeave( object sender, EventArgs e )
        {
            this.infoTooltip.Hide( this.AepLabel );
        }

        private void addButton_Click( object sender, EventArgs e )
        {
            WatchlistController.getInstance().Add( this.mStock );
        }

        private void bizConLabel_MouseHover( object sender, EventArgs e )
        {
            String nDisplay = String.Format( "Profitability - {0}\nCashflow - {1}\nReturn On Equity - {2:0.0#}\nDebt to Equity - {3:0.0#}", 
                this.mStock.Profitability? "True":"False",
                this.mStock.InFlowCash ? "True" : "False",
                this.mStock.ROE, this.mStock.DOE);
            this.infoTooltip.Show( nDisplay, this.bizConLabel );
        }

        private void bizConLabel_MouseLeave( object sender, EventArgs e )
        {
            this.infoTooltip.Hide( this.bizConLabel );
        }
    }
}
