using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 日程管理生成系统
{
     class TableItem_Title:TableItem
    {
        private TimeSpan_Title timeSpan_Title;

        public TableItem_Title(Label label)
        {
            Label = label;
        }

        public TableItem_Title(Label label,TimeSpan_Title timeSpan_Title)
        {
            Label = label;
            this.TimeSpan_Title = timeSpan_Title;
        }

        internal TimeSpan_Title TimeSpan_Title { get => timeSpan_Title; set => timeSpan_Title = value; }
    }
}
