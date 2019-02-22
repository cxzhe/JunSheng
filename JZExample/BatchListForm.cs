using System;
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
    }
}
