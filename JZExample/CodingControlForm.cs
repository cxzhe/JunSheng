using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

using JZExample.Model;

namespace JZExample
{
    public partial class CodingControlForm : Form
    {
        private Form _mainForm;
        private PrintController _printController;
        private Batch _batch;

        public CodingControlForm(Form form, Batch batch)
        {
            _mainForm = form;
            _batch = batch;
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = batch.Items;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupPrintController();
        }

        private void SetupPrintController()
        {
            _printController = new PrintController(_batch.Items);
            _printController.FieldName = Settings.Default.QRField;

            _printController.SerialPort.BaudRate = Settings.Default.BaudRate;
            _printController.SerialPort.DataBits = Settings.Default.DataBitss;
            _printController.SerialPort.Parity = Parity.None;
            _printController.SerialPort.StopBits = StopBits.One;
            _printController.SerialPort.ReadTimeout = 1000;
            _printController.SerialPort.PortName = Settings.Default.PortName;
        }

        private void _printController_Logged(object sender, PrintControllerLogEventArgs e)
        {
            Log(e.Message);
            //codingInfoListView.Items.Add(e.Message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
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
            //textBox1.AppendText($"{message}{Environment.NewLine}");
            //textBox1.Text = $"{textBox1.Text}{Environment.NewLine}{message}";
            //textBox1.scr
            //richTextBox1.scro
            //codingInfoListView.Items.Add("连接到X30");
        }

        private void StartFailed(string message)
        {
            MessageBox.Show(message);
            startButton.Enabled = true;
        }

        private async void Start()
        {
            startButton.Enabled = false;
            
            if (string.IsNullOrWhiteSpace(Settings.Default.X30Ip))
            {
                StartFailed("X30 ip还未设置");
                return;
            }

            if (string.IsNullOrWhiteSpace(Settings.Default.QRField))
            {
                StartFailed("作业字段名未设置");
                return;
            }

            try
            {
                var ip = Settings.Default.X30Ip;
                await _printController.X30Client.ConnectAsync(ip);
                //Log("连接到X30");
            }
            catch (Exception e)
            {
                StartFailed($"无法连接到X30 {e.Message}");
                return;
            }

            try
            {
                await _printController.X30Client.StateChangeAsync();
                //Log("x30没有设置就绪，请查看设备");
            }
            catch (Exception e)
            {
                StartFailed($"x30无法就绪 {e.Message}");
                return;
            }

            try
            {
                if (!_printController.SerialPort.IsOpen)
                {
                    _printController.SerialPort.Open();
                }
            }
            catch (Exception e)
            {
                StartFailed($"无法连接串口 {e.Message}");
                return;
            }

            if (null == _printController)
            {
               
                //_printController.Logged += _printController_Logged;
                _printController.Printed += _printController_Printed;
            }

            _printController.Start();
        }

        private void _printController_Printed(object sender, EventArgs e)
        {
            var msg = $"已打印{_printController.BatchIndex}条，共{_printController.BatchsToPrint.Length}条";
            statusTextBox.Text = "";
        }

        private void compareBtn_Click(object sender, EventArgs e)
        {
            //compareInfoListView.Items.Add("Start Compare");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
