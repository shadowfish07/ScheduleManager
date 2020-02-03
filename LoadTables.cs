using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 日程管理生成系统
{
    public partial class LoadTables : Form
    {
        public LoadTables()
        {
            InitializeComponent();
        }

        private void LoadTables_Load(object sender, EventArgs e)
        {
        }

        private void LoadTables_Shown(object sender, EventArgs e)
        {
            if (!Directory.Exists("Data.xml"))
            {
                Hide();
                Initialization intf = new Initialization();
                intf.Show();
            }
        }

        private void ReadDicTableFiles()
        {
            
        }
    }
}
