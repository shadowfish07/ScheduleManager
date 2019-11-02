using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 日程管理生成系统
{

    
    class TableItem
    {
        private Label label;
        private List<TimeSpan> timeSpan= new List<TimeSpan>();
        public TableItemStatu Statu=TableItemStatu.Null;

        public enum TableItemStatu
        {
            Null,
            FirstColumn,
            Exist
        }

        public void Edit(TimeSpan timeSpan,int index)
        {
            TimeSpan target = this.timeSpan.Find(t => t.Index1 == index);
            target.StartTime = timeSpan.StartTime;
            target.EndTime = timeSpan.EndTime;
            target.Describsion = timeSpan.Describsion;
            target.Outline = timeSpan.Outline;
            label.Text = "";
            foreach (var item in this.timeSpan)
            {
                label.Text += item.Outline + "\n";
            }
        }

        public TableItem(Label label,TimeSpan[] timespan)
        {
            this.label = label;
            for (int i = 0;i<timespan.Length;i++)
                this.timeSpan.Add(timespan[i]);
            
            Statu = TableItemStatu.Exist;
        }

        public TableItem(Label label)
        {
            this.label = label;
            Statu = TableItemStatu.FirstColumn;
        }

        public void Clear()
        {
            Statu = TableItemStatu.Null;
        }
    }
}
