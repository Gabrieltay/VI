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
            mCfgMgr = new ConfigurationManager<Config>( aFilename );
            this.Config = this.mCfgMgr.Out;
        }

        public void Save()
        {
            this.mCfgMgr.SaveChanges();
        }

        private ConfigurationManager<Config> mCfgMgr
        {
            get; set;
        }

        public Config Config
        {
            get; set;
        }
    }
}
