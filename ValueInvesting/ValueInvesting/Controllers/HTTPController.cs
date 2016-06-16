using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Controllers
{
    public class HTTPController
    {

        public static async Task<string> GetREQUEST( String aQueryStr, String aKeyStr )
        {
            String nData;

            var baseAddress = new Uri( aQueryStr );
            using ( var httpClient = new HttpClient() )
            {
                var byteArray = Encoding.ASCII.GetBytes( aKeyStr );
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue( "Basic", Convert.ToBase64String( byteArray ) );
                using ( var response = await httpClient.GetAsync( aQueryStr ) )
                {
                    nData = await response.Content.ReadAsStringAsync();
                }
            }
            return nData;
        }

    }
}
