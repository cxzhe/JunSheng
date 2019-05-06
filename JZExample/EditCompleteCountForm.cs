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
    public partial class EditCompleteCountForm : Form
    {
        private Batch _batch;

        //public TextBox CompleteCountTextBox
        //{
        //    get { return completeCountTextBox; }
        //}

        public EditCompleteCountForm(Batch batch)
        {
            _batch = batch;
            InitializeComponent();
            completeCountTextBox.Text = _batch.CompleteCount.ToString();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(completeCountTextBox.Text, out int completeCount) && 
                completeCount > 0 && completeCount <= _batch.Items.Length)
            {
                _batch.CompleteCount = completeCount;
                AppContext.Instance.DB.Update(_batch);
                Close();
            }else
            {
                MessageBox.Show("输入数量有误");
            }
        }
    }
}
