using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace 日程管理生成系统
{
    //TODO:TEST ALL FUNCTION
    class TableDrawControl
    {
        private Hashtable table_current ;
        private Label[] positioningLabel;
        private Panel panel;
        /// <summary>
        /// 用来清空列表时清除所有创建的Label
        /// </summary>
        private List<Label> createdLabel = new List<Label>();

        private const int COLUMN_SPAN_FIRST = 51;
        private const int COLUMN_SPAN = 78;  
        
        /// <summary>
        /// 返回列表行数
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private int GetColumn(List<TimeSpan_Title> list)
        {
            return list.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="positioningLabel">周一从第2个元素开始</param>
        public TableDrawControl(Panel panel,Hashtable table_current,Label[] positioningLabel)
        {
            this.panel = panel;
            this.positioningLabel = positioningLabel;
            this.table_current = table_current;
        }

        public void CreatTable(Table table_data,int currentWeek)
        {
            ClearTable();
            int x = 0;
            int y = 0;
            positioningLabel[0].Text = table_data.TableName;
            List<TimeSpan_Title> timeSpan_list_sorted = TimeSpan_Title.Sort(table_data.GetTitileList());
            foreach (var item in timeSpan_list_sorted)
            {
                //CreatItem(x, y++, item);
                foreach (var item2 in item.Context)
                {
                    if (item2.IsInThisWeek(currentWeek))
                    {
                        foreach (var day in item2.InDays)
                        {
                            if (day != 0)
                                CreatItem(day, y, item2);
                        }
                    }
                }
                CreatItem(x, y++, item);
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

            if (!table_current.ContainsKey(new Point(x, y)))
            {
                Label newLbl = new Label()
                {
                    Font = new Font(new FontFamily("微软雅黑"), (float)10.28571),
                    Location = new Point(resultX, resultY),
                    AutoSize = false,
                    Size = new Size(123, 78),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panel.Controls.Add(newLbl);
                TableItem_Context newTC = new TableItem_Context(newLbl,new Point(x,y));
                newTC.LabelClickedEvent += ProgramData.Form_TableEdit.TableItem_Clicked;
                createdLabel.Add(newLbl);
                table_current.Add(new Point(x, y), newTC);
            }
            
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
                if(!table_current.ContainsKey(new Point(x,y)))
                {
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
                    TableItem_Title newTT = new TableItem_Title(newLbl, (TimeSpan_Title)item,new Point(x,y));
                    newTT.LabelClickedEvent += ProgramData.Form_TableEdit.TableItem_Clicked;
                    table_current.Add(new Point(x, y), newTT);
                    panel.Controls.Add(newLbl);
                }
            }
            else
            {
                //创建context
                if (table_current.ContainsKey(new Point(x,y)))
                {
                    //已存在时,仅绘制信息
                    TableItem_Context ttmp = (TableItem_Context)table_current[new Point(x, y)];
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
                    TableItem_Context newTC = new TableItem_Context(newLbl,new TimeSpan_Context[] { (TimeSpan_Context)item }, new Point(x, y));
                    newTC.LabelClickedEvent += ProgramData.Form_TableEdit.TableItem_Clicked;
                    table_current.Add(new Point(x, y), newTC);
                    newTC.UpdateLableText();
                    panel.Controls.Add(newLbl);
                    createdLabel.Add(newLbl);
                }
            }
            

        }

        private void ClearTable()
        {
            if (createdLabel.Count == 0)
                return;
            foreach (var item in createdLabel)
            {
                //label执行清空处理
                item.Text = "";
            }
        }
    }
}
