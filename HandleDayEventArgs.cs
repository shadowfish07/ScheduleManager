using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    public class HandleDayEventArgs:EventArgs
    {
        public int Day;
        public enum HandleType
        {
            add,
            remove
        }

        public HandleType Type; 

        public HandleDayEventArgs(int day,HandleType type)
        {
            this.Day = day;
            Type = type;
        }
    }
}
