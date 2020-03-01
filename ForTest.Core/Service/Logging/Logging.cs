using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ForTest.Core.Service.Log
{
    public class Logging
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logging));

        public static void InitLogger()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(HttpContext.Current.ApplicationInstance.Server.MapPath("~") + "log4net.config"));
        }

        public static ILog Log
        {
            get
            {
                return log;
            }
        }
    }
}
