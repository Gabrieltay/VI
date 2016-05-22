using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Utils
{
    public static class Comparer
    {
        public static bool Compare<T>( IList<T> aList_1, IList<T> aList_2 )
        {
            if ( aList_1.Count != aList_2.Count )
                return false;

            Type eleType = typeof( T );
            for ( int index = 0; index < aList_1.Count; index++ )
            {
                foreach ( var propInfo in eleType.GetProperties() )
                {
                    if ( ( propInfo.GetValue( aList_1[index], null ) ).Equals(
                        propInfo.GetValue( aList_2[index], null ) ) )
                        continue;
                    else
                        return false;
                }
            }
            return true;
        }
    }
}
