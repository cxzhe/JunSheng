namespace JZExample
{
    partial class SettingForm
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
            this.x30IpTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.qrcodeTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.portNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.baudRateTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataBitssTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.modelTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateProducedTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.batchNoTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.errorCountTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gongKongPortNameTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.gongKongDataBitsTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gongKongBaudRateTextBox = new System.Windows.Forms.TextBox();
            this.textBoxExpiredDateKey = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X30打码机IP地址";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // x30IpTextBox
            // 
            this.x30IpTextBox.Location = new System.Drawing.Point(126, 17);
            this.x30IpTextBox.Name = "x30IpTextBox";
            this.x30IpTextBox.Size = new System.Drawing.Size(211, 20);
            this.x30IpTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "二维码键值";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // qrcodeTextBox
            // 
            this.qrcodeTextBox.Location = new System.Drawing.Point(126, 66);
            this.qrcodeTextBox.Name = "qrcodeTextBox";
            this.qrcodeTextBox.Size = new System.Drawing.Size(211, 20);
            this.qrcodeTextBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(318, 590);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(194, 590);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 41);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // portNameTextBox
            // 
            this.portNameTextBox.Location = new System.Drawing.Point(126, 311);
            this.portNameTextBox.Name = "portNameTextBox";
            this.portNameTextBox.Size = new System.Drawing.Size(211, 20);
            this.portNameTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "串口名";
            // 
            // baudRateTextBox
            // 
            this.baudRateTextBox.Location = new System.Drawing.Point(126, 360);
            this.baudRateTextBox.Name = "baudRateTextBox";
            this.baudRateTextBox.Size = new System.Drawing.Size(211, 20);
            this.baudRateTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "BaudRate";
            // 
            // dataBitssTextBox
            // 
            this.dataBitssTextBox.Location = new System.Drawing.Point(126, 409);
            this.dataBitssTextBox.Name = "dataBitssTextBox";
            this.dataBitssTextBox.Size = new System.Drawing.Size(211, 20);
            this.dataBitssTextBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "DataBits";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // modelTextBox
            // 
            this.modelTextBox.Location = new System.Drawing.Point(126, 115);
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.Size = new System.Drawing.Size(211, 20);
            this.modelTextBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "生产型号键值";
            // 
            // dateProducedTextBox
            // 
            this.dateProducedTextBox.Location = new System.Drawing.Point(126, 164);
            this.dateProducedTextBox.Name = "dateProducedTextBox";
            this.dateProducedTextBox.Size = new System.Drawing.Size(211, 20);
            this.dateProducedTextBox.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "生产日期键值";
            // 
            // batchNoTextBox
            // 
            this.batchNoTextBox.Location = new System.Drawing.Point(126, 262);
            this.batchNoTextBox.Name = "batchNoTextBox";
            this.batchNoTextBox.Size = new System.Drawing.Size(211, 20);
            this.batchNoTextBox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "生产批号键值";
            // 
            // errorCountTextBox
            // 
            this.errorCountTextBox.Location = new System.Drawing.Point(126, 458);
            this.errorCountTextBox.Name = "errorCountTextBox";
            this.errorCountTextBox.Size = new System.Drawing.Size(211, 20);
            this.errorCountTextBox.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 458);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "失败次数阙值";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(24, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(380, 536);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxExpiredDateKey);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.errorCountTextBox);
            this.tabPage1.Controls.Add(this.x30IpTextBox);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dataBitssTextBox);
            this.tabPage1.Controls.Add(this.batchNoTextBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.qrcodeTextBox);
            this.tabPage1.Controls.Add(this.baudRateTextBox);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dateProducedTextBox);
            this.tabPage1.Controls.Add(this.portNameTextBox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.modelTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(372, 510);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "打码设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gongKongPortNameTextBox);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.gongKongDataBitsTextBox);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.gongKongBaudRateTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(372, 510);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "工控";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gongKongPortNameTextBox
            // 
            this.gongKongPortNameTextBox.Location = new System.Drawing.Point(127, 23);
            this.gongKongPortNameTextBox.Name = "gongKongPortNameTextBox";
            this.gongKongPortNameTextBox.Size = new System.Drawing.Size(211, 20);
            this.gongKongPortNameTextBox.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "串口名";
            // 
            // gongKongDataBitsTextBox
            // 
            this.gongKongDataBitsTextBox.Location = new System.Drawing.Point(127, 133);
            this.gongKongDataBitsTextBox.Name = "gongKongDataBitsTextBox";
            this.gongKongDataBitsTextBox.Size = new System.Drawing.Size(211, 20);
            this.gongKongDataBitsTextBox.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "BaudRate";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "DataBits";
            // 
            // gongKongBaudRateTextBox
            // 
            this.gongKongBaudRateTextBox.Location = new System.Drawing.Point(127, 78);
            this.gongKongBaudRateTextBox.Name = "gongKongBaudRateTextBox";
            this.gongKongBaudRateTextBox.Size = new System.Drawing.Size(211, 20);
            this.gongKongBaudRateTextBox.TabIndex = 24;
            // 
            // textBoxExpiredDateKey
            // 
            this.textBoxExpiredDateKey.Location = new System.Drawing.Point(126, 213);
            this.textBoxExpiredDateKey.Name = "textBoxExpiredDateKey";
            this.textBoxExpiredDateKey.Size = new System.Drawing.Size(211, 20);
            this.textBoxExpiredDateKey.TabIndex = 21;
            this.textBoxExpiredDateKey.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "失效时间键值";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 658);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.Text = "设置";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox x30IpTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox qrcodeTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox portNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox baudRateTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dataBitssTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox modelTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox dateProducedTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox batchNoTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox errorCountTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox gongKongPortNameTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox gongKongDataBitsTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox gongKongBaudRateTextBox;
        private System.Windows.Forms.TextBox textBoxExpiredDateKey;
        private System.Windows.Forms.Label label10;
    }
}