using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JZExample.Model;

namespace JZExample
{
    public partial class Form1 : Form
    {
        private const string _password = "admin";
        private MainForm _mainForm;

        public Form1()
        {
            InitializeComponent();
            _mainForm = new MainForm();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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
