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
    public partial class MainForm : Form
    {
        private ImportDataForm _importDataForm;

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
            _importDataForm = new ImportDataForm(this);
            Hide();
            _importDataForm.Show();
            //_importDataForm.ShowDialog();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var codingForm = new CodingControlForm(this);
            Hide();
            codingForm.Show();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }
    }
}
