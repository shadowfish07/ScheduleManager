using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    static class  ProgramData
    {
        static public List<Table> Table_List = new List<Table>() { new Table("默认表", 20) };
        static public TableEdit Form_TableEdit = new TableEdit();
        public const String TABLE_EXTRA_NAME = ".rtb";
    }
}
