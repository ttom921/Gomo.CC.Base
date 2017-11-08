using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Gomo.CC.Common
{
    public class LogHelper
    {
        public static Queue<string> ExceptionStringQueue = new Queue<string>();
        public static List<ILogWriter> LogWriterList = new List<ILogWriter>();
        static LogHelper()
        {
            LogWriterList.Add(new Log4NetWriter());
            ThreadPool.QueueUserWorkItem(o => {
                while (true)
                {
                    lock (ExceptionStringQueue)
                    {
                        if (ExceptionStringQueue.Count > 0)
                        {
                            string str = ExceptionStringQueue.Dequeue();
                            //把異常信息寫到日志文件裏面去
                            //變化點:有可能到日志文件，有可能寫到數據庫裏面去，有可能都寫

                            //執行委托方法，將異常信息寫到委托裏面去
                            //WriteLogDelFun(str);
                            //ILogWriter writer = new TextFileWriter();
                            //writer.WriteLogInfo(str);
                            foreach (var logWriter in LogWriterList)
                            {
                                logWriter.WriteLogInfo(str);
                            }
                        }
                        else
                        {
                            Thread.Sleep(100);
                        }
                    }
                }
            });
        }
        public static void WriteLog(string exceptionText)
        {
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(exceptionText);
            }
        }
    }
}
