using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopicManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void connectionDB(string sql) {
            if (!Database.connect(sql))
            {
                MessageBox.Show("Không kết nối được với cơ sở dữ liệu!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            try
            {
                txtUsername.Text = Database.getSingelData("select username from remember", "string")[0];
                chkRemember.Checked = true;
                txtPassword.Focus();
            }
            catch { }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Validate();
        }

        private void Validate() {
            if (Database.MD5Hash(txtPassword.Text) == Database.getSingelData("Select password from account where username='" + txtUsername.Text + "'", "string")[0])
            {
                this.Hide();
                if (chkRemember.Checked == true)
                {
                    Database.updateData("delete from remember");
                    Database.updateData("insert into remember values('" + txtUsername.Text + "')");
                }
                else Database.updateData("delete from remember");
                new Main().ShowDialog();
            }
            else
            {
                txtPassword.Text = "";
                txtPassword.Focus();
                lblError.Text = "Mật khẩu không chính xác. Mời nhập lại!";
            }
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            string address = System.IO.Directory.GetCurrentDirectory();
            string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + address.Substring(0, address.Length - 14) + @"\TopicManagement.mdf;Integrated Security=True";
            connectionDB(sql);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
        }
    }
}
