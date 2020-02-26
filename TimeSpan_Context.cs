using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace 日程管理生成系统
{
    /// <summary>
    /// 具体事件
    /// </summary>
    [SerializableAttribute]
    public class TimeSpan_Context:TimeSpan,ICloneable
    {
        private int[] inDays;
        private int[] weeks;
        private List<TimeSpan_Title> belongTo_TimeSpan_Titles = new List<TimeSpan_Title>();
        private List<TableItem_Context> belongTo_TableItem_Context = new List<TableItem_Context>();


        //事件先发送至Table类，再由Table类发送至TableEdit类（form）进行处理
        public delegate void HandleDayOrWeek(object sender, HandleDayOrWeekEventArgs e);
        public event HandleDayOrWeek HandleDayEvent;
        public event HandleDayOrWeek HandleWeekEvent;


        public int[] InDays { get => inDays; set => inDays = value; }
        public int[] InWeeks { get => weeks; set => weeks = value; }
        internal List<TimeSpan_Title> BelongTo_TimeSpan_Titles { get => belongTo_TimeSpan_Titles; set => belongTo_TimeSpan_Titles = value; }
        public List<TableItem_Context> BelongTo_TableItem_Context { get => belongTo_TableItem_Context; set => belongTo_TableItem_Context = value; }

        public TimeSpan_Context(int[] inDays, int[] weeks, TableItem_Title belongTo_TableItem_Title,TableItem_Context belongTo_TableItem_Context)
        {
            InDays = inDays;
            InWeeks = weeks;
            BelongTo_TimeSpan_Titles.Add(belongTo_TableItem_Title.TimeSpan_Title);
            BelongTo_TableItem_Context.Add(belongTo_TableItem_Context);
        }

        public TimeSpan_Context(int[] inDays, int[] weeks, TableItem_Title[] belongTo_TableItem_Title, TableItem_Context[] belongTo_TableItem_Context)
        {
            InDays = inDays;
            InWeeks = weeks;
            foreach (var item in belongTo_TableItem_Title)
            {
                belongTo_TimeSpan_Titles.Add(item.TimeSpan_Title);
            }
            foreach (var item in belongTo_TableItem_Context)
            {
                BelongTo_TableItem_Context.Add(item);
            }
        }
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



        /// <summary>
        /// 读入将符合格式要求的字符串,字符串为空时引发ArgumentException
        /// </summary>
        /// <remarks>字符串为空时引发ArgumentException</remarks>
        /// <param name="days"></param>
        public void ReadDays(string days)
        {
            try
            {
                int[] tmpinDays = ReadDaysOrWeeks(days);

                //处理新数据多出的天的UI变化
                foreach (var day in tmpinDays)
                {
                    if (!IsInThisDay(day))
                    {
                        HandleDayEvent(this, new HandleDayOrWeekEventArgs(day,HandleDayOrWeekEventArgs.HandleType.add));
                    }
                }

                //处理新数据少去的天的UI变化
                foreach (var item in InDays)
                {
                    Boolean flag = false;
                    foreach (var item2 in tmpinDays)
                    {
                        if (item == item2)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        HandleDayEvent(this, new HandleDayOrWeekEventArgs(item, HandleDayOrWeekEventArgs.HandleType.remove));
                    }
                }


                InDays = tmpinDays;

            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("绑定天数" + e.Message);
            }
        }
        /// <summary>
        /// 读入将符合格式要求的字符串,字符串为e空时引发ArgumentException
        /// </summary>
        ///<remarks>字符串为空时引发ArgumentException</remarks>
        /// <param name="weeks"></param>
        public void ReadWeeks(string weeks)
        {
            try
            {
                int[] tmpWeek = ReadDaysOrWeeks(weeks);
                Boolean flag = false;
                foreach (var item in InWeeks)
                {
                    foreach (var item2 in tmpWeek)
                    {
                        if (item == item2)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag) break;
                    //if (!flag)
                    //{
                    //    HandleWeekEvent(this, new HandleDayOrWeekEventArgs(item, HandleDayOrWeekEventArgs.HandleType.remove));
                    //}
                }


                this.weeks = tmpWeek;
                if(!flag) HandleWeekEvent(this, new HandleDayOrWeekEventArgs());

            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("绑定周数" + e.Message);
            }
            
        }

        /// <summary>
        /// 公用方法ReadDays和ReadWeeks的内部实现,字符串为空时引发ArgumentException
        /// </summary>
        /// <param name="str">待处理的字符串</param>
        /// <remarks>字符串为空时引发ArgumentException</remarks>
        /// <returns></returns>
        private int[] ReadDaysOrWeeks(string str)
        {
            //TODO:字符串格式非法时的处理
            if (str == "")
                throw new ArgumentException("字符为空");
            int[] resultTmp = new int[100];
            int[] result;
            int currentIndex = 0;
            string[] items = str.Split(',');
            foreach (var item in items)
            {
                if(item.Contains("-"))
                {
                    string[] span = item.Split('-');
                    for (int i = int.Parse(span[0]); i <= int.Parse(span[1]); i++)
                        resultTmp[currentIndex++] = i;
                }
                else
                {
                    resultTmp[currentIndex++] = int.Parse(item);
                }
            }
            result = new int[currentIndex];
            for (int i =0;i<currentIndex;i++)
            {
                result[i] = resultTmp[i];
            }

            return result;
        }

        /// <summary>
        /// 格式化输出days或weeks的值
        /// </summary>
        /// <param name="daysOrWeeks">"days" or "weeks"</param>
        /// <returns></returns>
        public string PrintDaysOrWeeks(string daysOrWeeks)
        {
            string result="";
            int pre=0;
            int after;
            int[] deal = null;
            switch (daysOrWeeks)
            {
                case "days":
                    deal = inDays;
                    break;
                case "weeks":
                    deal = weeks;
                    break;
                default:
                    break;
            }
            if(deal.Count()==1)
            {
                result = deal[0].ToString();
                return result ;
            }
            for(int i = 0;i<deal.Count()-1;i++)
            {
                if (Math.Abs(deal[i] - deal[i + 1]) == 1)
                {
                    pre = deal[i];
                    after = deal[i + 1];
                    int j;
                    for( j = i+2;j<deal.Count();j++)
                    {
                        if (Math.Abs(deal[j] - deal[j - 1]) == 1)
                        {
                            after = deal[j];
                        }
                        else
                            break;
                    }
                    i = j - 1;
                    int tmppre = Math.Min(pre, after);
                    after = Math.Max(pre, after);
                    pre = tmppre;
                    if (Math.Abs(pre - after) >= 2)
                    {
                        result += pre.ToString() + "-" + after.ToString()+",";
                    }
                    else
                    {
                        result += pre.ToString() + "," + after.ToString()+",";
                    }
                }
                else
                {
                    result += pre.ToString()+",";
                }
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }

        public bool CirculateFormatVaild(string text, int maxiWeek)
        {
            string[] items;
            items = text.Split(',');
            Func<int, int[], bool> checkVaild = isVaildWeek;
            int[] inputInt = new int[1];
            inputInt[0] = maxiWeek;
            return CirculateFormatVaild(items, checkVaild, inputInt);
        }

        public bool CirculateFormatVaild(string text, int[] vaildDays)
        {
            string[] items;
            items = text.Split(',');
            Func<int, int[], bool> checkVaild = isVaildDay;
            int[] inputInt = vaildDays;
            return CirculateFormatVaild(items, checkVaild, inputInt);
        }


        private bool CirculateFormatVaild(string[] items, Func<int,int[],bool> func,int[] inputInt)
        {
            try
            {
                foreach (var item in items)
                {
                    if (item.Contains("-"))
                    {
                        string[] span = item.Split('-');
                        if (int.Parse(span[0]) <= int.Parse(span[1]) && func(int.Parse(span[0]), inputInt) && func(int.Parse(span[1]), inputInt))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (func(int.Parse(item), inputInt))
                            return true;
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
        private bool isVaildDay(int target,int[] validDays)
        {
            if (validDays.Contains<int>(target))
                return true;
            return false;
        }

        private bool isVaildWeek(int target,int[] maxiweek)
        {
            if (target >= 1 && target <= maxiweek[0])
                return true;
            return false;
        }

        public bool IsInThisWeek(int week)
        {
            foreach (var item in InWeeks)
            {
                if (item == week)
                    return true;
            }
            return false;
        }

        public bool IsInThisDay(int day)
        {
            foreach (var item in InDays)
            {
                if (item == day)
                    return true;
            }
            return false;
        }
    
        /// <summary>
        /// 删除自身及其所有引用
        /// </summary>
        public void Delete()
        {
            foreach (var item in BelongTo_TimeSpan_Titles)
            {
                item.Context.Remove(this);
            }
            foreach (var item in BelongTo_TableItem_Context)
            {
                item.RemoveContext(this);
            }
        }
    
    }
}
