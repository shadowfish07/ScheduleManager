using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    class TimeSpan
    {
        private static int Index = 0;

        private string describsion;
        private DateTime startTime;
        private DateTime endTime;
        private string outline;
        private int index1;
        private Type type1;

        public enum Type
        {
            Title,
            memember
        }

        public string Describsion { get => describsion; set => describsion = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public string Outline { get => outline; set => outline = value; }
        public int Index1 { get => index1; set => index1 = value; }
        internal Type Type1 { get => type1; set => type1 = value; }

        public TimeSpan(DateTime startTime, DateTime endTime,Type type, string describsion = "")
        {
            StartTime = startTime;
            EndTime = endTime;
            Describsion = describsion;
            outline = describsion;
            Index1 = TimeSpan.Index++;
            Type1 = type;
        }

        /// <summary>
        /// 验证list中无时间重叠项
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool CheckVaild(List<TimeSpan> list, out string error)
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
    }
}
