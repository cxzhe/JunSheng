namespace JZExample
{
    partial class ConfirmImportDataForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.serialNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qrColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.modelTextBox = new System.Windows.Forms.TextBox();
            this.dateProducedTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.batchNoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.itemCountTextBox = new System.Windows.Forms.TextBox();
            this.expireDataTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialNumberColumn,
            this.qrColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(800, 420);
            this.dataGridView1.TabIndex = 0;
            // 
            // serialNumberColumn
            // 
            this.serialNumberColumn.DataPropertyName = "SerinalNo";
            this.serialNumberColumn.HeaderText = "序号";
            this.serialNumberColumn.Name = "serialNumberColumn";
            this.serialNumberColumn.ReadOnly = true;
            // 
            // qrColumn
            // 
            this.qrColumn.DataPropertyName = "QRCodeContent";
            this.qrColumn.HeaderText = "二维码数据";
            this.qrColumn.Name = "qrColumn";
            this.qrColumn.ReadOnly = true;
            this.qrColumn.Width = 200;
            // 
            // importBtn
            // 
            this.importBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.importBtn.Location = new System.Drawing.Point(662, 583);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(150, 43);
            this.importBtn.TabIndex = 4;
            this.importBtn.Text = "确认导入";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancelBtn.Location = new System.Drawing.Point(471, 583);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(150, 43);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "产品型号：";
            // 
            // modelTextBox
            // 
            this.modelTextBox.Location = new System.Drawing.Point(83, 38);
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.Size = new System.Drawing.Size(315, 20);
            this.modelTextBox.TabIndex = 7;
            // 
            // dateProducedTextBox
            // 
            this.dateProducedTextBox.Location = new System.Drawing.Point(497, 38);
            this.dateProducedTextBox.Name = "dateProducedTextBox";
            this.dateProducedTextBox.Size = new System.Drawing.Size(315, 20);
            this.dateProducedTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "生产日期：";
            // 
            // batchNoTextBox
            // 
            this.batchNoTextBox.Location = new System.Drawing.Point(83, 70);
            this.batchNoTextBox.Name = "batchNoTextBox";
            this.batchNoTextBox.Size = new System.Drawing.Size(315, 20);
            this.batchNoTextBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "生产批号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "总数量：";
            // 
            // itemCountTextBox
            // 
            this.itemCountTextBox.Location = new System.Drawing.Point(83, 102);
            this.itemCountTextBox.Name = "itemCountTextBox";
            this.itemCountTextBox.ReadOnly = true;
            this.itemCountTextBox.Size = new System.Drawing.Size(315, 20);
            this.itemCountTextBox.TabIndex = 13;
            // 
            // expireDataTextBox
            // 
            this.expireDataTextBox.Location = new System.Drawing.Point(497, 70);
            this.expireDataTextBox.Name = "expireDataTextBox";
            this.expireDataTextBox.Size = new System.Drawing.Size(315, 20);
            this.expireDataTextBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(426, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "失效日期：";
            // 
            // ConfirmImportDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 639);
            this.Controls.Add(this.expireDataTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.itemCountTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.batchNoTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateProducedTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modelTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ConfirmImportDataForm";
            this.Text = "导入数据";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qrColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox modelTextBox;
        private System.Windows.Forms.TextBox dateProducedTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox batchNoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox itemCountTextBox;
        private System.Windows.Forms.TextBox expireDataTextBox;
        private System.Windows.Forms.Label label5;
    }
}