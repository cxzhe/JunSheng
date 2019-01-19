using JZExample.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JZExample
{
    public partial class StatisticalQueryForm : Form
    {
        private Form _mainForm;

        public StatisticalQueryForm(Form form)
        {
            _mainForm = form;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void backToMainBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            _mainForm.Show();
        }

        private void queryBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(batchInfoTextBox.Text))
            {
                using (var db = JunShengDb.Create())
                {
                    var batchInfos = JunShengDb.QueryBatchInfosByBatch(db, batchInfoTextBox.Text).ToArray();
                    if (batchInfos.Length > 0)
                    {
                        var dataTable = new DataTable();
                        var ccc = new DataColumn(nameof(BatchInfo.BatchNo));
                        dataTable.Columns.Add(new DataColumn(nameof(BatchInfo.BatchNo)));
                        dataTable.Columns.Add(new DataColumn(nameof(BatchInfo.SerinalNo)));
                        dataTable.Columns.Add(new DataColumn(nameof(BatchInfo.QRCodeContent)));

                        foreach (var info in batchInfos)
                        {
                            var row = dataTable.NewRow();
                            row[nameof(BatchInfo.BatchNo)] = info.BatchNo;
                            row[nameof(BatchInfo.SerinalNo)] = info.SerinalNo;
                            row[nameof(BatchInfo.QRCodeContent)] = info.QRCodeContent;
                            dataTable.Rows.Add(row);
                        }

                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                    }

                }
            }
        }
    }
}
