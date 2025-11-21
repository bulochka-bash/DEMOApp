using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace DEMOApp
{
    internal class ConnectionString
    {
        private static string pc = Environment.MachineName;
            public static string conString = $"Data Source={pc}\\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True";
    }
}
