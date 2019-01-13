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
            codingInfoListView.Items.Add("Compare");
        }

        private void compareBtn_Click(object sender, EventArgs e)
        {
            compareInfoListView.Items.Add("Compare");

        }
    }
}
