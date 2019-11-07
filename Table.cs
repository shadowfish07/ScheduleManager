using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    [SerializableAttribute]
    public class Table
    {
        private List<TimeSpan_Context> timeSpanList_Context =new List<TimeSpan_Context>();//TODO：不这样记录可以通过TimeSpan_Title序列化Context吗？
        private List<TimeSpan_Title> timeSpanList_Titles = new List<TimeSpan_Title>();//存所有title类型的timespan
        private string tableName ="admin";
        private int maxiWeek;
        

        public string TableName { get => tableName; set => tableName = value; }
        public int MaxiWeek { get => maxiWeek; set => maxiWeek = value; }

        public Table(string name,int maxiWeek)
        {
            tableName = name;
            MaxiWeek = maxiWeek;
        }

        //TODO:添加完后需要重绘表格
        public void AddTimeSpan_Context(int[] inDays,int[] weeks,TimeSpan_Title belongTo)
        {
            TimeSpan_Context newtc = new TimeSpan_Context(inDays, weeks, belongTo);
            belongTo.Context.Add(newtc);
            timeSpanList_Context.Add(newtc);
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
