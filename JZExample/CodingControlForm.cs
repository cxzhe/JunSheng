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

            //codingInfoListView.Columns.Add("", 500);
            //codingInfoListView.View = View.Details;
            //codingInfoListView.HeaderStyle = ColumnHeaderStyle.None;

            compareInfoListView.Columns.Add("", 500);
            compareInfoListView.View = View.Details;
            compareInfoListView.HeaderStyle = ColumnHeaderStyle.None;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void _printController_Logged(object sender, PrintControllerLogEventArgs e)
        {
            Log(e.Message);
            //codingInfoListView.Items.Add(e.Message);
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
            //codingInfoListView.Items.Add("Start Coding");
            Start();
        }

        private void Log(string message)
        {
            textBox1.AppendText($"{message}{Environment.NewLine}");
            //textBox1.Text = $"{textBox1.Text}{Environment.NewLine}{message}";
            //textBox1.scr
            //richTextBox1.scro
            //codingInfoListView.Items.Add("连接到X30");
        }

        private async void Start()
        {
            if (AppContext.Instance.BatchsToPrint == null || AppContext.Instance.BatchsToPrint.Length == 0)
            {
                MessageBox.Show("没有批次数据请先导入");
                return;
            }

            if (string.IsNullOrWhiteSpace(Settings.Default.X30Ip))
            {
                MessageBox.Show("X30 ip还未设置");
                return;
            }

            if (string.IsNullOrWhiteSpace(Settings.Default.QRField))
            {
                MessageBox.Show("作业字段名未设置");
                return;
            }

            try
            {
                var ip = Settings.Default.X30Ip;
                await _x30Client.TcpClient.ConnectAsync(ip, 21000);
                Log("连接到X30");
                //codingInfoListView.Items.Add("连接到X30");

                if (null == _printController)
                {
                    var batchInfos = AppContext.Instance.BatchsToPrint;
                    _printController = new PrintController(_x30Client, Settings.Default.QRField, batchInfos);
                    _printController.Logged += _printController_Logged;
                }

                _printController.Start();

                codingBtn.Enabled = false;
            }
            catch (Exception e)
            {
                Log($"无法连接到X30 {e.Message}");
            }
        }

        private void compareBtn_Click(object sender, EventArgs e)
        {
            compareInfoListView.Items.Add("Start Compare");
        }
    }
}
