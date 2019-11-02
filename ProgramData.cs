using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日程管理生成系统
{
    static class  ProgramData
    {
        static public List<Table> Table_List = new List<Table>();

        static ProgramData()
        {
            Table table = new Table("默认表");
            Table_List.Add(table);
        }
    }
}
