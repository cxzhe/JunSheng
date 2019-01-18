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
    public partial class CodingControlForm : Form
    {
        private Form _mainForm;
        private X30Client _x30Client = new X30Client();
        private PrintController _printController;
     

        public CodingControlForm(Form form)
        {
            _mainForm = form;
            InitializeComponent();

            codingInfoListView.Columns.Add("", 500);
            codingInfoListView.View = View.Details;
            codingInfoListView.HeaderStyle = ColumnHeaderStyle.None;

            compareInfoListView.Columns.Add("", 500);
            compareInfoListView.View = View.Details;
            compareInfoListView.HeaderStyle = ColumnHeaderStyle.None;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if(AppContext.Instance.BatchsToPrint == null || AppContext.Instance.BatchsToPrint.Length == 0)
            {
                MessageBox.Show("没有批次数据请先导入");
                Close();
            }

            if(string.IsNullOrWhiteSpace(Settings.Default.X30Ip))
            {
                MessageBox.Show("X30 ip还未设置");
            }

            if(string.IsNullOrWhiteSpace(Settings.Default.QRField))
            {
                MessageBox.Show("作业字段名未设置");
            }

            var batchInfos = AppContext.Instance.BatchsToPrint;
            _printController = new PrintController(_x30Client, Settings.Default.QRField, batchInfos);
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

        private void codingBtn_Click(object sender, EventArgs e)
        {
            codingInfoListView.Items.Add("Start Coding");
        }

        private void compareBtn_Click(object sender, EventArgs e)
        {
            compareInfoListView.Items.Add("Start Compare");

        }
    }
}
