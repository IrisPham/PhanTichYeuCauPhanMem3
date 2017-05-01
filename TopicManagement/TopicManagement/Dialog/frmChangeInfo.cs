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
    public partial class frmChangeInfo : Form
    {
        private string OldPass;
        private string OldLectureid;
        public frmChangeInfo()
        {
            InitializeComponent();
            getOldPass();
            getOldLectureid();
        }
        //Phương thức lấy mật khẩu cũ
        private void getOldPass()
        {
            string sql;
            sql = "select password from account";
            List<string> list = Database.getSingelData(sql, "string");
            OldPass = list[0];
        }
        //Lưu mật khẩu
        private void btnSavePass_Click(object sender, EventArgs e)
        {
            //Kiểm tra mật khẩu nhập cũ nhập vào so với mật khẩu cũ trong CSDL
            if (Database.MD5Hash(txtOldPass.Text) != OldPass)
            {
                MessageBox.Show("Mật khẩu cũ chưa chính xác!");
                txtOldPass.Text = "";
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
                txtOldPass.Focus();
                return;
            }
            //Kiểm tra mật khẩu mới != "";
            if (txtNewPass.Text == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu mới!");
                txtNewPass.Focus();
                return;
            }
            //Kiểm tra mật khẩu cũ != ""
            //Kiểm tra mật khẩu mới với xác nhận mật khẩu mới giống nhau
            //Nếu không giống nhau yêu cầu nhập lại
            if (txtOldPass.Text != "")
            {
                if ((txtConfirmPass.Text.Trim() == txtNewPass.Text.Trim()))
                {
                    String sql;
                    sql = "update account set password ='" + Database.MD5Hash(txtNewPass.Text) + "'";
                    Database.updateData(sql);
                    MessageBox.Show("Thay đổi mật khẩu thành công! \nMật khẩu có hiệu lực đăng nhập lần kế tiếp!");
                    getOldPass();
                    txtOldPass.Text = "";
                    txtNewPass.Text = "";
                    txtConfirmPass.Text = "";
                    txtOldPass.Focus();
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu sai!Mời nhập lại!");
                    txtConfirmPass.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu cũ");
                txtOldPass.Focus();
            }

        }
        //Nhập lại mật khẩu
        private void btnRePress_Click(object sender, EventArgs e)
        {
            txtOldPass.Text = "";
            txtNewPass.Text = "";
            txtConfirmPass.Text = "";
            txtOldPass.Focus();
        }

        //Phần xử lí sự kiện thay đổi mã Giảng viên
        //Phương thấy lấy mã giảng viên cũ
        private void getOldLectureid()
        {
            String sql;
            sql = "select lecturerid from account";
            List<string> list = Database.getSingelData(sql, "string");
            OldLectureid = list[0].ToString();
        }
        //Lưu mã giảng viên
        private void btnSaveCodeInstructor_Click(object sender, EventArgs e)
        {
            //Kiểm tra mã GV cũ nhập vào so với mã GV cũ trong CSDL
            if (txtOldCodeInstructor.Text != OldLectureid)
            {
                MessageBox.Show("Nhập mã GV cũ chưa chính xác!");
                txtOldCodeInstructor.Text = "";
                txtOldCodeInstructor.Focus();
                return;
            }
            //Kiểm tra nhập mã GV mới != "";
            if (txtNewCodeInstructor.Text == "")
            {
                MessageBox.Show("Chưa nhập mã GV mới!");
                txtOldCodeInstructor.Focus();
                return;
            }
            //Kiểm tra mã GV cũ != ""
            //Kiểm tra mã GV mới với xác nhận mã GV mới giống nhau
            //Nếu không giống nhau yêu cầu nhập lại
            if (txtOldCodeInstructor.Text != "")
            {
                if ((txtConfirmCodeInstructor.Text.Trim() == txtNewCodeInstructor.Text.Trim()))
                {
                    String sql;
                    sql = "update account set lecturerid ='" + txtConfirmCodeInstructor.Text + "'";
                    Database.updateData(sql);
                    MessageBox.Show("Thay mã GV thành công!");
                    getOldLectureid();
                    txtOldCodeInstructor.Text = "";
                    txtNewCodeInstructor.Text = "";
                    txtConfirmCodeInstructor.Text = "";
                    txtOldCodeInstructor.Focus();
                }
                else
                {
                    MessageBox.Show("Xác nhận mã GV sai!Nhập lại!");
                    txtConfirmCodeInstructor.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mã giảng viên cũ!");
                txtOldCodeInstructor.Focus();
            }

        }
        //Nhập lại mã giảng viên
        private void btnRePressCodeInstructor_Click(object sender, EventArgs e)
        {
            txtOldCodeInstructor.Text = "";
            txtNewCodeInstructor.Text = "";
            txtConfirmCodeInstructor.Text = "";
            txtOldCodeInstructor.Focus();
        }
    }
}
