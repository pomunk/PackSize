using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{

    public class Logger : ILogger
    {
        private static Logger instance;

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
