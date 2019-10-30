using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    class Table
    {
        private List<TimeSpan> timeSpanList =new List<TimeSpan>();

        public void AddTimeSpan(TimeSpan timeSpan)
        {
            timeSpanList.Add(timeSpan);
        }
        public void AddTimeSpan(DateTime startTime,DateTime endTime,string describsion ="")
        {
            AddTimeSpan(new TimeSpan(startTime, endTime, describsion));
        }
    }
}
