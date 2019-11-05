using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 日程管理生成系统
{

    
    class TableItem_Context : TableItem
    {
        private List<TimeSpan_Context> timeSpan= new List<TimeSpan_Context>();


        //TODO:重绘图表
        public void Edit(string describsion,string outline, int[] inDays,int[] weeks,int oldIndex)
        {
            TimeSpan_Context target = this.timeSpan.Find(t => t.Index1 == oldIndex);
            target.Describsion = describsion;
            target.InDays = inDays;
            target.Weeks = weeks;
            target.Outline = outline;

            Label.Text = "";
            foreach (var item in this.timeSpan)
            {
                Label.Text += item.Outline + "\n";
            }
        }

        public void Move(TimeSpan_Title newBelongTo,int oldIndex)
        {
            TimeSpan_Context target = this.timeSpan.Find(t => t.Index1 == oldIndex);
            newBelongTo.Context.Add(target);
            target.BelongTo = newBelongTo;
            target.BelongTo.Context.Remove(target);
        }

        public void Add(TimeSpan_Context timeSpan_Context)
        {
            timeSpan.Add(timeSpan_Context);
        }

        public TableItem_Context(Label label,TimeSpan_Context[] timespan)
        {
            Label= label;
            for (int i = 0;i<timespan.Length;i++)
                this.timeSpan.Add(timespan[i]);
            
        }

        public TableItem_Context(Label label)
        {
            Label = label;
        }

        public void Clear()
        {
            timeSpan = new List<TimeSpan_Context>();
        }
    }
}
