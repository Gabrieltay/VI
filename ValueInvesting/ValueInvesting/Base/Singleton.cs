using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Base
{
    public abstract class Singleton<T>
        where T : Singleton<T>, new()
    {
        private static T msInstance;

        public static T getInstance()
        {
            if ( msInstance == null )
            {
                msInstance = new T();
            }
            return msInstance;
        }
    }
}
