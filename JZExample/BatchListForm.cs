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
    public partial class BatchListForm : Form
    {
        public BatchListForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns.IndexOf(printColumn))
            {
                var batch = AppContext.Instance.Batchs[e.RowIndex];
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
            dataGridView1.DataSource = AppContext.Instance.Batchs;
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
