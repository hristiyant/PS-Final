using System;

namespace UserLogin
{
    class Logs
    {
        public int LogsId { get; set; }
        public DateTime LogTime { get; set; }
        public string LogContent { get; set; }

        public Logs() { }

        public Logs(string logContent)
        {
            LogTime = DateTime.Now;
            LogContent = logContent;
        }
    }
}
