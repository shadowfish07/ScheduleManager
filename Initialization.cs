using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 日程管理生成系统
{
    public partial class Initialization : Form
    {
        public Initialization()
        {
            InitializeComponent();
        }

        private void btn_divide_by_class_Click(object sender, EventArgs e)
        {
            Initialization_divide_by_class fc = new Initialization_divide_by_class();
            fc.Show();
            Hide();
        }

        private void btn_divide_freely_Click(object sender, EventArgs e)
        {
            Initialization_divide_freely ff = new Initialization_divide_freely();
            ff.Show();
            Hide();
        }
    }
}
