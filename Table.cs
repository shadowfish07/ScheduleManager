using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    class Table
    {
        private List<TimeSpan> timeSpanList =new List<TimeSpan>();
        private List<TimeSpan> timeSpanList_Titles = new List<TimeSpan>();//存所有title类型的timespan
        private string tableName;

        public string TableName { get => tableName; set => tableName = value; }

        public Table(string name)
        {
            tableName = name;
        }

        public bool AddTimeSpan(TimeSpan timeSpan)
        {
            try
            {
                timeSpanList.Add(timeSpan);
                if (timeSpan.Type1 == TimeSpan.Type.Title)
                    timeSpanList_Titles.Add(timeSpan);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool AddTimeSpan(DateTime startTime,DateTime endTime,TimeSpan.Type type,string describsion ="")
        {
            if (DateTime.Compare(startTime, endTime) > 0)
                return false;
            return AddTimeSpan(new TimeSpan(startTime, endTime, type,describsion));
        }

        public List<TimeSpan> GetList()
        {
            return timeSpanList;
        }
        /// <summary>
        /// 返回根据起始时间排列的List(总表）
        /// </summary>
        /// <param name="order">True为升序，Fause为降序</param>
        /// <returns></returns>
        public List<TimeSpan> Sort_All(bool order = true)
        {
            return Table.Sort(timeSpanList,order);
        }
        /// <summary>
        /// 返回根据起始时间排列的List(title表）
        /// </summary>
        /// <param name="order">True为升序，Fause为降序</param>
        /// <returns></returns>
        public List<TimeSpan> Sort_Title(bool order = true)
        {
            return Table.Sort(timeSpanList_Titles, order);
        }


        /// <summary>
        /// 返回根据起始时间排列的List
        /// </summary>
        /// <param name="timeSpan_list"></param>
        /// <param name="order"> True为升序，Fause为降序</param>
        /// <returns></returns>
        public static List<TimeSpan> Sort(List<TimeSpan> timeSpan_list,bool order=true)
        {
            System.Globalization.DateTimeFormatInfo dfi = new System.Globalization.DateTimeFormatInfo();
            dfi.ShortDatePattern = "HH:mm:ss";
            List<TimeSpan> tmpList = new List<TimeSpan>();
            List<TimeSpan> result = new List<TimeSpan>();
            TimeSpan extremeTimeSpan =null;
            DateTime extremeTime = Convert.ToDateTime("23:59:59",dfi);
            Func<DateTime, DateTime, bool, bool> compare = (t1, t2, mode) =>
              {
                  if (mode)
                  {
                      if (DateTime.Compare(t1, t2) > 0)
                          return true;
                      else
                          return false;
                  }
                  else
                  {
                      if (DateTime.Compare(t1, t2) < 0)
                          return true;
                      else
                          return false;
                  }
              };

            foreach (var item in timeSpan_list)
            {
                tmpList.Add(item);
            }

            for (int i =0;i< timeSpan_list.Count;i++)
            {
                foreach (var item in tmpList)
                {
                    if (compare(extremeTime,item.StartTime,order))
                    {
                        extremeTime = item.StartTime;
                        extremeTimeSpan  = item;
                    }
                }
                result.Add(extremeTimeSpan );
                tmpList.Remove(extremeTimeSpan);
                extremeTime = Convert.ToDateTime("23:59:59", dfi);
            }
            return result;
        }
    }
}
