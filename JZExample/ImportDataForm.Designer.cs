namespace JZExample
{
    partial class ImportDataForm
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
            this.importButton = new System.Windows.Forms.Button();
            this.backToMainButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.batchInfoTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fileSelectLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // importButton
            // 
            this.importButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.importButton.Location = new System.Drawing.Point(12, 398);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(150, 40);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "导入数据";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // backToMainButton
            // 
            this.backToMainButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.backToMainButton.Location = new System.Drawing.Point(638, 398);
            this.backToMainButton.Name = "backToMainButton";
            this.backToMainButton.Size = new System.Drawing.Size(150, 40);
            this.backToMainButton.TabIndex = 4;
            this.backToMainButton.Text = "返回主界面";
            this.backToMainButton.UseVisualStyleBackColor = true;
            this.backToMainButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "批次信息:";
            // 
            // batchInfoTextBox
            // 
            this.batchInfoTextBox.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.batchInfoTextBox.Location = new System.Drawing.Point(124, 360);
            this.batchInfoTextBox.Name = "batchInfoTextBox";
            this.batchInfoTextBox.Size = new System.Drawing.Size(494, 31);
            this.batchInfoTextBox.TabIndex = 6;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 24F);
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(399, 33);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "均晟公司自动打码控制系统";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fileSelectLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Click += new System.EventHandler(this.groupBox1_Click);
            // 
            // fileSelectLabel
            // 
            this.fileSelectLabel.AutoSize = true;
            this.fileSelectLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileSelectLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.fileSelectLabel.Location = new System.Drawing.Point(198, 136);
            this.fileSelectLabel.Name = "fileSelectLabel";
            this.fileSelectLabel.Size = new System.Drawing.Size(157, 21);
            this.fileSelectLabel.TabIndex = 0;
            this.fileSelectLabel.Text = "数据源文件选择";
            this.fileSelectLabel.Click += new System.EventHandler(this.groupBox1_Click);
            // 
            // ImportDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.batchInfoTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backToMainButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "ImportDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "均晟公司自动打码控制系统";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button backToMainButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox batchInfoTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label fileSelectLabel;
    }
}