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

        public delegate void HandleDay(object sender, HandleDayEventArgs e);

        /// <summary>
        /// 这个属性声明可以避免序列化时序列化了事件订阅者。前缀field不可去除，详情见该问题
        /// <see cref="https://stackoverflow.com/questions/4450830/difference-between-field-nonserialized-and-nonserialized-in-c-sharp" />
        /// </summary>
        [field: NonSerialized]
        public event HandleDay HandleDayEvent;

        public string TableName { get => tableName; set => tableName = value; }
        public int MaxiWeek { get => maxiWeek; set => maxiWeek = value; }

        public Table(string name,int maxiWeek)
        {
            tableName = name;
            MaxiWeek = maxiWeek;
        }

        //TODO:添加完后需要重绘表格
        public TimeSpan_Context AddTimeSpan_Context(int[] inDays,int[] weeks,TableItem_Title belongTo_TableItem_Title,TableItem_Context belongTo_TableItem_Context)
        {
            TimeSpan_Context newtc = new TimeSpan_Context(inDays, weeks, belongTo_TableItem_Title,belongTo_TableItem_Context);
            newtc.HandleDayEvent += HandleDay_Handle;
            belongTo_TableItem_Title.TimeSpan_Title.Context.Add(newtc);
            timeSpanList_Context.Add(newtc);
            return newtc;
        }

        private void HandleDay_Handle(object sender, HandleDayEventArgs e)
        {
            HandleDayEvent(sender, e);
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
