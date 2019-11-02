using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace 日程管理生成系统
{
    public partial class TableEdit : Form
    {
        public TableEdit()
        {
            InitializeComponent();
        }
        private void TableEdit_Load(object sender, EventArgs e)
        {
            //l.Remove(l.FindLast(t => t.Index1 == 1));

            TableDrawControl tbDrawer = new TableDrawControl(panel1, ProgramData.Table_List[0], new Label[] { lbl_table_name, lbl_Mondy, lbl_Tuesday, lbl_Wednesday, lbl_Thusday, lbl_Friday, lbl_Saturday, lbl_Sunday });
            tbDrawer.CreatTable();

        }
    }
}
