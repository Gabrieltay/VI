using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Base
{
    public class Base
    {
        public enum Action
        {
            INSERT_OBJECT,
            INSERT_OBJECTS,
            UPDATE_OBJECT,
            UPDATE_OBJECTS,
            DELETE_OBJECT,
            DELETE_OBJECTS,
            CLEAR_OBJECTS,
            NULL
        }
    }
}
