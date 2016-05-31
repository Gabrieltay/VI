using SmartConf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Base;
using ValueInvesting.Commons;

namespace ValueInvesting.Controllers
{
    public class ConfigManager : Singleton<ConfigManager>
    {

        public void init( String aFilename )
        {
            mCfg = new ConfigurationManager<Config>( aFilename );
        }

        public String read(String aKey)
        {
            mCfg.Out.
        }

        private ConfigurationManager<Config> mCfg
        {
            get; set;
        }
    }
}
