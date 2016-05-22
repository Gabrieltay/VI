using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Base
{
    public abstract class Observer : Base
    {
        abstract public void update( Action aAction, object aSubject );
    }
}
