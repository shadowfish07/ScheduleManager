namespace 日程管理生成系统
{
    partial class Initialization
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_divide_by_class = new System.Windows.Forms.Button();
            this.btn_divide_freely = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 41.7479F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(670, 89);
            this.label1.TabIndex = 0;
            this.label1.Text = "YO~第一次使用呀！";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 21.78151F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(704, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "在开始自律前，先告诉我一些基本信息吧！";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.73109F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(530, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "1.你要按照课时划分一天，还是自由划分呢？";
            // 
            // btn_divide_by_class
            // 
            this.btn_divide_by_class.Font = new System.Drawing.Font("微软雅黑", 15.73109F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_divide_by_class.Location = new System.Drawing.Point(101, 294);
            this.btn_divide_by_class.Name = "btn_divide_by_class";
            this.btn_divide_by_class.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_divide_by_class.Size = new System.Drawing.Size(221, 202);
            this.btn_divide_by_class.TabIndex = 3;
            this.btn_divide_by_class.Text = "按课时划分";
            this.btn_divide_by_class.UseVisualStyleBackColor = true;
            this.btn_divide_by_class.Click += new System.EventHandler(this.btn_divide_by_class_Click);
            // 
            // btn_divide_freely
            // 
            this.btn_divide_freely.Font = new System.Drawing.Font("微软雅黑", 15.73109F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_divide_freely.Location = new System.Drawing.Point(439, 294);
            this.btn_divide_freely.Name = "btn_divide_freely";
            this.btn_divide_freely.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_divide_freely.Size = new System.Drawing.Size(221, 202);
            this.btn_divide_freely.TabIndex = 4;
            this.btn_divide_freely.Text = "自由划分";
            this.btn_divide_freely.UseVisualStyleBackColor = true;
            this.btn_divide_freely.Click += new System.EventHandler(this.btn_divide_freely_Click);
            // 
            // Initialization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 546);
            this.Controls.Add(this.btn_divide_freely);
            this.Controls.Add(this.btn_divide_by_class);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Initialization";
            this.Text = "Initialization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Initialization_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_divide_by_class;
        private System.Windows.Forms.Button btn_divide_freely;
    }
}