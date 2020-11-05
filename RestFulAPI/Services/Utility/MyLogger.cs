using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFulAPI.Services.Utility
{
    public class MyLogger : ILogger
    {
        private static MyLogger instance;
        private static Logger logger;

        private MyLogger()
        {

        }

        public static MyLogger GetInstance()
        {
            if (instance == null)
                instance = new MyLogger();
            return instance;
        }

        private Logger GetLogger(string theLogger)
        {
            if (MyLogger.logger == null)
                MyLogger.logger = LogManager.GetLogger(theLogger);
            return MyLogger.logger;
        }



        public void Debug(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLog").Debug(message);
            else
                GetLogger("myAppLog").Debug(message, arg);

        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLog").Debug(message);
            else
                GetLogger("myAppLog").Debug(message, arg);

        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLog").Debug(message);
            else
                GetLogger("myAppLog").Debug(message, arg);

        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLog").Debug(message);
            else
                GetLogger("myAppLog").Debug(message, arg);

        }
    }
}