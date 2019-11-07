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

        private const int COLUMN_SPAN_FIRST = 51;
        private const int COLUMN_SPAN = 78;  

        private int GetColumn(List<TimeSpan_Title> list)
        {
            return list.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="positioningLabel">周一从第2个元素开始</param>
        public TableDrawControl(Panel panel,Label[] positioningLabel)
        {
            this.panel = panel;
            this.positioningLabel = positioningLabel;
        }

        public void CreatTable(Table table_data)
        {
            int x = 0;
            int y = 0;
            positioningLabel[0].Text = table_data.TableName;
            List<TimeSpan_Title> timeSpan_list_sorted = TimeSpan_Title.Sort(table_data.GetTitileList());
            foreach (var item in timeSpan_list_sorted)
            {
                CreatItem(x, y++, item);
                foreach (var item2 in item.Context)
                {
                    foreach (var day in item2.InDays)
                    {
                        if (day != 0)
                            CreatItem(positioningLabel[day].Location.X, y, item2);
                    }
                }
            }
            //填补空位
            for (x = 1;x<=7;x++)
            {
                for (y=0;y< timeSpan_list_sorted.Count;y++)
                {
                    CreatEmptyItem(x, y);
                }
            }

            
        }

        private void CreatEmptyItem(int x,int y)
        {
            int resultX;
            int resultY;
            resultX = positioningLabel[x].Location.X;
            resultY = positioningLabel[x].Location.Y + COLUMN_SPAN_FIRST + y * COLUMN_SPAN;
           
            Label newLbl = new Label()
            {
                Font = new Font(new FontFamily("微软雅黑"), (float)10.28571),
                Location = new Point(resultX, resultY),
                AutoSize = false,
                Size = new Size(123, 78),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(newLbl);
            TableItem_Context newTC = new TableItem_Context(newLbl);
            current_table.Add(new Point(x, y), newTC);
        }

        private void CreatItem(int x, int y, TimeSpan item)
        {
            int resultX;
            int resultY;
            resultX = positioningLabel[x].Location.X;
            resultY = positioningLabel[x].Location.Y + COLUMN_SPAN_FIRST + y * COLUMN_SPAN;
            
            
            if (item.GetType() == typeof(TimeSpan_Title))
            {
                //创建title

                TimeSpan_Title tmp = (TimeSpan_Title)item;
                Label newLbl = new Label()
                {
                    Font = new Font(new FontFamily("微软雅黑"), (float)10.28571),
                    Location = new Point(resultX, resultY),
                    AutoSize = false,
                    Size = new Size(123, 78),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                newLbl.Text = tmp.Outline + "\n" + tmp.StartTime.ToString("t") + "-" + tmp.EndTime.ToString("t");
                TableItem_Title newTT = new TableItem_Title(newLbl, (TimeSpan_Title)item);
                current_table.Add(new Point(x, y),newTT);
                panel.Controls.Add(newLbl);
            }
            else
            {
                //创建context

                TimeSpan_Context tmp = (TimeSpan_Context)item;
                if (current_table.ContainsKey(new Point(x,y)))
                {
                    //已存在时，添加
                    
                    TableItem_Context ttmp = (TableItem_Context)current_table[new Point(x, y)];
                    ttmp.Add(tmp);
                    ttmp.UpdateLableText();
                }
                else
                {
                    //不存在时，创建

                    Label newLbl = new Label()
                    {
                        Font = new Font(new FontFamily("微软雅黑"), (float)10.28571),
                        Location = new Point(resultX, resultY),
                        AutoSize = false,
                        Size = new Size(123, 78),
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    TableItem_Context newTC = new TableItem_Context(newLbl,new TimeSpan_Context[] { (TimeSpan_Context)item });
                    current_table.Add(new Point(x, y), newTC);
                    newTC.UpdateLableText();
                    panel.Controls.Add(newLbl);
                }
            }
            

        }
    }
}
