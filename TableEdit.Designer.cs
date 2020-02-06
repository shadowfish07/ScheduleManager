namespace 日程管理生成系统
{
    partial class TableEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_preWeek = new System.Windows.Forms.Button();
            this.btn_NextWeek = new System.Windows.Forms.Button();
            this.lbl_Sunday = new System.Windows.Forms.Label();
            this.lbl_Saturday = new System.Windows.Forms.Label();
            this.lbl_Friday = new System.Windows.Forms.Label();
            this.lbl_Thusday = new System.Windows.Forms.Label();
            this.lbl_Wednesday = new System.Windows.Forms.Label();
            this.lbl_Tuesday = new System.Windows.Forms.Label();
            this.lbl_Mondy = new System.Windows.Forms.Label();
            this.lbl_table_name = new System.Windows.Forms.Label();
            this.lbl_week_index = new System.Windows.Forms.Label();
            this.btn_NewTable = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_title = new System.Windows.Forms.TabPage();
            this.btn_SaveTimeSpan = new System.Windows.Forms.Button();
            this.btn_deleteTimeSpan = new System.Windows.Forms.Button();
            this.btn_addNewTimeSpan = new System.Windows.Forms.Button();
            this.txt_describsion_title = new System.Windows.Forms.TextBox();
            this.txt_outline_title = new System.Windows.Forms.TextBox();
            this.mtxt_end_time = new System.Windows.Forms.MaskedTextBox();
            this.mtxt_begin_time = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tp_Context = new System.Windows.Forms.TabPage();
            this.btn_copyContext = new System.Windows.Forms.Button();
            this.btn_SaveContext = new System.Windows.Forms.Button();
            this.btn_deleteContext = new System.Windows.Forms.Button();
            this.btn_addContext = new System.Windows.Forms.Button();
            this.cmb_timeSpan = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_bondDays = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_bondWeeks = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_describsion_context = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listb_context = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_outline_context = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tp_title.SuspendLayout();
            this.tp_Context.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btn_preWeek);
            this.panel1.Controls.Add(this.btn_NextWeek);
            this.panel1.Controls.Add(this.lbl_Sunday);
            this.panel1.Controls.Add(this.lbl_Saturday);
            this.panel1.Controls.Add(this.lbl_Friday);
            this.panel1.Controls.Add(this.lbl_Thusday);
            this.panel1.Controls.Add(this.lbl_Wednesday);
            this.panel1.Controls.Add(this.lbl_Tuesday);
            this.panel1.Controls.Add(this.lbl_Mondy);
            this.panel1.Controls.Add(this.lbl_table_name);
            this.panel1.Controls.Add(this.lbl_week_index);
            this.panel1.Location = new System.Drawing.Point(9, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 577);
            this.panel1.TabIndex = 0;
            // 
            // btn_preWeek
            // 
            this.btn_preWeek.Font = new System.Drawing.Font("微软雅黑", 12.10084F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_preWeek.Location = new System.Drawing.Point(9, 3);
            this.btn_preWeek.Name = "btn_preWeek";
            this.btn_preWeek.Size = new System.Drawing.Size(38, 44);
            this.btn_preWeek.TabIndex = 10;
            this.btn_preWeek.Text = "<";
            this.btn_preWeek.UseVisualStyleBackColor = true;
            this.btn_preWeek.Visible = false;
            this.btn_preWeek.Click += new System.EventHandler(this.btn_preWeek_Click);
            // 
            // btn_NextWeek
            // 
            this.btn_NextWeek.Font = new System.Drawing.Font("微软雅黑", 12.10084F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_NextWeek.Location = new System.Drawing.Point(1011, 3);
            this.btn_NextWeek.Name = "btn_NextWeek";
            this.btn_NextWeek.Size = new System.Drawing.Size(38, 44);
            this.btn_NextWeek.TabIndex = 9;
            this.btn_NextWeek.Text = ">";
            this.btn_NextWeek.UseVisualStyleBackColor = true;
            this.btn_NextWeek.Click += new System.EventHandler(this.btn_NextWeek_Click);
            // 
            // lbl_Sunday
            // 
            this.lbl_Sunday.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Sunday.Location = new System.Drawing.Point(913, 50);
            this.lbl_Sunday.Name = "lbl_Sunday";
            this.lbl_Sunday.Size = new System.Drawing.Size(123, 51);
            this.lbl_Sunday.TabIndex = 8;
            this.lbl_Sunday.Text = "星期日";
            this.lbl_Sunday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Saturday
            // 
            this.lbl_Saturday.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Saturday.Location = new System.Drawing.Point(784, 50);
            this.lbl_Saturday.Name = "lbl_Saturday";
            this.lbl_Saturday.Size = new System.Drawing.Size(123, 51);
            this.lbl_Saturday.TabIndex = 7;
            this.lbl_Saturday.Text = "星期六";
            this.lbl_Saturday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Friday
            // 
            this.lbl_Friday.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Friday.Location = new System.Drawing.Point(651, 50);
            this.lbl_Friday.Name = "lbl_Friday";
            this.lbl_Friday.Size = new System.Drawing.Size(123, 51);
            this.lbl_Friday.TabIndex = 6;
            this.lbl_Friday.Text = "星期五";
            this.lbl_Friday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Thusday
            // 
            this.lbl_Thusday.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Thusday.Location = new System.Drawing.Point(520, 50);
            this.lbl_Thusday.Name = "lbl_Thusday";
            this.lbl_Thusday.Size = new System.Drawing.Size(123, 51);
            this.lbl_Thusday.TabIndex = 5;
            this.lbl_Thusday.Text = "星期四";
            this.lbl_Thusday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Wednesday
            // 
            this.lbl_Wednesday.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Wednesday.Location = new System.Drawing.Point(389, 50);
            this.lbl_Wednesday.Name = "lbl_Wednesday";
            this.lbl_Wednesday.Size = new System.Drawing.Size(123, 51);
            this.lbl_Wednesday.TabIndex = 4;
            this.lbl_Wednesday.Text = "星期三";
            this.lbl_Wednesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Tuesday
            // 
            this.lbl_Tuesday.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Tuesday.Location = new System.Drawing.Point(258, 50);
            this.lbl_Tuesday.Name = "lbl_Tuesday";
            this.lbl_Tuesday.Size = new System.Drawing.Size(123, 51);
            this.lbl_Tuesday.TabIndex = 3;
            this.lbl_Tuesday.Text = "星期二";
            this.lbl_Tuesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Mondy
            // 
            this.lbl_Mondy.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Mondy.Location = new System.Drawing.Point(127, 50);
            this.lbl_Mondy.Name = "lbl_Mondy";
            this.lbl_Mondy.Size = new System.Drawing.Size(123, 51);
            this.lbl_Mondy.TabIndex = 2;
            this.lbl_Mondy.Text = "星期一";
            this.lbl_Mondy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_table_name
            // 
            this.lbl_table_name.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_table_name.Location = new System.Drawing.Point(-4, 50);
            this.lbl_table_name.Name = "lbl_table_name";
            this.lbl_table_name.Size = new System.Drawing.Size(123, 51);
            this.lbl_table_name.TabIndex = 1;
            this.lbl_table_name.Text = "Table_Name";
            this.lbl_table_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_week_index
            // 
            this.lbl_week_index.BackColor = System.Drawing.Color.Snow;
            this.lbl_week_index.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_week_index.Font = new System.Drawing.Font("微软雅黑", 24.20168F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_week_index.Location = new System.Drawing.Point(0, 0);
            this.lbl_week_index.Name = "lbl_week_index";
            this.lbl_week_index.Size = new System.Drawing.Size(1062, 50);
            this.lbl_week_index.TabIndex = 0;
            this.lbl_week_index.Text = "第1周";
            this.lbl_week_index.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_NewTable
            // 
            this.btn_NewTable.AccessibleDescription = "";
            this.btn_NewTable.Location = new System.Drawing.Point(889, 28);
            this.btn_NewTable.Name = "btn_NewTable";
            this.btn_NewTable.Size = new System.Drawing.Size(144, 39);
            this.btn_NewTable.TabIndex = 1;
            this.btn_NewTable.Text = "新建日程表";
            this.btn_NewTable.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleDescription = "";
            this.btn_Save.Location = new System.Drawing.Point(889, 85);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(144, 39);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "保存日程表";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_title);
            this.tabControl1.Controls.Add(this.tp_Context);
            this.tabControl1.Location = new System.Drawing.Point(18, -28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(852, 215);
            this.tabControl1.TabIndex = 3;
            // 
            // tp_title
            // 
            this.tp_title.AccessibleDescription = "s";
            this.tp_title.BackColor = System.Drawing.SystemColors.Control;
            this.tp_title.Controls.Add(this.btn_SaveTimeSpan);
            this.tp_title.Controls.Add(this.btn_deleteTimeSpan);
            this.tp_title.Controls.Add(this.btn_addNewTimeSpan);
            this.tp_title.Controls.Add(this.txt_describsion_title);
            this.tp_title.Controls.Add(this.txt_outline_title);
            this.tp_title.Controls.Add(this.mtxt_end_time);
            this.tp_title.Controls.Add(this.mtxt_begin_time);
            this.tp_title.Controls.Add(this.label4);
            this.tp_title.Controls.Add(this.label3);
            this.tp_title.Controls.Add(this.label2);
            this.tp_title.Controls.Add(this.label1);
            this.tp_title.Location = new System.Drawing.Point(4, 29);
            this.tp_title.Name = "tp_title";
            this.tp_title.Padding = new System.Windows.Forms.Padding(3);
            this.tp_title.Size = new System.Drawing.Size(844, 182);
            this.tp_title.TabIndex = 0;
            this.tp_title.Text = "tabPage1";
            // 
            // btn_SaveTimeSpan
            // 
            this.btn_SaveTimeSpan.Location = new System.Drawing.Point(714, 31);
            this.btn_SaveTimeSpan.Name = "btn_SaveTimeSpan";
            this.btn_SaveTimeSpan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_SaveTimeSpan.Size = new System.Drawing.Size(109, 31);
            this.btn_SaveTimeSpan.TabIndex = 16;
            this.btn_SaveTimeSpan.Text = "保存时间段";
            this.btn_SaveTimeSpan.UseVisualStyleBackColor = true;
            this.btn_SaveTimeSpan.Click += new System.EventHandler(this.btn_SaveTimeSpan_Click);
            // 
            // btn_deleteTimeSpan
            // 
            this.btn_deleteTimeSpan.Location = new System.Drawing.Point(714, 103);
            this.btn_deleteTimeSpan.Name = "btn_deleteTimeSpan";
            this.btn_deleteTimeSpan.Size = new System.Drawing.Size(109, 31);
            this.btn_deleteTimeSpan.TabIndex = 15;
            this.btn_deleteTimeSpan.Text = "删除时间段";
            this.btn_deleteTimeSpan.UseVisualStyleBackColor = true;
            this.btn_deleteTimeSpan.Click += new System.EventHandler(this.btn_deleteTimeSpan_Click);
            // 
            // btn_addNewTimeSpan
            // 
            this.btn_addNewTimeSpan.Location = new System.Drawing.Point(714, 67);
            this.btn_addNewTimeSpan.Name = "btn_addNewTimeSpan";
            this.btn_addNewTimeSpan.Size = new System.Drawing.Size(109, 31);
            this.btn_addNewTimeSpan.TabIndex = 14;
            this.btn_addNewTimeSpan.Text = "新增时间段";
            this.btn_addNewTimeSpan.UseVisualStyleBackColor = true;
            this.btn_addNewTimeSpan.Click += new System.EventHandler(this.btn_addNewTimeSpan_Click);
            // 
            // txt_describsion_title
            // 
            this.txt_describsion_title.Location = new System.Drawing.Point(410, 11);
            this.txt_describsion_title.Multiline = true;
            this.txt_describsion_title.Name = "txt_describsion_title";
            this.txt_describsion_title.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_describsion_title.Size = new System.Drawing.Size(257, 158);
            this.txt_describsion_title.TabIndex = 13;
            // 
            // txt_outline_title
            // 
            this.txt_outline_title.Location = new System.Drawing.Point(90, 87);
            this.txt_outline_title.Name = "txt_outline_title";
            this.txt_outline_title.Size = new System.Drawing.Size(241, 27);
            this.txt_outline_title.TabIndex = 12;
            // 
            // mtxt_end_time
            // 
            this.mtxt_end_time.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mtxt_end_time.Location = new System.Drawing.Point(90, 46);
            this.mtxt_end_time.Mask = "90:00";
            this.mtxt_end_time.Name = "mtxt_end_time";
            this.mtxt_end_time.Size = new System.Drawing.Size(77, 27);
            this.mtxt_end_time.TabIndex = 11;
            this.mtxt_end_time.Tag = "1";
            this.mtxt_end_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_end_time.ValidatingType = typeof(System.DateTime);
            // 
            // mtxt_begin_time
            // 
            this.mtxt_begin_time.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mtxt_begin_time.Location = new System.Drawing.Point(90, 8);
            this.mtxt_begin_time.Mask = "90:00";
            this.mtxt_begin_time.Name = "mtxt_begin_time";
            this.mtxt_begin_time.Size = new System.Drawing.Size(77, 27);
            this.mtxt_begin_time.TabIndex = 10;
            this.mtxt_begin_time.Tag = "1";
            this.mtxt_begin_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_begin_time.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "详细描述";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "概述";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "结束时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间";
            // 
            // tp_Context
            // 
            this.tp_Context.BackColor = System.Drawing.SystemColors.Control;
            this.tp_Context.Controls.Add(this.btn_copyContext);
            this.tp_Context.Controls.Add(this.btn_SaveContext);
            this.tp_Context.Controls.Add(this.btn_deleteContext);
            this.tp_Context.Controls.Add(this.btn_addContext);
            this.tp_Context.Controls.Add(this.cmb_timeSpan);
            this.tp_Context.Controls.Add(this.label10);
            this.tp_Context.Controls.Add(this.txt_bondDays);
            this.tp_Context.Controls.Add(this.label9);
            this.tp_Context.Controls.Add(this.txt_bondWeeks);
            this.tp_Context.Controls.Add(this.label8);
            this.tp_Context.Controls.Add(this.txt_describsion_context);
            this.tp_Context.Controls.Add(this.label7);
            this.tp_Context.Controls.Add(this.label6);
            this.tp_Context.Controls.Add(this.listb_context);
            this.tp_Context.Controls.Add(this.label5);
            this.tp_Context.Controls.Add(this.txt_outline_context);
            this.tp_Context.Location = new System.Drawing.Point(4, 29);
            this.tp_Context.Name = "tp_Context";
            this.tp_Context.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Context.Size = new System.Drawing.Size(844, 182);
            this.tp_Context.TabIndex = 1;
            this.tp_Context.Text = "tabPage2";
            // 
            // btn_copyContext
            // 
            this.btn_copyContext.Location = new System.Drawing.Point(748, 90);
            this.btn_copyContext.Name = "btn_copyContext";
            this.btn_copyContext.Size = new System.Drawing.Size(81, 30);
            this.btn_copyContext.TabIndex = 28;
            this.btn_copyContext.Text = "复制事件";
            this.btn_copyContext.UseVisualStyleBackColor = true;
            this.btn_copyContext.Click += new System.EventHandler(this.btn_copyContext_Click);
            // 
            // btn_SaveContext
            // 
            this.btn_SaveContext.Location = new System.Drawing.Point(748, 20);
            this.btn_SaveContext.Name = "btn_SaveContext";
            this.btn_SaveContext.Size = new System.Drawing.Size(81, 30);
            this.btn_SaveContext.TabIndex = 27;
            this.btn_SaveContext.Text = "保存事件";
            this.btn_SaveContext.UseVisualStyleBackColor = true;
            this.btn_SaveContext.Click += new System.EventHandler(this.btn_SaveContext_Click);
            // 
            // btn_deleteContext
            // 
            this.btn_deleteContext.Location = new System.Drawing.Point(748, 125);
            this.btn_deleteContext.Name = "btn_deleteContext";
            this.btn_deleteContext.Size = new System.Drawing.Size(81, 30);
            this.btn_deleteContext.TabIndex = 26;
            this.btn_deleteContext.Text = "删除事件";
            this.btn_deleteContext.UseVisualStyleBackColor = true;
            this.btn_deleteContext.Click += new System.EventHandler(this.btn_deleteContext_Click);
            // 
            // btn_addContext
            // 
            this.btn_addContext.Location = new System.Drawing.Point(748, 55);
            this.btn_addContext.Name = "btn_addContext";
            this.btn_addContext.Size = new System.Drawing.Size(81, 30);
            this.btn_addContext.TabIndex = 25;
            this.btn_addContext.Text = "新建事件";
            this.btn_addContext.UseVisualStyleBackColor = true;
            this.btn_addContext.Click += new System.EventHandler(this.btn_addContext_Click);
            // 
            // cmb_timeSpan
            // 
            this.cmb_timeSpan.FormattingEnabled = true;
            this.cmb_timeSpan.Location = new System.Drawing.Point(248, 6);
            this.cmb_timeSpan.Name = "cmb_timeSpan";
            this.cmb_timeSpan.Size = new System.Drawing.Size(191, 28);
            this.cmb_timeSpan.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(173, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "绑定时间";
            // 
            // txt_bondDays
            // 
            this.txt_bondDays.Location = new System.Drawing.Point(249, 101);
            this.txt_bondDays.Name = "txt_bondDays";
            this.txt_bondDays.Size = new System.Drawing.Size(190, 27);
            this.txt_bondDays.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "绑定星期";
            // 
            // txt_bondWeeks
            // 
            this.txt_bondWeeks.Location = new System.Drawing.Point(249, 54);
            this.txt_bondWeeks.Name = "txt_bondWeeks";
            this.txt_bondWeeks.Size = new System.Drawing.Size(190, 27);
            this.txt_bondWeeks.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(174, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "绑定周数";
            // 
            // txt_describsion_context
            // 
            this.txt_describsion_context.Location = new System.Drawing.Point(520, 38);
            this.txt_describsion_context.Multiline = true;
            this.txt_describsion_context.Name = "txt_describsion_context";
            this.txt_describsion_context.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_describsion_context.Size = new System.Drawing.Size(211, 131);
            this.txt_describsion_context.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(445, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "详细说明";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(445, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "概述";
            // 
            // listb_context
            // 
            this.listb_context.FormattingEnabled = true;
            this.listb_context.ItemHeight = 20;
            this.listb_context.Location = new System.Drawing.Point(10, 31);
            this.listb_context.Name = "listb_context";
            this.listb_context.Size = new System.Drawing.Size(154, 124);
            this.listb_context.TabIndex = 15;
            this.listb_context.Click += new System.EventHandler(this.list_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "事件";
            // 
            // txt_outline_context
            // 
            this.txt_outline_context.Location = new System.Drawing.Point(520, 5);
            this.txt_outline_context.Name = "txt_outline_context";
            this.txt_outline_context.Size = new System.Drawing.Size(211, 27);
            this.txt_outline_context.TabIndex = 13;
            // 
            // TableEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 770);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_NewTable);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TableEdit";
            this.Text = "日志管理生成系统——日程表编辑";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TableEdit_FormClosed);
            this.Load += new System.EventHandler(this.TableEdit_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tp_title.ResumeLayout(false);
            this.tp_title.PerformLayout();
            this.tp_Context.ResumeLayout(false);
            this.tp_Context.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Sunday;
        private System.Windows.Forms.Label lbl_Saturday;
        private System.Windows.Forms.Label lbl_Friday;
        private System.Windows.Forms.Label lbl_Thusday;
        private System.Windows.Forms.Label lbl_Wednesday;
        private System.Windows.Forms.Label lbl_Tuesday;
        private System.Windows.Forms.Label lbl_Mondy;
        private System.Windows.Forms.Label lbl_table_name;
        private System.Windows.Forms.Label lbl_week_index;
        private System.Windows.Forms.Button btn_NewTable;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_title;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tp_Context;
        private System.Windows.Forms.TextBox txt_describsion_title;
        private System.Windows.Forms.TextBox txt_outline_title;
        private System.Windows.Forms.MaskedTextBox mtxt_end_time;
        private System.Windows.Forms.MaskedTextBox mtxt_begin_time;
        private System.Windows.Forms.ComboBox cmb_timeSpan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_bondDays;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_bondWeeks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_describsion_context;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listb_context;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_outline_context;
        private System.Windows.Forms.Button btn_preWeek;
        private System.Windows.Forms.Button btn_NextWeek;
        private System.Windows.Forms.Button btn_deleteTimeSpan;
        private System.Windows.Forms.Button btn_addNewTimeSpan;
        private System.Windows.Forms.Button btn_deleteContext;
        private System.Windows.Forms.Button btn_SaveTimeSpan;
        private System.Windows.Forms.Button btn_SaveContext;
        private System.Windows.Forms.Button btn_addContext;
        private System.Windows.Forms.Button btn_copyContext;
    }
}