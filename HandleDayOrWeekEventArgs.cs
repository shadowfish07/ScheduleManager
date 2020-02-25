using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    public class HandleDayOrWeekEventArgs:EventArgs
    {
        public int Value;
        public enum HandleType
        {
            add,
            remove
        }

        public HandleType Type; 
        /// <summary>
        /// 用于Week事件
        /// </summary>
        public HandleDayOrWeekEventArgs()
        {

        }
        /// <summary>
        /// 用于Day事件
        /// </summary>
        /// <param name="dayOrweek"></param>
        /// <param name="type"></param>
        public HandleDayOrWeekEventArgs(int dayOrweek,HandleType type)
        {
            this.Value = dayOrweek;
            Type = type;
        }
    }
}
