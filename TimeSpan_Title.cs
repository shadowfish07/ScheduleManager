using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace 日程管理生成系统
{
    [SerializableAttribute]
    public  class TimeSpan_Title:TimeSpan, ICloneable
    {
        private DateTime startTime;
        private DateTime endTime;
        private List<TimeSpan_Context> context = new List<TimeSpan_Context>();

        /// <summary>
        /// 返回深拷贝
        /// </summary>
        /// <see cref="https://blog.csdn.net/XJAVASunjava/article/details/7648242"/>
        /// <remarks>深克隆代码来自网络，待测试是否有效</remarks>
        /// <returns></returns>
        public new object Clone()
        {
            //TODO：测试是否有效
            using (System.IO.Stream stream = new System.IO.MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, typeof(TimeSpan_Context));
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                return formatter.Deserialize(stream);
            }
        }


        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        internal List<TimeSpan_Context> Context { get => context; set => context = value; }

        public TimeSpan_Title(DateTime startTime, DateTime endTime, string describsion = "")
        {
            StartTime = startTime;
            EndTime = endTime;
            Describsion = describsion;
            Outline = describsion;
        }

        /// <summary>
        /// 验证list中无时间重叠项
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool CheckVaild(List<TimeSpan_Title> list, out string error)
        {
            error = "";
            System.Collections.Hashtable times = new System.Collections.Hashtable();
            foreach (var item in list)
            {
                if (!times.ContainsKey(item.StartTime))
                {
                    times.Add(item.StartTime, item.EndTime);
                }
            }

            Func<DateTime, DateTime, DateTime, bool> IsInSpan = (t1, t2, t3) =>
              {
                  if (DateTime.Compare(t1, t2) == 0 && DateTime.Compare(t1, t3) == 0)
                      return false;//起止时间相同时，算合法
                  if (DateTime.Compare(t1, t2) > 0 && DateTime.Compare(t1, t3) < 0)
                      return true;
                  else
                      return false;
              };
            foreach (var head in times.Keys)
            {
                foreach (var spanhead in times.Keys)
                {
                    if (IsInSpan((DateTime)head, (DateTime)spanhead, (DateTime)times[spanhead]))
                    {
                        DateTime tmp = (DateTime)head;
                        error = "起/止于 " +tmp.ToString("t")+"与";
                        tmp = (DateTime)spanhead;
                        error += "  " + tmp.ToString("t");
                        tmp = (DateTime)times[spanhead];
                        error += "-" + tmp.ToString("t")+"冲突";
                        return false;
                    }
                }
            }
            foreach (var tail in times.Values)
            {
                foreach (var spanhead in times.Keys)
                {
                    if (IsInSpan((DateTime)tail, (DateTime)spanhead, (DateTime)times[spanhead]))
                    {
                        DateTime tmp = (DateTime)tail;
                        error = "起/止于 " + tmp.ToString("t") + "与";
                        tmp = (DateTime)spanhead;
                        error += "  " + tmp.ToString("t");
                        tmp = (DateTime)times[spanhead];
                        error += "-" + tmp.ToString("t") + "冲突";
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 返回根据起始时间排列的List
        /// </summary>
        /// <param name="timeSpan_list"></param>
        /// <param name="order"> True为升序，Fause为降序</param>
        /// <returns></returns>
        public static List<TimeSpan_Title> Sort(List<TimeSpan_Title> timeSpan_list, bool order = true)
        {
            System.Globalization.DateTimeFormatInfo dfi = new System.Globalization.DateTimeFormatInfo();
            dfi.ShortDatePattern = "HH:mm:ss";
            List<TimeSpan_Title> tmpList = new List<TimeSpan_Title>();
            List<TimeSpan_Title> result = new List<TimeSpan_Title>();
            TimeSpan_Title extremeTimeSpan = null;
            DateTime extremeTime = Convert.ToDateTime("23:59:59", dfi);
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

            for (int i = 0; i < timeSpan_list.Count; i++)
            {
                foreach (var item in tmpList)
                {
                    if (compare(extremeTime, item.StartTime, order))
                    {
                        extremeTime = item.StartTime;
                        extremeTimeSpan = item;
                    }
                }
                result.Add(extremeTimeSpan);
                tmpList.Remove(extremeTimeSpan);
                extremeTime = Convert.ToDateTime("23:59:59", dfi);
            }
            return result;
        }
    }
}
