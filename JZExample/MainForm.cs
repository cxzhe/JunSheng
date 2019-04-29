using System;
using System.Windows.Forms;

namespace JZExample
{
    public partial class MainForm : Form
    {
        //private ImportDataForm _importDataForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_importDataForm = new ImportDataForm(this);
            //Hide();
            //_importDataForm.Show();
            //_importDataForm.ShowDialog();

            ImportExcel();
        }

        private void ImportExcel()
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Multiselect = false;
            //openFileDialog.Title = "选择数据源文件";
            //openFileDialog.Filter = "(*.xls,*.xlsx)|*.xls;*.xlsx;";
            ////openFileDialog.ShowDialog();
            //if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.CheckFileExists)
            //{
            //    var form = new ConfirmImportDataForm(openFileDialog.FileName);
            //    form.ShowDialog();
            //    //Console.WriteLine(openFileDialog.FileName);
            //    //Console.WriteLine(openFileDialog.SafeFileName);
            //    //if (openFileDialog.CheckFileExists)
            //    //{
            //    //    fileSelectLabel.ForeColor = Color.Black;
            //    //var blah =  openFileDialog.SafeFileName;
            //    //    _chooseFile = new FileInfo(openFileDialog.FileName);
            //    //}
            //}
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if(AppContext.Instance.BatchsToPrint == null || AppContext.Instance.BatchsToPrint.Length <= 0)
            //{
            //    MessageBox.Show("没有批次数据，请先导入");
            //}else
            //{
            //    var codingForm = new CodingControlForm(this);
            //    Hide();
            //    codingForm.Show();
            //}
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new StatisticalQueryForm(this);
            this.Hide();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var settingForm = new SettingForm();
            settingForm.ShowDialog();

        }
    }
}
