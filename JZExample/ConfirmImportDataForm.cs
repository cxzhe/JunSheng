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
        private BatchItem[] _batchItems;

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
            _batchItems = excelLoader.Load(_path).ToArray();
            dataGridView1.DataSource = _batchItems;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            var batchNumber = batchTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(batchNumber))
            {
                MessageBox.Show($"批次不能为空");
                return;
            }

            var db = AppContext.Instance.DB;

            if(null != db.Table<Batch>().FirstOrDefault((b) => b.BatchNo == batchNumber))
            {
                MessageBox.Show($"批次{batchNumber}已存在");
                return;
            }

            var batch = new Batch()
            {
                BatchNo = batchNumber,
                CreateTime = DateTime.Now,
            };
            db.RunInTransaction(() =>
            {
                db.Insert(batch);
                foreach (var item in _batchItems)
                {
                    item.BatchId = batch.Id;
                    db.Insert(item);
                }
            });
            batch.Items = _batchItems;

            AppContext.Instance.Batchs.Insert(0, batch);
            //MessageBox.Show($"导入成功");
            Close();
        }
    }
}
