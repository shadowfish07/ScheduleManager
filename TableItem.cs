using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 日程管理生成系统
{
     class TableItem
    {
        private Point location;
        private Label label;


        public Point Location { get => location; set => location = value; }
        public Label Label { get => label; set => label = value; }
    }
}
