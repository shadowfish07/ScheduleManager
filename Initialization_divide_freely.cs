using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace 日程管理生成系统
{
    public partial class Initialization_divide_freely : Form
    {
        public Initialization_divide_freely()
        {
            InitializeComponent();
        }

        private void mtxt_span_end_time_TextChanged(object sender, EventArgs e)
        {
            MaskedTextBox msender = (MaskedTextBox)sender;
            DealWithColor(msender);
            if (msender.Text.Length == 5 && msender.ForeColor == Color.Black && GetControlCount<GroupBox>() < 6 && Convert.ToInt32( msender.Tag.ToString().Substring(0,1))== GetControlCount<GroupBox>())
            {
                GroupBox newGb = new GroupBox()
                {
                    Text = (GetControlCount<GroupBox>() + 1).ToString(),
                    Size = new Size(256, 189),
                };
                groupBox1.Controls.Add(newGb);
                newGb.Location = GetControlLocation(typeof(GroupBox));

                Label newlbl1 = new Label
                {
                    Text = "区间" + newGb.Text + "开始时间",
                    Font = new Font(new FontFamily("微软雅黑"), (float)12.10084),
                    AutoSize = true,
                    Location = new Point(13, 26)
                };
                newGb.Controls.Add(newlbl1);

                Label newlbl2 = new Label
                {
                    Text = "区间" + newGb.Text + "结束时间",
                    Font = new Font(new FontFamily("微软雅黑"), (float)12.10084),
                    AutoSize = true,
                    Location = new Point(13, 69)
                };
                newGb.Controls.Add(newlbl2);

                Label newlbl3 = new Label
                {
                    Text = "区间" + newGb.Text + "描述（可选）",
                    Font = new Font(new FontFamily("微软雅黑"), (float)12.10084),
                    AutoSize = true,
                    Location = new Point(13, 114)
                };
                newGb.Controls.Add(newlbl3);

                MaskedTextBox newMtxt1 = new MaskedTextBox()
                {
                    Mask = "90:00",
                    Location = new Point(163, 23),
                    TextAlign = System.Windows.Forms.HorizontalAlignment.Center,
                    Font = new Font(new FontFamily("微软雅黑"), (float)12.10084),
                    Tag = newGb.Text+"s",
                    Size=new Size(68, 34)
                };
                newGb.Controls.Add(newMtxt1);
                newMtxt1.TextChanged += mtxt_span_begin_time_TextChanged;

                MaskedTextBox newMtxt2 = new MaskedTextBox()
                {
                    Mask = "90:00",
                    Location = new Point(163, 66),
                    TextAlign = System.Windows.Forms.HorizontalAlignment.Center,
                    Font = new Font(new FontFamily("微软雅黑"), (float)12.10084),
                    Tag = newGb.Text+"e",
                    Size = new Size(68, 34)
                };
                newGb.Controls.Add(newMtxt2);
                newMtxt2.TextChanged += mtxt_span_end_time_TextChanged;

                TextBox newTxt = new TextBox()
                {
                    Font = new Font(new FontFamily("微软雅黑"), (float)12.10084),
                    Location = new Point(18, 144),
                    Size=new Size(226, 34)
                };
                newGb.Controls.Add(newTxt);

                newMtxt1.Focus();

            }
        }

        private void mtxt_span_begin_time_TextChanged(object sender, EventArgs e)
        {
            MaskedTextBox msender = (MaskedTextBox)sender;
            DealWithColor(msender);
            if (msender.Text.Length == 5 && msender.ForeColor == Color.Black)
            {
                foreach (var item in msender.Parent.Controls.OfType<MaskedTextBox>())
                {
                    if (item != msender)
                        item.Focus();
                }
            }
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

        private Point GetControlLocation(Type type)
        {
            int base_x= 20;
            //const int COLUMN_NUM = 3;
            const int RAW_NUM = 2;
            const int RAW_INTERVAL = 207;
            const int COLUMN_INTERVAL = 286;
            const int BASE_Y = 17;
            MethodInfo mi = GetType().GetMethod("GetControlCount").MakeGenericMethod(type);
            int count = (int)mi.Invoke(this, null);
            int x = base_x + (count - 1) / RAW_NUM * COLUMN_INTERVAL;
            int y = BASE_Y + ((count - 1) % RAW_NUM) * RAW_INTERVAL;
            Point result = new Point(x, y);
            return result;

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

        private void SetTextVaildColorControl(bool isVaild, Control control)
        {
            if (isVaild)
                control.ForeColor = Color.Black;
            else
                control.ForeColor = Color.Red;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Action<string> Dofail = (error) =>
            {
                ProgramData.Table_List[0] = new Table("默认表", int.Parse(txt_maxiWeek.Text));
                MessageBox.Show(error);
            };
            System.Globalization.DateTimeFormatInfo dfi = new System.Globalization.DateTimeFormatInfo();
            dfi.ShortDatePattern = "HH:mm:ss";
            DateTime startTime=new DateTime();
            DateTime endTime= new DateTime();
            string describsion="";

                foreach (var item in groupBox1.Controls.OfType<GroupBox>())
                {
                    try
                    {
                        foreach (var _item in item.Controls.OfType<MaskedTextBox>())
                        {
                            if (item.ForeColor == Color.Red)
                            {
                            Dofail("提交失败：时间格式错误");
                            return;
                            }
                                
                            if (_item.Tag.ToString().Substring(1, 1) == "s")
                                startTime = Convert.ToDateTime(_item.Text, dfi);
                            else
                                endTime = Convert.ToDateTime(_item.Text, dfi);
                        }
                        foreach (var _item in item.Controls.OfType<TextBox>())
                        {
                            describsion = _item.Text;
                        }
                        if (!ProgramData.Table_List[0].AddTimeSpan_Title(startTime, endTime,describsion))
                        {
                            Dofail("提交失败：时间格式错误\n" + "请检查第" + item.Text + "项");
                            return;
                        }
                            
                        if (!TimeSpan_Title.CheckVaild(ProgramData.Table_List[0].GetTitileList(), out string error))
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
                TableEdit te = new TableEdit();
                te.Show();
        }
    }
}
