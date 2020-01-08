using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 日程管理生成系统
{
    /// <summary>
    /// 表示一个日程表第一行时间区间，包含该区间的Label，位置和第一行数据类（TimeSpan_Title）
    /// </summary>
    public class TableItem_Title:TableItem
    {
        private TimeSpan_Title timeSpan_Title;

        public TableItem_Title(Label label):base(label)
        {
            Label.Click += OnClicked;

        }

        public TableItem_Title(Label label,TimeSpan_Title timeSpan_Title) : base(label)
        {
            this.TimeSpan_Title = timeSpan_Title;
            Label.Click += OnClicked;

        }

        protected override void OnClicked(object sender, EventArgs e)
        {
            base.OnClicked(this, null);
        }

        internal TimeSpan_Title TimeSpan_Title { get => timeSpan_Title; set => timeSpan_Title = value; }
    }
}
