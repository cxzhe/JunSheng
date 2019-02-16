namespace JZExample
{
    partial class BatchListForm
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
            this.importButton = new System.Windows.Forms.Button();
            this.batchColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.settingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.batchColumn,
            this.itemsCountColumn,
            this.createTimeColumn,
            this.printColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(776, 367);
            this.dataGridView1.TabIndex = 0;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(12, 12);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(102, 39);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "导入批次";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // batchColumn
            // 
            this.batchColumn.DataPropertyName = "BatchNo";
            this.batchColumn.HeaderText = "批次";
            this.batchColumn.Name = "batchColumn";
            this.batchColumn.ReadOnly = true;
            this.batchColumn.Width = 200;
            // 
            // itemsCountColumn
            // 
            this.itemsCountColumn.DataPropertyName = "ItemsCount";
            this.itemsCountColumn.HeaderText = "数量";
            this.itemsCountColumn.Name = "itemsCountColumn";
            this.itemsCountColumn.ReadOnly = true;
            // 
            // createTimeColumn
            // 
            this.createTimeColumn.DataPropertyName = "CreateTime";
            this.createTimeColumn.HeaderText = "创建时间";
            this.createTimeColumn.Name = "createTimeColumn";
            this.createTimeColumn.ReadOnly = true;
            // 
            // printColumn
            // 
            this.printColumn.DataPropertyName = "PrintText";
            this.printColumn.HeaderText = "";
            this.printColumn.Name = "printColumn";
            this.printColumn.ReadOnly = true;
            this.printColumn.Text = "打码";
            // 
            // settingButton
            // 
            this.settingButton.Location = new System.Drawing.Point(145, 12);
            this.settingButton.Name = "settingButton";
            this.settingButton.Size = new System.Drawing.Size(102, 39);
            this.settingButton.TabIndex = 2;
            this.settingButton.Text = "系统设置";
            this.settingButton.UseVisualStyleBackColor = true;
            this.settingButton.Click += new System.EventHandler(this.settingButton_Click);
            // 
            // BatchListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.settingButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "BatchListForm";
            this.Text = "批次管理";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTimeColumn;
        private System.Windows.Forms.DataGridViewButtonColumn printColumn;
        private System.Windows.Forms.Button settingButton;
    }
}