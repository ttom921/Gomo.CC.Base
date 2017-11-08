using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gomo.CC.Common
{
    public class Log4NetWriter : ILogWriter
    {
        public void WriteLogInfo(string txt)
        {
            ILog logWriter = log4net.LogManager.GetLogger("NETCoreRepository", "WebLogger");
            logWriter.Error(txt);
        }
    }
}
