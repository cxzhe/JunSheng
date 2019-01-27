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
            textBox1.Text = Settings.Default.X30Ip;
            textBox2.Text = Settings.Default.QRField;
            portNameTextBox.Text = Settings.Default.PortName;
            baudRateTextBox.Text = Settings.Default.BaudRate.ToString();
            dataBitssTextBox.Text = Settings.Default.DataBitss.ToString();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Settings.Default.X30Ip = textBox1.Text;
            Settings.Default.QRField = textBox2.Text;
            Settings.Default.PortName = portNameTextBox.Text;

            if(int.TryParse(baudRateTextBox.Text,out int baudRate))
            {
                Settings.Default.BaudRate = baudRate;
            }

            if (int.TryParse(dataBitssTextBox.Text, out int dataBits))
            {
                Settings.Default.DataBitss = dataBits;
            }

            Settings.Default.Save();
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
