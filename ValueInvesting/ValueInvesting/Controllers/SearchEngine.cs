using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Base;
using ValueInvesting.Commons;
using ValueInvesting.Models;
using ValueInvesting.Parsers;

namespace ValueInvesting.Controllers
{
    public class SearchEngine : Singleton<SearchEngine>
    {
        private const int MAX_RESULTS = 10;

        public void init()
        {
            this.Stocks = new List<Stock>();
            StartParse( @"Stocks/NASDAQ.txt", "NASDAQ", Enums.Market.US );
            StartParse( @"Stocks/NYSE.txt", "NYSE", Enums.Market.US );
            StartParse( @"Stocks/SGX.txt", "SGX", Enums.Market.SG);
        }

        private void StartParse( String aFilename,  String aMkt, Enums.Market aMarket)
        {
            foreach ( String nLine in File.ReadLines( aFilename ) )
            {
                if ( !nLine.Contains("Symbol") && !nLine.Contains( "Description" ) )
                {
                    Stock nStock = new Stock();
                    nStock.Market = aMarket;
                    nStock.Mkt = aMkt;
                    EodDataSymbolsParser nParser = new EodDataSymbolsParser( nStock );
                    nParser.StartTXT( nLine );
                    this.Stocks.Add( nStock );
                }
            }
        }

        public List<Stock> Search(String aSearchStr)
        {
            List<Stock> nResult = new List<Stock>();

            foreach ( Stock nStock in this.Stocks)
            {
                if ( nStock.Name.ToLower().Contains(aSearchStr.ToLower()) || nStock.Sym.ToLower().Contains(aSearchStr.ToLower() ))
                {
                    nResult.Add( nStock );
                }

                if ( nResult.Count == MAX_RESULTS )
                    break;
            }
            return nResult;
        }


        public List<Stock> Stocks
        {
            get; set;
        }
    }
}
