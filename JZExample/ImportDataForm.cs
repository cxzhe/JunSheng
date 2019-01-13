using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JZExample
{
    public partial class ImportDataForm : Form
    {
        private Form _mainForm;
        private FileInfo _chooseFile;

        public ImportDataForm(Form form)
        {
            _mainForm = form;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            _mainForm.Show();
        }

        private void groupBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "选择数据源文件";
            openFileDialog.Filter = "(*.xls,*.xlsx)|*.xls;*.xlsx;";
            //openFileDialog.ShowDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(openFileDialog.FileName);
                Console.WriteLine(openFileDialog.SafeFileName);
                if (openFileDialog.CheckFileExists)
                {
                    fileSelectLabel.ForeColor = Color.Black;
                    fileSelectLabel.Text = openFileDialog.SafeFileName;
                    _chooseFile = new FileInfo(openFileDialog.FileName);
                }
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (_chooseFile?.Exists ?? false)
            {
                ExcelHelper excelHelper = new ExcelHelper(_chooseFile.FullName);
                var datatable = excelHelper.ExcelToDataTable("product", true);

                DatabaseHelper.DeleteDatabase();
                DatabaseHelper.CreateProductTable("product");

                DatabaseHelper.InsertProductRows("product", datatable);
            }
            else
            {
                MessageBox.Show("请选择文件", "请选择文件");
            }
        }
    }
}
