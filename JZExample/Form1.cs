using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;

using JZExample.Model;

namespace JZExample
{
    public partial class Form1 : Form
    {
        private const string _password = "admin";
        private BatchListForm _mainForm;

        public Form1()
        {
            InitializeComponent();
            _mainForm = new BatchListForm();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Test();

        }

        private async void Test()
        {
            //{ ~ST0 |}
            var client = new TcpClient();
            await client.ConnectAsync(Settings.Default.X30Ip, 21000);
            var stream = client.GetStream();
            var encoding = System.Text.Encoding.ASCII;
            var packet = "{~ST|04|}";
            //var packet = "{~PS|0|}";
            
            var bytes = encoding.GetBytes(packet);
            await stream.WriteAsync(bytes, 0, bytes.Length);

            var bufferSize = 1024 * 8;
            var readerBuffer = new byte[bufferSize];
            var count = await stream.ReadAsync(readerBuffer, 0, bufferSize);
            var text = encoding.GetString(readerBuffer, 0, count);
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Equals(_password))
            {
                ShowMainForm();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Equals(_password))
            {
                ShowMainForm();
            }
            else
            {
                MessageBox.Show("密码错误");
            }
        }

        private void ShowMainForm()
        {
            Hide();
            _mainForm.Show();
        }
    }
}
