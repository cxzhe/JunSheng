using System;
using System.Linq;
using System.Windows.Forms;

using JZExample.Model;

namespace JZExample
{
    public partial class ConfirmImportDataForm : Form
    {
        //private IEnumerable<BatchInfo> batchInfos;
        private Batch _batch;

        public ConfirmImportDataForm(Batch batch)
        {
            InitializeComponent();
            _batch = batch;
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

            dataGridView1.DataSource = _batch.Items;
            modelTextBox.Text = _batch.Model;
            dateProducedTextBox.Text = _batch.DateProduced;
            batchNoTextBox.Text = _batch.BatchNo;
            itemCountTextBox.Text = _batch.Items.Length.ToString();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            var batchNumber = modelTextBox.Text.Trim();
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

            _batch.CompleteCount = _batch.Items.Length;

            db.RunInTransaction(() =>
            {
                db.Insert(_batch);
                foreach (var item in _batch.Items)
                {
                    item.BatchId = _batch.Id;
                    db.Insert(item);
                }
            });

            AppContext.Instance.Batchs.Insert(0, _batch);
            //MessageBox.Show($"导入成功");
            Close();
        }
    }
}
