using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;

namespace 日程管理生成系统
{
    
    public partial class TableEdit : Form
    {

        TableDrawControl tbDrawer;

        /// <summary>
        /// 当前读取的列表项数据
        /// </summary>
        EnhancedList listBox_TimeSpan_Context;

        Table Table_DataSource;

        //存储TableItem的XY坐标，用来以坐标访问TableItem
        Dictionary<Point,TableItem> Current_Table = new Dictionary<Point, TableItem>();
        //当前打开的TableItem
        protected TableItem Current_TableItem;

        int currentWeek;

        public int CurrentWeek
        {
            get => currentWeek;
            set
            {
                currentWeek = value;
                lbl_week_index.Text = "第" + CurrentWeek.ToString() + "周";
            }
        }

        public TableEdit()
        {
            InitializeComponent();
            Table_DataSource = ProgramData.Table_List[0];
            Table_DataSource.HandleDayEvent += HandleDay_Handle;
            Table_DataSource.HandleWeekEvent += HandleWeek_Handle;
            CurrentWeek = 1;
        }



        public TableEdit(Table table)
        {
            InitializeComponent();
            Table_DataSource = table;
            Table_DataSource.HandleDayEvent += HandleDay_Handle;
            Table_DataSource.HandleWeekEvent += HandleWeek_Handle;
            CurrentWeek = 1;
        }

        private void HandleWeek_Handle(object sender, HandleDayOrWeekEventArgs e)
        {
            //若当前显示周中无该事件，自动跳转至有的周
            CurrentWeek= ((TimeSpan_Context)sender).InWeeks[0];
            //刷新列表将在btn_SaveContext_Click中完成
        }

        private void HandleDay_Handle(object sender, HandleDayOrWeekEventArgs e)
        {
            if(e.Type==HandleDayOrWeekEventArgs.HandleType.add)
            {
                foreach (var item in Current_Table.Values)
                {
                    TableItem tableItem_Context = item;
                    if (tableItem_Context.Location.X == e.Value)
                        ((TableItem_Context)tableItem_Context).AddContext((TimeSpan_Context)sender);
                }
            }
            else if (e.Type==HandleDayOrWeekEventArgs.HandleType.remove)
            {
                foreach (var item in Current_Table.Values)
                {
                    TableItem tableItem_Context = item;
                    if (tableItem_Context.Location.X == e.Value)
                        ((TableItem_Context)tableItem_Context).RemoveContext((TimeSpan_Context)sender);
                }
                //TODO：若当前显示单元格中无该事件，自动跳转至有的单元格

            }
        }

        private void TableEdit_Load(object sender, EventArgs e)
        {
            //l.Remove(l.FindLast(t => t.Index1 == 1));
            listBox_TimeSpan_Context = new EnhancedList(listb_context,this);

            tbDrawer = new TableDrawControl(panel1, Current_Table, new Label[] { lbl_table_name, lbl_Mondy, lbl_Tuesday, lbl_Wednesday, lbl_Thusday, lbl_Friday, lbl_Saturday, lbl_Sunday });

            tbDrawer.CreatTable(Table_DataSource,CurrentWeek);

        }
        

        /// <summary>
        /// 为Listbox增加绑定了一个存储TimeSpan_Contest列表的类，支持通过选择的列表项获取TimeSpan_Contest
        /// </summary>
        /// TODO:貌似多余了，listbox似乎可以直接添加对象，只要再实现一下对象的ToString()?：：：：可以加点方法，不用代替
        class EnhancedList
        {
            TableEdit tableEdit;
            ListBox listbox;
            List<TimeSpan_Context> TcinList = new List<TimeSpan_Context>();

            public ListBox Listbox { get => listbox; set => listbox = value; }
            public List<TimeSpan_Context> TimeSpan_ContextInList { get => TcinList; set => TcinList = value; }


            /// <summary>
            /// 设置listbox的当前选择项
            /// </summary>
            /// <param name="index"></param>
            /// <param name="doClick">可选，为要执行Click事件的e参数</param>
            public void SetSelectedItem(int index,LabelClickedEventArgs args =null)
            {
                Listbox.SelectedIndex = index;
                if(args!=null) tableEdit.TableItem_Clicked(tableEdit.Current_TableItem,args);
            }

            public EnhancedList(ListBox listBox,TableEdit tableEdit)
            {
                this.tableEdit = tableEdit;
                Listbox = listBox;
            }

            public void Add(TimeSpan_Context timeSpan_Context)
            {
                Listbox.Items.Add(timeSpan_Context.Outline);
                TimeSpan_ContextInList.Add(timeSpan_Context);
            }

            public void Remove(TimeSpan_Context timeSpan_Context)
            {
                Listbox.Items.Remove(timeSpan_Context.Outline);
                TimeSpan_ContextInList.Remove(timeSpan_Context);
            }

            public void Clear()
            {
                Listbox.Items.Clear();
                TimeSpan_ContextInList.Clear();
            }

            /// <summary>
            /// 逐项读取一个内容表格项内的事件
            /// </summary>
            /// <param name="tableItem_Context"></param>
            public void ReadNewTableItemContexts(TableItem_Context tableItem_Context)
            {
                Clear();
                foreach (var item in tableItem_Context.GetTimeSpanList())
                {
                    Add(item);
                }
                if(listbox.Items.Count!=0) listbox.SelectedIndex = 0;
            }

            /// <summary>
            /// 返回当前选择的TimeSpan_Contest
            /// </summary>
            /// <returns></returns>
            public TimeSpan_Context GetCurrentTC()
            {
                return (TimeSpan_Context)TimeSpan_ContextInList[Listbox.SelectedIndex];
            }
        }

        /// <summary>
        /// 列表单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void list_Click(object sender, EventArgs e)
        {
            txt_outline_context.Text = listBox_TimeSpan_Context.GetCurrentTC().Outline;
            txt_describsion_context.Text = listBox_TimeSpan_Context.GetCurrentTC().Describsion;
            txt_bondDays.Text = listBox_TimeSpan_Context.GetCurrentTC().PrintDaysOrWeeks("days");
            txt_bondWeeks.Text = listBox_TimeSpan_Context.GetCurrentTC().PrintDaysOrWeeks("weeks");
            //枚举所有Title打印在绑定时间中
            cmb_timeSpan.Items.Clear();
            foreach (var item in listBox_TimeSpan_Context.GetCurrentTC().BelongTo_TimeSpan_Titles)
            {
                cmb_timeSpan.Items.Add(item.Outline);
            }
            cmb_timeSpan.Text = cmb_timeSpan.Items[0].ToString();
        }

        /// <summary>
        /// 处理日程表单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TableItem_Clicked(TableItem sender,LabelClickedEventArgs e)
        {
            Current_TableItem = sender;
            switch (e.Type)
            {
                case LabelClickedEventArgs.TableItemType.Title:
                    TableItem_Title tt = (TableItem_Title)sender;
                    DispayTitleInfo(tt);
                    break;
                case LabelClickedEventArgs.TableItemType.Context:
                    TableItem_Context tc = (TableItem_Context)sender;
                    tabControl1.SelectedTab = tp_Context;
                    listBox_TimeSpan_Context.ReadNewTableItemContexts(tc);

                    if (tc.IsEmpty())
                        NewContext(Current_TableItem);
                    else
                    {
                        txt_outline_context.Text = listBox_TimeSpan_Context.GetCurrentTC().Outline;
                        txt_describsion_context.Text = listBox_TimeSpan_Context.GetCurrentTC().Describsion;
                    }
                    cmb_timeSpan.Items.Clear();
                    //枚举所有Title打印在绑定时间中
                    for (int y = 0;Current_Table.ContainsKey(new Point(0,y));y++) 
                    {
                        TableItem_Title tt2 = (TableItem_Title)Current_Table[new Point(0, y)];
                        cmb_timeSpan.Items.Add(tt2.TimeSpan_Title.Outline);
                    }
                    cmb_timeSpan.Text = cmb_timeSpan.Items[0].ToString();
                    txt_bondDays.Text = listBox_TimeSpan_Context.GetCurrentTC().PrintDaysOrWeeks("days");
                    txt_bondWeeks.Text = listBox_TimeSpan_Context.GetCurrentTC().PrintDaysOrWeeks("weeks");

                    break;
                default:
                    break;
            }
        }

        private void DispayTitleInfo(TableItem_Title tt)
        {
            tabControl1.SelectedTab = tp_title;

            if(DateTime.Compare(tt.TimeSpan_Title.StartTime,Convert.ToDateTime("10:00"))<0)
                mtxt_begin_time.Text = "0"+ tt.TimeSpan_Title.StartTime.ToString("t");
            else
                mtxt_begin_time.Text = tt.TimeSpan_Title.StartTime.ToString("t");
            if (DateTime.Compare(tt.TimeSpan_Title.EndTime, Convert.ToDateTime("10:00")) < 0)
                mtxt_end_time.Text = "0"+ tt.TimeSpan_Title.EndTime.ToString("t");
            else
                mtxt_end_time.Text = tt.TimeSpan_Title.EndTime.ToString("t");

            txt_describsion_title.Text = tt.TimeSpan_Title.Describsion;
            txt_outline_title.Text = tt.TimeSpan_Title.Outline;
        }

        private bool IsTimeFormatVaild(string time)
        {
            int firstNum = 0;
            int secondNum = 0;
            int thirdNum = 0;
            try
            {
                int.TryParse(time.Substring(0, 1), out firstNum);
                int.TryParse(time.Substring(1, 1), out secondNum);
                int.TryParse(time.Substring(3, 1), out thirdNum);
            }
            catch (Exception)
            {
            }
            if (firstNum > 2)
            {
                return false ;
            }
            if (firstNum == 2 && secondNum > 3)
            {
                return false ;
            }

            if (thirdNum > 5)
            {
                return false ;
            }
            return true;
        }

        /// <summary>
        /// 新建事件单击处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addContext_Click(object sender, EventArgs e)
        {
            NewContext(Current_TableItem);
        }

        /// <summary>
        /// 创建一个TableItem中新的事件
        /// </summary>
        /// <param name="tableItem"></param>
        private void NewContext(TableItem tableItem)
        {
            TimeSpan_Context newTC = Table_DataSource.AddTimeSpan_Context(new int[] { tableItem.Location.X }, new int[] { CurrentWeek }, (TableItem_Title)Current_Table[new Point(0, tableItem.Location.Y)], (TableItem_Context)tableItem);
            newTC.Outline = "新建事件";
            listBox_TimeSpan_Context.Add(newTC);
            listBox_TimeSpan_Context.Listbox.SelectedIndex = listBox_TimeSpan_Context.Listbox.Items.Count - 1;

            //防止保存时值被误写
            txt_outline_context.Text = "新建事件";
            txt_describsion_context.Text = "";
            txt_bondDays.Text = newTC.PrintDaysOrWeeks("days");
            txt_bondWeeks.Text = newTC.PrintDaysOrWeeks("weeks");

            btn_SaveContext_Click(null, null);
        }

        /// <summary>
        /// 保存事件单击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveContext_Click(object sender, EventArgs e)
        {
            //TODO:功能应迁移至table类中的edit
            TimeSpan_Context tsc = listBox_TimeSpan_Context.GetCurrentTC();
            tsc.Describsion = txt_describsion_context.Text;
            tsc.Outline = txt_outline_context.Text;
            
            try
            {
                tsc.ReadDays(txt_bondDays.Text);
            }catch (ArgumentException){}


            try
            {
                tsc.ReadWeeks(txt_bondWeeks.Text);
            }
            catch (ArgumentException) {}
            listBox_TimeSpan_Context.Listbox.Items[listBox_TimeSpan_Context.Listbox.SelectedIndex] = tsc.Outline;
            //刷新表格
            tbDrawer.CreatTable(Table_DataSource, CurrentWeek);
        }
        /// <summary>
        /// 删除时间段单击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_deleteTimeSpan_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 新建时间段单击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addNewTimeSpan_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 保存时间段单击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveTimeSpan_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 复制事件单击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_copyContext_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 删除事件单击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_deleteContext_Click(object sender, EventArgs e)
        {
            Table_DataSource.RemoveTimeSpan_Context(listBox_TimeSpan_Context.GetCurrentTC().ID);
            listBox_TimeSpan_Context.Remove(listBox_TimeSpan_Context.GetCurrentTC());
            if(listBox_TimeSpan_Context.Listbox.Items.Count==0)
            {
                NewContext(Current_TableItem);
            }
            else
            {
                listBox_TimeSpan_Context.SetSelectedItem(0, new LabelClickedEventArgs(Current_TableItem));
            }
            //刷新表格
            tbDrawer.CreatTable(Table_DataSource, CurrentWeek);
        }

        private void TableEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_preWeek_Click(object sender, EventArgs e)
        {
            if (CurrentWeek == 2)
            {
                btn_preWeek.Visible = false;
            } 
            btn_NextWeek.Visible = true;
            CurrentWeek--;
            tbDrawer.CreatTable(Table_DataSource, CurrentWeek);
        }

        private void btn_NextWeek_Click(object sender, EventArgs e)
        {
            if (CurrentWeek == Table_DataSource.MaxiWeek - 1)
            {
                btn_NextWeek.Visible = false;
            }
            btn_preWeek.Visible = true;
            CurrentWeek++;
            tbDrawer.CreatTable(Table_DataSource, CurrentWeek);
        }

        private void ReadCurrentWeekTable()
        {

        }
    }
}
