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
<<<<<<< HEAD
        private static string pc = Environment.MachineName;
            public static string conString = $"Data Source={pc}\\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True";
=======
        static string pcName = Environment.MachineName;
        public static string conString = $"Data Source={pcName}\\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True";
>>>>>>> 6bdefe2ffe03e65ee9d86252eab8c4796ed7516c
    }
}
