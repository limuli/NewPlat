using log4net;
using NewPlat.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.MySuperSocket
{
    static class LogHelper
    {
        private static readonly ILog _logger = LogManager.GetLogger("MyLogger");

        public static void Info(string message)
        {
            _logger.Info(message);
            CommonFunction.platm.Showmsg(message + Environment.NewLine );
        }

        public static void Error(string message)
        {
            _logger.Error(message);
           CommonFunction.platm.Showmsg(message + Environment.NewLine);
        }

    }
}
