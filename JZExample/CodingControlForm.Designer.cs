namespace JZExample
{
    partial class CodingControlForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.codingBtn = new System.Windows.Forms.Button();
            this.compareBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.codingInfoListView = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.compareInfoListView = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.Location = new System.Drawing.Point(174, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(399, 33);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "均晟公司自动打码控制系统";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(638, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 40);
            this.button2.TabIndex = 9;
            this.button2.Text = "返回主界面";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // codingBtn
            // 
            this.codingBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codingBtn.Location = new System.Drawing.Point(638, 214);
            this.codingBtn.Name = "codingBtn";
            this.codingBtn.Size = new System.Drawing.Size(150, 40);
            this.codingBtn.TabIndex = 10;
            this.codingBtn.Text = "打码";
            this.codingBtn.UseVisualStyleBackColor = true;
            this.codingBtn.Click += new System.EventHandler(this.codingBtn_Click);
            // 
            // compareBtn
            // 
            this.compareBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.compareBtn.Location = new System.Drawing.Point(638, 308);
            this.compareBtn.Name = "compareBtn";
            this.compareBtn.Size = new System.Drawing.Size(150, 40);
            this.compareBtn.TabIndex = 11;
            this.compareBtn.Text = "对比";
            this.compareBtn.UseVisualStyleBackColor = true;
            this.compareBtn.Click += new System.EventHandler(this.compareBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.codingInfoListView);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 179);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打码信息";
            // 
            // codingInfoListView
            // 
            this.codingInfoListView.Location = new System.Drawing.Point(7, 21);
            this.codingInfoListView.Name = "codingInfoListView";
            this.codingInfoListView.Size = new System.Drawing.Size(548, 152);
            this.codingInfoListView.TabIndex = 0;
            this.codingInfoListView.UseCompatibleStateImageBehavior = false;
            this.codingInfoListView.View = System.Windows.Forms.View.Details;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.compareInfoListView);
            this.groupBox2.Location = new System.Drawing.Point(12, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 190);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "对比信息";
            // 
            // compareInfoListView
            // 
            this.compareInfoListView.Location = new System.Drawing.Point(7, 21);
            this.compareInfoListView.Name = "compareInfoListView";
            this.compareInfoListView.Size = new System.Drawing.Size(548, 163);
            this.compareInfoListView.TabIndex = 0;
            this.compareInfoListView.UseCompatibleStateImageBehavior = false;
            // 
            // CodingControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.compareBtn);
            this.Controls.Add(this.codingBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.titleLabel);
            this.Name = "CodingControlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "均晟公司自动打码控制系统";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button codingBtn;
        private System.Windows.Forms.Button compareBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView codingInfoListView;
        private System.Windows.Forms.ListView compareInfoListView;
    }
}