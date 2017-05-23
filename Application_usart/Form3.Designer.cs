namespace Application_usart
{
    partial class Form3
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.state = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.soc = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.current = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.voltage = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Data1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Data3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Data5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Data7 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(10, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 281);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "协议设置";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(35, 347);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "复位";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(136, 347);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.state);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.soc);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.current);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.voltage);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.header);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(10, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 103);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "总数据协议";
            // 
            // state
            // 
            this.state.Location = new System.Drawing.Point(168, 70);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(47, 21);
            this.state.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(114, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "电池状态";
            // 
            // soc
            // 
            this.soc.Location = new System.Drawing.Point(55, 70);
            this.soc.Name = "soc";
            this.soc.Size = new System.Drawing.Size(47, 21);
            this.soc.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 21;
            this.label14.Text = "总SOC";
            // 
            // current
            // 
            this.current.Location = new System.Drawing.Point(168, 44);
            this.current.Name = "current";
            this.current.Size = new System.Drawing.Size(47, 21);
            this.current.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(114, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "总电流";
            // 
            // voltage
            // 
            this.voltage.Location = new System.Drawing.Point(55, 44);
            this.voltage.Name = "voltage";
            this.voltage.Size = new System.Drawing.Size(47, 21);
            this.voltage.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "总电压";
            // 
            // header
            // 
            this.header.Location = new System.Drawing.Point(55, 17);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(47, 21);
            this.header.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "帧头";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "书写格式：0X01十六进制形式";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(10, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 151);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "单体电池功能位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "电压";
            // 
            // Data1
            // 
            this.Data1.Location = new System.Drawing.Point(64, 9);
            this.Data1.Name = "Data1";
            this.Data1.Size = new System.Drawing.Size(47, 21);
            this.Data1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "SOC";
            // 
            // Data3
            // 
            this.Data3.Location = new System.Drawing.Point(64, 35);
            this.Data3.Name = "Data3";
            this.Data3.Size = new System.Drawing.Size(47, 21);
            this.Data3.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "SOH";
            // 
            // Data5
            // 
            this.Data5.Location = new System.Drawing.Point(64, 62);
            this.Data5.Name = "Data5";
            this.Data5.Size = new System.Drawing.Size(47, 21);
            this.Data5.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "温度";
            // 
            // Data7
            // 
            this.Data7.Location = new System.Drawing.Point(64, 89);
            this.Data7.Name = "Data7";
            this.Data7.Size = new System.Drawing.Size(47, 21);
            this.Data7.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Data7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.Data5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Data3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Data1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 123);
            this.panel1.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 6;
            this.label15.Text = "协议二设置";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 382);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form3";
            this.Text = "数据协议设置（第二版）";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox state;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox soc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox current;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox voltage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox header;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Data7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Data5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Data3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Data1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
    }
}