using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace 日程管理生成系统
{
    public partial class Initialization_divide_by_class : Form
    {
        private const int OTHER_LABLE_IN_GRUOP = 2;
        //private List<MaskedTextBox> listMtxt;

        public Initialization_divide_by_class()
        {
            InitializeComponent();
        }

        private void mtxt_class_begin_time_TextChanged(object sender, EventArgs e)
        {
            MaskedTextBox msender = (MaskedTextBox)sender;
            DealWithColor(msender);
            if (msender.Text.Length==5 && msender.ForeColor==Color.Black && GetControlCount<Label>()<=19 && Convert.ToInt32(msender.Tag.ToString()) == GetControlCount<MaskedTextBox>())
            {
                MaskedTextBox newMtxt = new MaskedTextBox
                {
                    Mask = "90:00",
                    Size = new Size(68, 34),
                    TextAlign = System.Windows.Forms.HorizontalAlignment.Center,
                    Font=new Font(new FontFamily("微软雅黑"), (float)12.10084),
                    Tag=GetControlCount<MaskedTextBox>()+1
                };
                groupBox1.Controls.Add(newMtxt);
                newMtxt.Location = GetControlLocation(newMtxt.GetType());
                newMtxt.TextChanged += mtxt_class_begin_time_TextChanged;

                Label newLabel = new Label
                {
                    AutoSize=true,
                    Text = "第" + (GetControlCount<Label>()- OTHER_LABLE_IN_GRUOP+1).ToString() + "节课开始时间",
                    Font = new Font(new FontFamily("微软雅黑"), (float)12.10084)
                };
                groupBox1.Controls.Add(newLabel);
                newLabel.Location = GetControlLocation(newLabel.GetType());

                newMtxt.Focus();
            }
        }

        private Point GetControlLocation(Type type)
        {
            int base_x;
            if (type == typeof(MaskedTextBox))
                base_x = 220;
            else if (type == typeof(Label))
                base_x = 43;
            else
                base_x = 0;
            //const int COLUMN_NUM = 3;
            const int RAW_NUM = 6;
            const int RAW_INTERVAL = 59;
            const int COLUMN_INTERVAL = 283;
            const int BASE_Y = 82;
            MethodInfo mi = GetType().GetMethod("GetControlCount").MakeGenericMethod(type);
            int count = (int) mi.Invoke(this,null);
            count = type == typeof(Label) ? count - OTHER_LABLE_IN_GRUOP : count;
            int x = base_x + (count-1) / RAW_NUM * COLUMN_INTERVAL;
            int y = BASE_Y + ((count-1) % RAW_NUM) * RAW_INTERVAL;
            Point result = new Point(x, y);
            return result;

        }

        public int GetControlCount<T>()
        {
            int count = 0;
            foreach (var item in groupBox1.Controls.OfType<T>())
            {
                count++;
            }

            return count;
        }

        private void DealWithColor(MaskedTextBox sender)
        {
            int firstNum = 0;
            int secondNum = 0;
            int thirdNum = 0;
            try
            {
                int.TryParse(sender.Text.Substring(0, 1), out firstNum);
                int.TryParse(sender.Text.Substring(1, 1), out secondNum);
                int.TryParse(sender.Text.Substring(3, 1), out thirdNum);
            }
            catch (Exception)
            {
            }

            if (firstNum > 2)
            {
                SetTextVaildColorControl(false, sender);
                return;
            }
            if (firstNum == 2 && secondNum > 3)
            {
                SetTextVaildColorControl(false, sender);
                return;
            }

            if (thirdNum > 5)
            {
                SetTextVaildColorControl(false, sender);
                return;
            }
            SetTextVaildColorControl(true, sender);
        }

        private void SetTextVaildColorControl(bool isVaild,Control control)
        {
            if (isVaild)
                control.ForeColor = Color.Black;
            else
                control.ForeColor = Color.Red;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Action<string> Dofail =(error)=>
            {
                ProgramData.Table_List[0] = new Table("默认表",int.Parse( txt_maxiWeek.Text));
                MessageBox.Show(error);
                return;
            };

            foreach (var item in groupBox1.Controls.OfType<MaskedTextBox>())
            {
                System.Globalization.DateTimeFormatInfo dfi = new System.Globalization.DateTimeFormatInfo();
                dfi.ShortDatePattern = "HH:mm:ss";
                try
                {
                    if (item.ForeColor == Color.Red)
                    {
                        Dofail("提交失败：时间格式错误");
                        return;
                    }
                    DateTime startTime = Convert.ToDateTime(item.Text, dfi);
                    DateTime endTime = startTime.AddMinutes(int.Parse(txt_class_length.Text));
                    ProgramData.Table_List[0].AddTimeSpan_Title(startTime, endTime, "第" + item.Tag + "节课");
                        
                    if (!TimeSpan_Title.CheckVaild(ProgramData.Table_List[0].GetTitileList(), out string  error))
                    {
                        Dofail("提交失败：存在冲突的时间\n" + error);
                        return;
                    }
                }
                catch (Exception){}
            }
            Hide();

            XMLManager x = new XMLManager(ProgramData.Table_List[0].TableName);
            x.WriteXmlBniary(ProgramData.Table_List[0]);

            ProgramData.Form_TableEdit.Show();
        }
    }
}
