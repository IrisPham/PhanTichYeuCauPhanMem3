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
    public partial class frmNhapDiemHoiDong : Form
    {
        private string id;

        public frmNhapDiemHoiDong(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            txtMark.Text = "";
            txtMarkerID.Text = "";
            txtMarkerName.Text = "";
            txtNote.Text = "";
            txtMarkerID.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(txtMark.Text) < 0 || double.Parse(txtMark.Text) > 10)
                {
                    MessageBox.Show("Vượt quá giới hạn điểm cho phép!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMark.Focus();
                    return;
                }
                if (txtMarkerID.Text == "" || txtMarkerName.Text == "")
                {
                    MessageBox.Show("Mã số hoặc tên người chấm không được bỏ trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Sai định dạng điểm!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMark.Focus();
                return;
            }
            string sql;
            sql = "insert into marker values('" + txtMarkerID.Text + "',N'" + txtMarkerName.Text +
                "'," + txtMark.Text + ",N'" + txtNote.Text + "'," + id + ")";
            if (!Database.updateData(sql)) {
                MessageBox.Show("Đã tồn tại người chấm này!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("Nhập điểm hoàn tất.");
                this.Close();
            }
        }
    }
}
