using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ValueInvesting.Base
{
    public abstract class Threader
    {
        public void Start()
        {
            Thread thread = new Thread( this.ThreadProcFunc );
            thread.Start();
        }

        public abstract void ThreadProcFunc();
    }
}
