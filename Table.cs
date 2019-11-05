using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    class Table
    {
        //private List<TimeSpan_Context> timeSpanList_Context =new List<TimeSpan_Context>(); 由于可以通过TimeSpan_Title获取所有TimeSpan_Context，此处暂无需存储
        private List<TimeSpan_Title> timeSpanList_Titles = new List<TimeSpan_Title>();//存所有title类型的timespan
        private string tableName;

        public string TableName { get => tableName; set => tableName = value; }

        public Table(string name)
        {
            tableName = name;
        }

        //TODO:添加完后需要重绘表格
        public void AddTimeSpan_Context(int[] inDays,int[] weeks,TimeSpan_Title belongTo)
        {
            belongTo.Context.Add(new TimeSpan_Context(inDays, weeks, belongTo));
        }

        public bool AddTimeSpan_Title(TimeSpan_Title timeSpan)
        {
            timeSpanList_Titles.Add(timeSpan);
            return true;
        }

        public bool AddTimeSpan_Title(DateTime startTime,DateTime endTime,string describsion ="")
        {
            if (DateTime.Compare(startTime, endTime) > 0)
                return false;
            return AddTimeSpan_Title(new TimeSpan_Title(startTime, endTime,describsion));
        }

        public List<TimeSpan_Title> GetTitileList()
        {
            return timeSpanList_Titles;
        }

     }
}
