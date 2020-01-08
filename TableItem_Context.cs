using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 日程管理生成系统
{

    /// <summary>
    /// 表达一个日程表内容项，包含一系列事件（List中的TimeSpan_Context），Label和位置
    /// </summary>
    class TableItem_Context : TableItem
    {
        private List<TimeSpan_Context> timeSpan= new List<TimeSpan_Context>();


        public TableItem_Context(Label label, TimeSpan_Context[] timespan) : base(label)
        {
            Label.Click += OnClicked;

            for (int i = 0; i < timespan.Length; i++)
                this.timeSpan.Add(timespan[i]);

        }
        public TableItem_Context(Label label) : base(label)
        {
            Label.Click += OnClicked;

        }


        public List<TimeSpan_Context> GetTimeSpanList()
        {
            return timeSpan;
        }

        //TODO:重绘图表


        /// <summary>
        /// 修改一项事件
        /// </summary>
        /// <param name="describsion">修改后的事件描述</param>
        /// <param name="outline">修改后的事件概述</param>
        /// <param name="inDays">修改后的事件响应天</param>
        /// <param name="weeks">修改后的事件响应周</param>
        /// <param name="oldIndex">要修改的事件Index值</param>
        public void Edit(string describsion,string outline, int[] inDays,int[] weeks,int oldIndex)
        {
           
            TimeSpan_Context target = this.timeSpan.Find(t => t.Index1 == oldIndex);//Learn this way to find a specific item
            target.Describsion = describsion;
            target.InDays = inDays;
            target.Weeks = weeks;
            target.Outline = outline;
            UpdateLableText();
        }

        /// <summary>
        /// 修改一项事件,参数不正确会返回ArgumentException
        /// </summary>
        /// <param name="describsion">修改后的事件描述</param>
        /// <param name="outline">修改后的事件概述</param>
        /// <param name="inDays">修改后的事件响应天</param>
        /// <param name="weeks">修改后的事件响应周</param>
        /// <param name="oldIndex">要修改的事件Index值</param>
        public void Edit(string describsion, string outline, string inDays, string weeks, int oldIndex)
        {
            TimeSpan_Context target = this.timeSpan.Find(t => t.Index1 == oldIndex);//Learn this way to find a specific item
            //加入修改失败时重置,进行深拷贝
            //TODO:需要测试深拷贝是否有效
            TimeSpan_Context tmp = (TimeSpan_Context)target.Clone();
            target.Describsion = describsion;
            try
            {
                target.ReadDays(inDays);
                target.ReadWeeks(weeks);
            }
            catch (ArgumentException)
            {
                //重置
                target = tmp;
                throw;
            }
            target.Outline = outline;
            UpdateLableText();
        }

        /// <summary>
        /// 重绘该单元格内所有事件的内容
        /// </summary>
        public  void UpdateLableText()
        {
            Label.Text = "";
            foreach (var item in this.timeSpan)
            {
                Label.Text += item.Outline + "\n" + item.Describsion + "\n";//TODO:添加文本过长时，只显示概要的功能
            }
        }

        /// <summary>
        /// 移动一个内容至另一个时间区间
        /// </summary>
        /// <param name="newBelongTo">新的时间区间</param>
        /// <param name="oldIndex">该单元格内要移动的事件的序号</param>
        public void Move(TimeSpan_Title newBelongTo,int oldIndex)
        {
            TimeSpan_Context target = this.timeSpan.Find(t => t.Index1 == oldIndex);
            newBelongTo.Context.Add(target);
            target.BelongTo = newBelongTo;
            target.BelongTo.Context.Remove(target);
        }

        /// <summary>
        /// 添加一个事件
        /// </summary>
        /// <param name="timeSpan_Context"></param>
        public void Add(TimeSpan_Context timeSpan_Context)
        {
            timeSpan.Add(timeSpan_Context);
        }

        /// <summary>
        /// 清除所有事件
        /// </summary>
        public void Clear()
        {
            timeSpan = new List<TimeSpan_Context>();
        }

        /// <summary>
        /// 检测事件列表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return timeSpan.Count == 0 ? true:false;
        }

        protected override void OnClicked(object sender, EventArgs e)
        {
            base.OnClicked(this, null);
        }
    }
}
