using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace QASystem.CommonHelper
{
    /// <summary>
    /// 错误消息的（内存）队列。当出现异常之后，
    /// 直接把错误消息放到内存的队列里去。
    /// 然后程序继续往下执行，给用户反馈信息。不会阻塞用户的响应。
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 日志
        /// </summary>
        private static ILog _log = LogManager.GetLogger("QA.Log");

        /// <summary>
        /// 异常信息的队列
        /// </summary>
        private static readonly Queue<string> ExcMsg;

        static LogHelper()
        {
            ExcMsg = new Queue<string>();
            ThreadPool.QueueUserWorkItem(u =>
            {
                while (true)
                {
                    string str = string.Empty;

                    if (ExcMsg == null)
                    {
                        continue;
                    }

                    lock (ExcMsg)
                    {
                        if (ExcMsg.Count > 0)
                            str = ExcMsg.Dequeue();
                    }
                    //往日志文件里面写就可以了。
                    if (!string.IsNullOrEmpty(str))
                    {
                        _log.Error(str);
                    }
                    if (!ExcMsg.Any())
                    {
                        Thread.Sleep(30);
                    }
                }
            });
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="logMsg">日志内容</param>
        public static void WriteLog(string logMsg)
        {
            lock (ExcMsg)
            {
                ExcMsg.Enqueue(logMsg);
            }
        }
    }
}
