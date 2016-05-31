using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueInvesting.Commons
{
    public class Config
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string ConnectionString { get; set; }

        public Config()
        {
            Name = "Timothy";
            ConnectionString = "localhost";
        }

        public override string ToString()
        {
            return String.Format(
                @"Hi, my name is {0}. I am {1} years old and I am a web server at ""{2}"".",
                Name, Age, ConnectionString );
        }
    }
}
