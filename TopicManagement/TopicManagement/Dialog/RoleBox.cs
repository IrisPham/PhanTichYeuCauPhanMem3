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
    public partial class RoleBox : Form
    {
        private string topicid, guiderid;

        public RoleBox(string topicid, string guiderid)
        {
            InitializeComponent();
            cboRole.SelectedIndex = 0;
            this.guiderid = guiderid;
            this.topicid = topicid;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "update guider set role=N'" + cboRole.Text + "' where topicid=" + topicid +
                " and guiderid='" + guiderid + "'";
            Database.updateData(sql);
            this.Close();
        }
    }
}
