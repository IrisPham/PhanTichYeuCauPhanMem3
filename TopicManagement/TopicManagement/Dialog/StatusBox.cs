using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopicManagement.Dialog
{
    public partial class StatusBox : Form
    {
        private bool status = true;
        string content;

        public StatusBox()
        {
            InitializeComponent();
            cboStatus.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            content = cboStatus.Text;
            this.Close();
        }

        public string getText()
        {
            this.ShowDialog();
            if (status)
            {
                return content;
            }
            else
                return null;
        }
    }
}
