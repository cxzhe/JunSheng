using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;

using JZExample.Model;

namespace JZExample
{
    public partial class BatchListForm : Form
    {
        private BindingList<Batch> _batchs;

        public BatchListForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.MultiSelect = false;

            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cell = dataGridView1.SelectedCells[0];
            var index = cell.RowIndex;
            var batch = _batchs[index];
            var msg = $"确定要删除批次{batch.BatchNo}";
            if(MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                _batchs.RemoveAt(index);
                AppContext.Instance.DB.Delete(batch);
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns.IndexOf(compleCountColumn))
            {
                var batch = _batchs[e.RowIndex];
                var editFrom = new EditCompleteCountForm(batch);
                editFrom.ShowDialog();

                //dataGridView1.BeginEdit(false);
            }
        }

       

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns.IndexOf(printColumn))
            {
                var batch = _batchs[e.RowIndex];
                if(batch.ItemsCount <= 0)
                {
                    MessageBox.Show("没有批次条目");
                    return;
                }

                var codingForm = new CodingControlForm(this, batch);
                Hide();
                codingForm.Show();
            }else if(e.ColumnIndex == dataGridView1.Columns.IndexOf(deleteColumn))
            {
                var index = e.RowIndex;
                var batch = _batchs[index];
                var msg = $"确定要删除批次{batch.BatchNo}";
                if (MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    _batchs.RemoveAt(index);
                    AppContext.Instance.DB.Delete(batch);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppContext.Instance.Load();
            _batchs = AppContext.Instance.Batchs;
            dataGridView1.DataSource = _batchs;
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            ImportFromExcel();
        }

        private void ImportFromExcel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "选择数据源文件";
            openFileDialog.Filter = "(*.xls,*.xlsx)|*.xls;*.xlsx;";
            //openFileDialog.ShowDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.CheckFileExists)
            {
                var form = new ConfirmImportDataForm(openFileDialog.FileName);
                form.ShowDialog();
            }
        }

        private void settingButton_Click(object sender, EventArgs e)
        {
            var settingForm = new SettingForm();
            settingForm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
