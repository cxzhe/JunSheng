using System;
using System.Linq;
using System.Windows.Forms;

using JZExample.Model;

namespace JZExample
{
    public partial class ConfirmImportDataForm : Form
    {
        //private IEnumerable<BatchInfo> batchInfos;
        private string _path;
        private BatchInfo[] _batchInfos;

        public ConfirmImportDataForm(string path)
        {
            InitializeComponent();
            _path = path;
            SetupDataGrid();
        }

        private void SetupDataGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var excelLoader = new ExcelLoader();
            _batchInfos = excelLoader.Load(_path).ToArray();
            dataGridView1.DataSource = _batchInfos;

            //var dataTable = new DataTable();
            //var ccc = new DataColumn(nameof(BatchInfo.BatchNo));
            //dataTable.Columns.Add(new DataColumn(nameof(BatchInfo.BatchNo)));
            //dataTable.Columns.Add(new DataColumn(nameof(BatchInfo.SerinalNo)));
            //dataTable.Columns.Add(new DataColumn(nameof(BatchInfo.QRCodeContent)));
            //foreach (var info in batchInfos)
            //{
            //    var row = dataTable.NewRow();
            //    row[nameof(BatchInfo.BatchNo)] = info.BatchNo;
            //    row[nameof(BatchInfo.SerinalNo)] = info.SerinalNo;
            //    row[nameof(BatchInfo.QRCodeContent)] = info.QRCodeContent;
            //    dataTable.Rows.Add(row);
            //}

            //dataGridView1.DataSource = dataTable;
            //dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            using (var db = JunShengDb.Create())
            {
                //SqliteHelper.DeleteAllBatchInfos(db);
                if (db.InsertBatchInfos(_batchInfos) > 0)
                {
                    AppContext.Instance.BatchsToPrint = _batchInfos;
                    MessageBox.Show($"导入成功");
                }
            }
            Close();
        }
    }
}
