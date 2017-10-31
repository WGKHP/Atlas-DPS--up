using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Atd.DAL
{
   public static class GetHostName
    {
      public static string gethostname()
        {
            string HostName = Dns.GetHostName();
            string stb = "Data Source =" + HostName + " ; Initial Catalog = cangkuDB; Integrated Security = True";
            return stb;
        }

    }

}
