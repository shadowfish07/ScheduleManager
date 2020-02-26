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

        public delegate void HandleDayOrWeek(object sender, HandleDayOrWeekEventArgs e);

        /// <summary>
        /// 这个属性声明可以避免序列化时序列化了事件订阅者。前缀field不可去除，详情见该问题
        /// <see cref="https://stackoverflow.com/questions/4450830/difference-between-field-nonserialized-and-nonserialized-in-c-sharp" />
        /// </summary>
        [field: NonSerialized]
        public event HandleDayOrWeek HandleDayEvent;
        [field: NonSerialized]
        public event HandleDayOrWeek HandleWeekEvent;


        public string TableName { get => tableName; set => tableName = value; }
        public int MaxiWeek { get => maxiWeek; set => maxiWeek = value; }

        public Table(string name,int maxiWeek)
        {
            tableName = name;
            MaxiWeek = maxiWeek;
        }

        //TODO:添加完后需要重绘表格（当前的引用后已经进行了重绘）
        /// <summary>
        /// 添加一个事件
        /// </summary>
        /// <param name="inDays"></param>
        /// <param name="weeks"></param>
        /// <param name="belongTo_TableItem_Title">事件所属的时间区间</param>
        /// <param name="belongTo_TableItem_Context">事件</param>
        /// <returns>返回该事件的TimeSpan_Context对象</returns>
        public TimeSpan_Context AddTimeSpan_Context(int[] inDays,int[] weeks,TableItem_Title belongTo_TableItem_Title,TableItem_Context belongTo_TableItem_Context)
        {
            TimeSpan_Context result = new TimeSpan_Context(inDays, weeks, belongTo_TableItem_Title,belongTo_TableItem_Context);
            result.HandleDayEvent += HandleDay_Handle;
            result.HandleWeekEvent += HandleWeek_Handle;
            belongTo_TableItem_Title.TimeSpan_Title.Context.Add(result);
            timeSpanList_Context.Add(result);

            belongTo_TableItem_Context.AddContext(result);
            return result;
        }


        public void RemoveTimeSpan_Context(int ID)
        {
            TimeSpan_Context beRemovedTC = timeSpanList_Context.Find(t => t.ID == ID);
            timeSpanList_Context.Remove(beRemovedTC);
            beRemovedTC.Delete();
        }


        private void HandleWeek_Handle(object sender, HandleDayOrWeekEventArgs e)
        {
            HandleWeekEvent(sender, e);
        }

        private void HandleDay_Handle(object sender, HandleDayOrWeekEventArgs e)
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
