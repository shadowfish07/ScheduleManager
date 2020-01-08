using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace 日程管理生成系统
{
    [SerializableAttribute]
    public class TimeSpan_Context:TimeSpan,ICloneable
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

        public TimeSpan_Context(int[] inDays, int[] weeks, TableItem_Title belongTo)
        {
            InDays = inDays;
            Weeks = weeks;
            BelongTo = belongTo.TimeSpan_Title;
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
                inDays = ReadDaysOrWeeks(days);
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
                this.weeks = ReadDaysOrWeeks(weeks);
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
            for(int i = 0;i<deal.Count();i++)
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
            foreach (var item in Weeks)
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
    }
}
