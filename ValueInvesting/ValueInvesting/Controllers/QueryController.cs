using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Commons;
using ValueInvesting.Models;
using ValueInvesting.Parsers;
using ValueInvesting.Utils;

namespace ValueInvesting.Controllers
{
    public class QueryController
    {
        private const String API_KEY = "c04dc410317711e69eba39bd4aca75eb";

        public async Task<bool> QueryStock( StockProfile aStock )
        {
            if ( !QueryYahooFinance( ref aStock ) )
                return false;

            if ( !QueryYahooFinanceProfile( ref aStock ) )
                return false;

            if ( !QueryMorningStar( ref aStock ) )
                return false;

            //if ( aStock.Market == Enums.Market.US)
                await QueryJitta( aStock );

            aStock.LastUpdate = DateTime.Now;

            return true;
        }

        public bool QueryStockData( ref StockData aStockData )
        {
            if ( !Directory.Exists( @"data" ) )
                Directory.CreateDirectory( @"data" );

            String nDatafile = @"data/" + aStockData.Sym + "-" + aStockData.Market.ToString() + ".bin";

            if ( !File.Exists(  nDatafile ) )
            {
                if ( !QueryYahooDataFull( ref aStockData ) )
                    return false;
            }
            else
            {
                aStockData = Serializer.GetObjectFromFile<StockData>( nDatafile );

                if ( aStockData.LastDate.Date == DateTime.Now.Date )
                    return true; // No need update again

                if ( !QueryYahooDataPartial( ref aStockData ) )
                    return false;
            }

            Serializer.SaveObjectToFile<StockData>( aStockData, nDatafile );
            return true;
        }

        private bool QueryYahooFinance( ref StockProfile aStock )
        {
            String nYahooQueryStr = YahooFinanceParser.QUERY_STR;

            nYahooQueryStr = nYahooQueryStr.Replace( "@TICK", getYahooSymbol( aStock, aStock.Sym ) );

            String nYahooCsvStr = RESTController.GetREST( nYahooQueryStr );

            YahooFinanceParser nYahooParser = new YahooFinanceParser( aStock );
            if ( nYahooParser.StartCSV( nYahooCsvStr ) )
                return true;

            return false;
        }

        private bool QueryYahooFinanceProfile( ref StockProfile aStock )
        {
            String nYahooQueryStr = YahooFinanceParser.PROFILE_STR;

            nYahooQueryStr = nYahooQueryStr.Replace( "@TICK", getYahooSymbol( aStock, aStock.Sym ) );

            String nYahooHtmlStr = RESTController.GetREST( nYahooQueryStr );
            YahooFinanceParser nYahooParser = new YahooFinanceParser( aStock );

            if ( nYahooParser.StartHTML( nYahooHtmlStr ) )
                return true;

            return false;
        }

        private bool QueryMorningStar( ref StockProfile aStock )
        {
            String nMorningQueryStr = MorningStarParser.QUERY_STR;

            nMorningQueryStr = nMorningQueryStr.Replace( "@TICK", getMorningStarSymbol( aStock, aStock.Sym ) );

            String nMorningOutStr = RESTController.GetREST( nMorningQueryStr );
            MorningStarParser nMorningParser = new MorningStarParser( aStock );

            if ( nMorningParser.StartCSV( nMorningOutStr ) )
                return true;

            return false;
        }

        private async Task<bool> QueryJitta( StockProfile aStock )
        {
            String nJittaQueryStr = JittaParser.QUERY_STR;

            nJittaQueryStr = nJittaQueryStr.Replace( "@TICK", aStock.Sym ).Replace( "@MKT", aStock.Mkt );

            String nJittaOutStr = await HTTPController.GetREQUEST( nJittaQueryStr, API_KEY );
            JittaParser nJittaParser = new JittaParser( aStock );

            if ( nJittaParser.StartJson( nJittaOutStr ) )
                return true;

            return false;
        }

        private bool QueryYahooDataFull( ref StockData aStockData )
        {
            String nYahooDownloadStr = YahooFinanceDownloader.QUERY_FULL_STR;

            nYahooDownloadStr = nYahooDownloadStr.Replace( "@ED", ( DateTime.Now.Day ).ToString() );
            nYahooDownloadStr = nYahooDownloadStr.Replace( "@EM", ( DateTime.Now.Month - 1 ).ToString() );
            nYahooDownloadStr = nYahooDownloadStr.Replace( "@EY", DateTime.Now.Year.ToString() );
            nYahooDownloadStr = nYahooDownloadStr.Replace( "@TICK", getYahooSymbol(aStockData, aStockData.Sym) );

            String nYahooOutStr = RESTController.GetREST( nYahooDownloadStr );
            YahooFinanceDownloader nDownloader = new YahooFinanceDownloader( aStockData );

            if ( nDownloader.StartCSV( nYahooOutStr ) )
                return true;

            return false;
        }

        private bool QueryYahooDataPartial(ref StockData aStockData )
        {
            String nYahooDownloadStr = YahooFinanceDownloader.QUERY_PARTIAL_STR;

            nYahooDownloadStr = nYahooDownloadStr.Replace( "@SD", aStockData.LastDate.Day.ToString() );
            nYahooDownloadStr = nYahooDownloadStr.Replace( "@SM", ( aStockData.LastDate.Month - 1 ).ToString() );
            nYahooDownloadStr = nYahooDownloadStr.Replace( "@SY", aStockData.LastDate.Year.ToString() );
            nYahooDownloadStr = nYahooDownloadStr.Replace( "@ED", ( DateTime.Now.Day ).ToString() );
            nYahooDownloadStr = nYahooDownloadStr.Replace( "@EM", ( DateTime.Now.Month - 1 ).ToString() );
            nYahooDownloadStr = nYahooDownloadStr.Replace( "@EY", DateTime.Now.Year.ToString() );
            nYahooDownloadStr = nYahooDownloadStr.Replace( "@TICK", getYahooSymbol( aStockData, aStockData.Sym ) );

            String nYahooOutStr = RESTController.GetREST( nYahooDownloadStr );
            YahooFinanceDownloader nDownloader = new YahooFinanceDownloader( aStockData );

            if ( nDownloader.StartCSV( nYahooOutStr ) )
                return true;

            return false;
        }

        private String getYahooSymbol( Stock aStock, String aYahooSymbol )
        {
            if ( aStock.Market == Enums.Market.SG )
            {
                aYahooSymbol = aYahooSymbol + ".SI";
            }
            return aYahooSymbol;
        }

        private String getMorningStarSymbol( Stock aStock, String aMorningSymbol )
        {
            if ( aStock.Market == Enums.Market.SG )
            {
                aMorningSymbol = "XSES:" + aMorningSymbol;
            }
            return aMorningSymbol;
        }
    }
}
