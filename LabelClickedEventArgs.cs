using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    public class LabelClickedEventArgs:EventArgs
    {
        public  enum TableItemType
        {
            Title,
            Context
        }

        public TableItemType Type;

        public LabelClickedEventArgs(TableItem tableItem)
        {
            if (tableItem.GetType() == typeof(TableItem_Context))
                Type = TableItemType.Context;
            else
                Type = TableItemType.Title;
        }
    }
}
