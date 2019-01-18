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
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Settings.Default.X30Ip = textBox1.Text;
            Settings.Default.QRField = textBox2.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
