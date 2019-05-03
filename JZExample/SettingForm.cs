using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace JZExample
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            x30IpTextBox.Text = Settings.Default.X30Ip;
            qrcodeTextBox.Text = Settings.Default.QRField;
            modelTextBox.Text = Settings.Default.ModelKey;
            dateProducedTextBox.Text = Settings.Default.DateProducedKey;
            batchNoTextBox.Text = Settings.Default.BatchNoKey;

            portNameTextBox.Text = Settings.Default.PortName;
            baudRateTextBox.Text = Settings.Default.BaudRate.ToString();
            dataBitssTextBox.Text = Settings.Default.DataBitss.ToString();

            errorCountTextBox.Text = Settings.Default.ErrorCount.ToString();

            gongKongPortNameTextBox.Text = Settings.Default.GongKongPortName;
            gongKongBaudRateTextBox.Text = Settings.Default.GongKongBaudRate.ToString();
            gongKongDataBitsTextBox.Text = Settings.Default.GongKongDataBits.ToString();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Settings.Default.X30Ip = x30IpTextBox.Text;
            Settings.Default.QRField = qrcodeTextBox.Text;
            Settings.Default.PortName = portNameTextBox.Text;

            Settings.Default.ModelKey = modelTextBox.Text;
            Settings.Default.DateProducedKey = dateProducedTextBox.Text;
            Settings.Default.BatchNoKey = batchNoTextBox.Text;

            if (int.TryParse(baudRateTextBox.Text,out int baudRate))
            {
                Settings.Default.BaudRate = baudRate;
            }

            if (int.TryParse(dataBitssTextBox.Text, out int dataBits))
            {
                Settings.Default.DataBitss = dataBits;
            }

            if (int.TryParse(errorCountTextBox.Text, out int errorcount))
            {
                Settings.Default.ErrorCount = errorcount;
            }

            Settings.Default.Save();


           
            Settings.Default.GongKongPortName = gongKongPortNameTextBox.Text;
            if (int.TryParse(gongKongBaudRateTextBox.Text, out int gkBaudRate))
            {
                Settings.Default.GongKongBaudRate = gkBaudRate;
            }
            if (int.TryParse(gongKongDataBitsTextBox.Text, out int gkDataBits))
            {
                Settings.Default.GongKongDataBits = gkDataBits;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
