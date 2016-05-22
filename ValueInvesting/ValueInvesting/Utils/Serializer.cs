using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Utils
{
    public static class Serializer
    {
        public static bool SaveListToFile<T>( IList<T> aList, String aFilename )
        {
            try
            {
                using ( Stream stream = File.Open( aFilename, FileMode.Create ) )
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize( stream, aList );
                    return true;
                }
            }
            catch ( IOException )
            {
                return false;
            }
        }

        public static bool SaveObjectToFile<T>( T aObj, String aFilename )
        {
            try
            {
                using ( Stream stream = File.Open( aFilename, FileMode.Create ) )
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize( stream, aObj );
                    return true;
                }
            }
            catch ( IOException )
            {
                return false;
            }
        }

        public static List<T> GetListFromFile<T>( String aFilename )
        {
            List<T> nList = new List<T>();
            try
            {
                using ( Stream stream = File.Open( aFilename, FileMode.Open ) )
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    nList = (List<T>) bin.Deserialize( stream );
                }
            }
            catch ( IOException )
            {
            }
            return nList;
        }

        public static T GetObjectFromFile<T>( String aFilename )
        {
            try
            {
                using ( Stream stream = File.Open( aFilename, FileMode.Open ) )
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    return (T) ( bin.Deserialize( stream ) );
                }
            }
            catch ( IOException )
            {
                return default( T );
            }
        }

    }
}
