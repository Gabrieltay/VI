using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Controllers
{
    public class RESTController
    {
        public static String GetREST(String aQueryStr)
        {
            String nData;

            using (WebClient web = new WebClient())
            {
                nData = web.DownloadString(aQueryStr);
            }

            return nData;
        }

    }
}
