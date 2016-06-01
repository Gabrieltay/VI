using SmartConf;
using SmartConf.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueInvesting.Commons;
using ValueInvesting.Controllers;
using ValueInvesting.Views;

namespace ValueInvesting
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigManager.getInstance().init( "Settings.xml" );
            SearchEngine.getInstance().init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run( new ValueInvestingForm() );
            //Application.Run(new Form1());
        }
    }
}
