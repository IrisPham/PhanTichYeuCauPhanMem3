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
    public partial class frmAddGuider : Form
    {
        private string topicid;

        public frmAddGuider(string topicid)
        {
            InitializeComponent();
            cboRole.SelectedIndex = 0;
            this.topicid = topicid;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtGuiderID.Text == "" || txtGuiderName.Text == "")
            {
                MessageBox.Show("Tên hoặc mã người h.dẫn không được để trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql;
            sql = "insert into guider values('" + txtGuiderID.Text + "',N'" + txtGuiderName.Text
                + "',N'" + cboRole.Text + "'," + topicid + ")";
            if (!Database.updateData(sql))
            {
                MessageBox.Show("Đã tồn tại người hướng dẫn này!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGuiderID.Text = "";
                txtGuiderName.Text = "";
                txtGuiderID.Focus();
            }
            else
            {
                this.Close();
            }
        }
    }
}
