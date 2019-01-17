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
    public partial class ConfirmImportDataForm : Form
    {
        private IEnumerable<BatchInfo> batchInfos;

        public ConfirmImportDataForm(IEnumerable<BatchInfo> infos)
        {
            InitializeComponent();

            batchInfos = infos;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

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
            //dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            using (var db = new JunShengDb())
            {
                //SqliteHelper.DeleteAllBatchInfos(db);
                if (JunShengDb.InsertBatchInfos(db, batchInfos) > 0)
                {
                    MessageBox.Show($"导入成功");
                }
            }
            this.Close();
        }
    }
}
