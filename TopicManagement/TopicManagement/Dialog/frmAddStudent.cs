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
    public partial class frmAddStudent : Form
    {
        private string topicid;

        public frmAddStudent(string topicid)
        {
            InitializeComponent();
            this.topicid = topicid;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtSpeID.Text == "" || txtStudentID.Text == "" || txtStudentName.Text == "")
            {
                MessageBox.Show("Có dữ liệu trống. Mời nhập lại!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql;
            sql = "insert into student values('" + txtStudentID.Text.Trim() + "',N'" + txtStudentName.Text.Trim() +
                "','" + txtSpeID.Text.Trim() + "')";
            if (!Database.updateData(sql)) {
                string notifi = " - " + txtStudentID.Text.Trim() + "\n - " + Database.getSingelData("select studentname from student where studentid='" + txtStudentID.Text.Trim() + "'", "string")[0]
                    + "\n - " + Database.getSingelData("select specializedid from student where studentid='" + txtStudentID.Text.Trim() + "'", "string")[0] + "\n\n";
                if (MessageBox.Show("Đã tồn tại mã số sinh viên này:\n" + notifi + "Nếu thêm, các giá trị nhập vào khác mã số sinh viên sẽ không được giữ lại. Xác nhận thêm?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    sql = "insert into topicdetail(topicid,status,studentid) values(" + topicid + ",N'Chưa hoàn thành','" + txtStudentID.Text.Trim() + "')";
                    Database.updateData(sql);
                    this.Close();
                }
                else return;
            }
            else
            {
                sql = "insert into topicdetail(topicid,status,studentid) values(" + topicid + ",N'Chưa hoàn thành','" + txtStudentID.Text.Trim() + "')";
                Database.updateData(sql);
                this.Close();
            }
        }
    }
}
