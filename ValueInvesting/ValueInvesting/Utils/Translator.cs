using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Commons;

namespace ValueInvesting.Utils
{
    public static class Translator
    {
        public static String MarketCodeToString( String aCode )
        {
            if ( aCode == "NMS" )
                return "NASDAQ";
            else if ( aCode == "NYQ" )
                return "NYSE";
            else if ( aCode == "ASE" || aCode == "PCX" )
                return "AMEX";
            else if ( aCode == "SES" )
                return "SGX";
            return aCode;
        }

        public static Enums.Market MarketStringToEnum( String aStr )
        {
            if ( aStr == "SGX" )
                return Enums.Market.SG;
            else
                return Enums.Market.US;             
        }
    }
}
