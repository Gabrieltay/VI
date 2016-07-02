using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightIdeasSoftware;
using ValueInvesting.Models;
using System.Drawing;

namespace ValueInvesting.Renderers
{
    public class StrengthRenderer : BaseRenderer
    {
        public override void Render( System.Drawing.Graphics g, System.Drawing.Rectangle r )
        {
            base.Render( g, r );

            Font nStrengthfont = new System.Drawing.Font( this.Font.Name, this.Font.Size, System.Drawing.FontStyle.Bold );
            StockProfile nStock = (StockProfile)this.RowObject;
            if ( nStock.LongStrength > nStock.ShortStrength )
                g.DrawString( this.GetText(), nStrengthfont, System.Drawing.Brushes.Blue, r.Left+20, r.Bottom, this.StringFormatForGdiPlus );
            else
                g.DrawString( this.GetText(), nStrengthfont, System.Drawing.Brushes.Red, r, this.StringFormatForGdiPlus );

        }
    }
    
}
