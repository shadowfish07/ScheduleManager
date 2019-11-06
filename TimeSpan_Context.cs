using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    [SerializableAttribute]
    public  class TimeSpan_Context:TimeSpan
    {
        private int[] inDays;
        private int[] weeks;
        private TimeSpan_Title belongTo;

        public int[] InDays { get => inDays; set => inDays = value; }
        public int[] Weeks { get => weeks; set => weeks = value; }
        internal TimeSpan_Title BelongTo { get => belongTo; set => belongTo = value; }

        public TimeSpan_Context(int[] inDays,int[] weeks,TimeSpan_Title belongTo)
        {
            InDays = inDays;
            Weeks = weeks;
            BelongTo = belongTo;
        }


        public bool IsInThisWeek(int week)
        {
            foreach (var item in Weeks)
            {
                if (item == week)
                    return true;
            }
            return false;
        }
    }
}
