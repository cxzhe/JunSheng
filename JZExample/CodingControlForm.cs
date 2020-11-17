using System;
using System.Linq;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;

using JZExample.Model;

namespace JZExample
{
    public partial class CodingControlForm : Form
    {
        private Form _mainForm;
        private PrintController _printController;
        private Batch _batch;

        private SerialPort _gongkongPort;

        public CodingControlForm(Form form, Batch batch)
        {
            _mainForm = form;
            _batch = batch;
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = new BindingList<BatchItem>(batch.Items);

            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[_batch.StartIndex].DefaultCellStyle.BackColor = Color.White;
            _batch.StartIndex = e.RowIndex;
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Cyan;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.RowIndex == _batch.StartIndex)
            {
                e.CellStyle.BackColor = Color.Cyan;
            }
            //throw new NotImplementedException();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupPrintController();

            _gongkongPort = new SerialPort();
            _gongkongPort.BaudRate = Settings.Default.GongKongBaudRate;
            _gongkongPort.DataBits = Settings.Default.GongKongDataBits;
            _gongkongPort.Parity = Parity.None;
            _gongkongPort.StopBits = StopBits.One;
            _gongkongPort.ReadTimeout = 1000;
            _gongkongPort.WriteTimeout = 1000;
            _gongkongPort.PortName = Settings.Default.GongKongPortName;
        }

        private void SetupPrintController()
        {
            _printController = new PrintController(_batch);
            _printController.ErrorCount = Settings.Default.ErrorCount;
            _printController.QrCodeFieldName = Settings.Default.QRField;
            _printController.ModelFieldName = Settings.Default.ModelKey;
            _printController.DateProducedFieldName = Settings.Default.DateProducedKey;
            _printController.DateExpiredFieldName = Settings.Default.DateExpiredKey;
            _printController.BatchNoFieldName = Settings.Default.BatchNoKey;

            _printController.CodeScaned += _printController_CodeScaned;
            _printController.PrintCompleted += _printController_PrintCompleted;
            _printController.Printed += _printController_Printed;
            _printController.FatalError += _printController_FatalError;

            _printController.SerialPort.BaudRate = Settings.Default.BaudRate;
            _printController.SerialPort.DataBits = Settings.Default.DataBitss;
            _printController.SerialPort.Parity = Parity.None;
            _printController.SerialPort.StopBits = StopBits.One;
            _printController.SerialPort.ReadTimeout = 1000;
            _printController.SerialPort.PortName = Settings.Default.PortName;
        }

        private void _printController_FatalError(object sender, EventArgs e)
        {
            StopGongKong();
            var message = $"连续{_printController.ErrorCount}个没有识别成功";
            MessageBox.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _printController_PrintCompleted(object sender, EventArgs e)
        {
            StopGongKong();
            var confirmCount = _batch.Items.Where(i => i.Status == BatchStatus.Confirmed).Count();
            var msg = $"成功打印{confirmCount}条，共{_printController.BatchsToPrint.Length}条";
            statusTextBox.Text = msg;
            MessageBox.Show("打码完成", msg);
        }

        private void _printController_CodeScaned(object sender, CodeScanedEventArgs e)
        {
            Action action = () =>
            {
                var items = _batch.Items;
                var batchItem = items.FirstOrDefault(bi => bi.QRCodeContent == e.Code && bi.Status != BatchStatus.Confirmed);
                if(null != batchItem)
                {
                    batchItem.Status = BatchStatus.Confirmed;
                    AppContext.Instance.DB.Update(batchItem);
                }
            };
            BeginInvoke(action);
        }

        private void _printController_Logged(object sender, PrintControllerLogEventArgs e)
        {
            Log(e.Message);
            //codingInfoListView.Items.Add(e.Message);
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
           
        //    //Close();
        //}

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _printController.Close();
            _mainForm.Show();

            if (!_gongkongPort.IsOpen)
            {
                try
                {
                    _gongkongPort.Open();
                }
                catch (Exception)
                {
                    return;
                }
            }

            try
            {
                var message = "workhalt";
                //var bytes = System.Text.Encoding.ASCII.GetBytes(message);
                _gongkongPort.Write(message);
            }
            catch (Exception)
            {
            }
            _gongkongPort.Close();
        }

        private void StopGongKong()
        {
            if (!_gongkongPort.IsOpen)
            {
                try
                {
                    _gongkongPort.Open();
                }
                catch (Exception)
                {
                    return;
                }
            }

            Task.Run(() =>
            {
                try
                {
                    var message = "workhalt";
                    //var bytes = System.Text.Encoding.ASCII.GetBytes(message);
                    _gongkongPort.Write(message);
                }
                catch (Exception)
                {
                }
            });
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

            //try
            //{
            //    await _printController.X30Client.StateChangeAsync();
            //    //Log("x30没有设置就绪，请查看设备");
            //}
            //catch (Exception e)
            //{
            //    StartFailed($"x30无法就绪 {e.Message}");
            //    return;
            //}

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
               
            }

            _printController.Start();
        }

        private void _printController_Printed(object sender, EventArgs e)
        {
            //var msg = $"已打印{_printController.BatchIndex}条，共{_printController.BatchsToPrint.Length}条";

            var confirmCount = _batch.Items.Where(i => i.Status == BatchStatus.Confirmed).Count();
            var msg = $"成功打印{confirmCount}条，共{_printController.BatchsToPrint.Length}条";
            statusTextBox.Text = msg;
            //MessageBox.Show("打码完成", msg);
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
            //_batch.Items[0].Status = BatchStatus.NG;

            Close();
        }
    }
}
