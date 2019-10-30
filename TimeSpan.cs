using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    class TimeSpan
    {
        public string Describsion;
        public DateTime StartTime;
        public DateTime EndTime;

        public TimeSpan(DateTime startTime, DateTime endTime, string describsion = "")
        {
            StartTime = startTime;
            EndTime = endTime;
            Describsion = describsion;
        }
    }
}
