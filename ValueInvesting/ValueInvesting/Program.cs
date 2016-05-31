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
        static void ManageMyConfigFile( Config config )
        {
            Console.WriteLine( config );
            Console.WriteLine(
                "I'll track changes even in methods/classes that don't know about " +
                "the ConfigurationManager, as long as the instance stays the same." );
            Console.WriteLine( "Changing age to 20." );
            config.Age = 20;
            config.Name = "Gabri222el";
            Console.WriteLine( config );
        }

        static void PrintChangedProperties( ConfigurationManager<Config> conf )
        {
            var props = conf.GetPropertyChangesByName();
            if ( props.Any() )
            {
                Console.WriteLine( "Changed Properties:" );
                foreach ( var prop in props )
                {
                    Console.WriteLine( "  {0}: {1}", prop.Key, prop.Value );
                }
            }
            else
            {
                Console.WriteLine( "No changed properties." );
            }
            Console.WriteLine();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new ConfigurationManager<Config>("Settings.xml");
            PrintChangedProperties( config );
            ManageMyConfigFile( config.Out );
            PrintChangedProperties( config );
            config.SaveChanges();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run( new ValueInvestingForm() );
            //Application.Run(new Form1());
        }
    }
}
