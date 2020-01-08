using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 日程管理生成系统
{
    /// <summary>
    /// 日程表每项的基类，包含每项的Label和位置
    /// </summary>
    public class TableItem
    {
        private Point location;
        private Label label;
        public delegate void LabelClickedHandler(TableItem sender, LabelClickedEventArgs e);
        public event LabelClickedHandler LabelClickedEvent;
        
        public Point Location { get => location; set => location = value; }
        public Label Label { get => label; set => label = value; }

        public TableItem(Label label)
        {
            Label = label;
        }

        protected virtual void OnClicked(object sender,EventArgs e)
        {
            LabelClickedEvent((TableItem)sender, new LabelClickedEventArgs((TableItem)sender));
        }
    }
}
