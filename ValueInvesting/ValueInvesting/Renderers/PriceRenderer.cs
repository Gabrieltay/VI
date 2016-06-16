using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightIdeasSoftware;
using ValueInvesting.Models;

namespace ValueInvesting.Renderers
{
    public class GrowthPriceRenderer : BaseRenderer
    {
        public override void Render( System.Drawing.Graphics g, System.Drawing.Rectangle r )
        {
            base.Render( g, r );
            StockProfile nStock = (StockProfile) this.RowObject;
            if ( nStock.GEP > nStock.Last )
            {
                g.FillRectangle( System.Drawing.Brushes.LightGreen, r );
                g.DrawString( this.GetText(), this.Font, System.Drawing.Brushes.Black, r, this.StringFormatForGdiPlus );
            }
            
        }
    }

    public class DividendPriceRenderer : BaseRenderer
    {
        public override void Render( System.Drawing.Graphics g, System.Drawing.Rectangle r )
        {
            base.Render( g, r );
            StockProfile nStock = (StockProfile) this.RowObject;
            if ( nStock.DEP > nStock.Last )
            {
                g.FillRectangle( System.Drawing.Brushes.LightGreen, r );
                g.DrawString( this.GetText(), this.Font, System.Drawing.Brushes.Black, r, this.StringFormatForGdiPlus );
            }

        }
    }

    public class AssetPriceRenderer : BaseRenderer
    {
        public override void Render( System.Drawing.Graphics g, System.Drawing.Rectangle r )
        {
            base.Render( g, r );
            StockProfile nStock = (StockProfile) this.RowObject;
            if ( nStock.AEP > nStock.Last )
            {
                g.FillRectangle( System.Drawing.Brushes.LightGreen, r );
                g.DrawString( this.GetText(), this.Font, System.Drawing.Brushes.Black, r, this.StringFormatForGdiPlus );
            }

        }
    }

    public class JittaPriceRenderer : BaseRenderer
    {
        public override void Render( System.Drawing.Graphics g, System.Drawing.Rectangle r )
        {
            base.Render( g, r );
            StockProfile nStock = (StockProfile)this.RowObject;
            if ( nStock.JEP > nStock.Last )
            {
                g.FillRectangle( System.Drawing.Brushes.LightGreen, r );
                g.DrawString( this.GetText(), this.Font, System.Drawing.Brushes.Black, r, this.StringFormatForGdiPlus );
            }

        }
    }
}
