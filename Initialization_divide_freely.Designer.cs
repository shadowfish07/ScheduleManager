namespace 日程管理生成系统
{
    partial class Initialization_divide_freely
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mtxt_span_end_time = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mtxt_span_begin_time = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("微软雅黑", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Location = new System.Drawing.Point(346, 676);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(262, 48);
            this.btn_ok.TabIndex = 14;
            this.btn_ok.Text = "提     交";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(33, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(873, 426);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.73109F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(27, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 35);
            this.label3.TabIndex = 12;
            this.label3.Text = "2.请输入具体计划信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 21.78151F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(25, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(704, 46);
            this.label2.TabIndex = 11;
            this.label2.Text = "在开始自律前，先告诉我一些基本信息吧！";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 41.7479F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(670, 89);
            this.label1.TabIndex = 10;
            this.label1.Text = "YO~第一次使用呀！";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.mtxt_span_end_time);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.mtxt_span_begin_time);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(20, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 189);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12.10084F);
            this.textBox1.Location = new System.Drawing.Point(18, 144);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 34);
            this.textBox1.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(13, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 27);
            this.label5.TabIndex = 18;
            this.label5.Text = "区间1描述（可选）";
            // 
            // mtxt_span_end_time
            // 
            this.mtxt_span_end_time.Font = new System.Drawing.Font("微软雅黑", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mtxt_span_end_time.Location = new System.Drawing.Point(163, 66);
            this.mtxt_span_end_time.Mask = "90:00";
            this.mtxt_span_end_time.Name = "mtxt_span_end_time";
            this.mtxt_span_end_time.Size = new System.Drawing.Size(68, 34);
            this.mtxt_span_end_time.TabIndex = 17;
            this.mtxt_span_end_time.Tag = "1e";
            this.mtxt_span_end_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_span_end_time.ValidatingType = typeof(System.DateTime);
            this.mtxt_span_end_time.TextChanged += new System.EventHandler(this.mtxt_span_end_time_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(13, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 27);
            this.label4.TabIndex = 16;
            this.label4.Text = "区间1结束时间";
            // 
            // mtxt_span_begin_time
            // 
            this.mtxt_span_begin_time.Font = new System.Drawing.Font("微软雅黑", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mtxt_span_begin_time.Location = new System.Drawing.Point(163, 23);
            this.mtxt_span_begin_time.Mask = "90:00";
            this.mtxt_span_begin_time.Name = "mtxt_span_begin_time";
            this.mtxt_span_begin_time.Size = new System.Drawing.Size(68, 34);
            this.mtxt_span_begin_time.TabIndex = 15;
            this.mtxt_span_begin_time.Tag = "1s";
            this.mtxt_span_begin_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_span_begin_time.ValidatingType = typeof(System.DateTime);
            this.mtxt_span_begin_time.TextChanged += new System.EventHandler(this.mtxt_span_begin_time_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12.10084F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(13, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 27);
            this.label6.TabIndex = 14;
            this.label6.Text = "区间1开始时间";
            // 
            // Initialization_divide_freely
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 735);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Initialization_divide_freely";
            this.Text = "Initialization_divide_freely";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mtxt_span_end_time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtxt_span_begin_time;
        private System.Windows.Forms.Label label6;
    }
}