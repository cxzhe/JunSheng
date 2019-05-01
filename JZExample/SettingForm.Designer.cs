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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "X30打码机IP地址";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // x30IpTextBox
            // 
            this.x30IpTextBox.Location = new System.Drawing.Point(156, 40);
            this.x30IpTextBox.Name = "x30IpTextBox";
            this.x30IpTextBox.Size = new System.Drawing.Size(285, 21);
            this.x30IpTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "二维码键值";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // qrcodeTextBox
            // 
            this.qrcodeTextBox.Location = new System.Drawing.Point(156, 98);
            this.qrcodeTextBox.Name = "qrcodeTextBox";
            this.qrcodeTextBox.Size = new System.Drawing.Size(285, 21);
            this.qrcodeTextBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(355, 545);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(227, 545);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // portNameTextBox
            // 
            this.portNameTextBox.Location = new System.Drawing.Point(156, 330);
            this.portNameTextBox.Name = "portNameTextBox";
            this.portNameTextBox.Size = new System.Drawing.Size(285, 21);
            this.portNameTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "串口名";
            // 
            // baudRateTextBox
            // 
            this.baudRateTextBox.Location = new System.Drawing.Point(156, 388);
            this.baudRateTextBox.Name = "baudRateTextBox";
            this.baudRateTextBox.Size = new System.Drawing.Size(285, 21);
            this.baudRateTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "BaudRate";
            // 
            // dataBitssTextBox
            // 
            this.dataBitssTextBox.Location = new System.Drawing.Point(156, 446);
            this.dataBitssTextBox.Name = "dataBitssTextBox";
            this.dataBitssTextBox.Size = new System.Drawing.Size(285, 21);
            this.dataBitssTextBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 446);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "DataBits";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // modelTextBox
            // 
            this.modelTextBox.Location = new System.Drawing.Point(156, 156);
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.Size = new System.Drawing.Size(285, 21);
            this.modelTextBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "生产型号键值";
            // 
            // dateProducedTextBox
            // 
            this.dateProducedTextBox.Location = new System.Drawing.Point(156, 214);
            this.dateProducedTextBox.Name = "dateProducedTextBox";
            this.dateProducedTextBox.Size = new System.Drawing.Size(285, 21);
            this.dateProducedTextBox.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "生产日期键值";
            // 
            // batchNoTextBox
            // 
            this.batchNoTextBox.Location = new System.Drawing.Point(156, 272);
            this.batchNoTextBox.Name = "batchNoTextBox";
            this.batchNoTextBox.Size = new System.Drawing.Size(285, 21);
            this.batchNoTextBox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "生产批号键值";
            // 
            // errorCountTextBox
            // 
            this.errorCountTextBox.Location = new System.Drawing.Point(156, 494);
            this.errorCountTextBox.Name = "errorCountTextBox";
            this.errorCountTextBox.Size = new System.Drawing.Size(285, 21);
            this.errorCountTextBox.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 494);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "失败次数阙值";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 607);
            this.Controls.Add(this.errorCountTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.batchNoTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateProducedTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.modelTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataBitssTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.baudRateTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.portNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.qrcodeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.x30IpTextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.Text = "设置";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}