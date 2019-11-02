using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace 日程管理生成系统
{
    class TableDrawControl
    {
        private Hashtable current_table = new Hashtable();
        private Label[] positioningLabel;
        private Panel panel;
        private Table table_data;

        private const int COLUMN_SPAN_FIRST = 51;
        private const int COLUMN_SPAN = 78;  

        private int GetColumn(List<TimeSpan> list)
        {
            return list.Count();
        }

        public TableDrawControl(Panel panel,Table table_data,Label[] positioningLabel)
        {
            this.panel = panel;
            this.positioningLabel = positioningLabel;
            this.table_data = table_data;
        }

        public void CreatTable()
        {
            int x = 0;
            int y = 0;
            //Label aboveLbl;
            positioningLabel[0].Text = table_data.TableName;
            List<TimeSpan> timeSpan_list_sorted = table_data.Sort_Title();
            foreach (var item in timeSpan_list_sorted)
            {
                ConcreteCreat(x, y++, item);
            }
            y = 0;

            //TODO:读取表中的数据

            //foreach (var item in table_data.GetList())
            //{
            //    if (item.Type1 == TimeSpan.Type.Title)
            //    {
            //        bool[] flag = new bool[current_table.Keys.Count];
            //        foreach (var xy in current_table.Keys)
            //        {
            //            Point tmp = (Point)xy;
            //            if (tmp.X == 0)
            //            {
            //                flag[y] = true;
            //            }
            //        }
            //        for (int i = 0; i < current_table.Keys.Count; i++)
            //        {
            //            if (flag[i] == false)
            //            {
            //                y = i;
            //                break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        bool[] flag = new bool[8];
            //        foreach (var itm in table_data.GetList())
            //        {
            //            foreach (var values in current_table.Values)
            //            {

            //            }
            //        }
            //    }

            //    ConcreteCreat(x, y, item);
            //}
        }

        private void ConcreteCreat(int x, int y, TimeSpan item)
        {
            int span;
            int resultX;
            int resultY;
            resultX = positioningLabel[x].Location.X;
            resultY = positioningLabel[x].Location.Y + COLUMN_SPAN_FIRST + y * COLUMN_SPAN;
            Label newLbl = new Label()
            {
                Text = item.Outline+"\n"+item.StartTime.ToString("t")+"-"+item.EndTime.ToString("t"),
                Font = new Font(new FontFamily("微软雅黑"), (float)10.28571),
                Location = new Point(resultX,resultY),
                AutoSize = false,
                Size = new Size(123, 78),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(newLbl);
            TableItem newTI = new TableItem(newLbl, new TimeSpan[] { item });
            current_table.Add(new Point(x, y), newLbl);
        }
    }
}
