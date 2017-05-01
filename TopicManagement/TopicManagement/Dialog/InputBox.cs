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
    public partial class InputBox : Form
    {
        private bool status = false;
        string content;
        private string title;

        public InputBox(int length, string title="")
        {
            InitializeComponent();
            txtInput.MaxLength = length;
            if (title != "") {
                txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                lblTitle.Text = title;
                this.title = "Nhập điểm";
            }
            this.title = title;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            content = txtInput.Text;
            if (title != "")
            {
                try
                {
                    if (double.Parse(content) > 10 || double.Parse(content) < 0)
                    {
                        MessageBox.Show("Điểm vượt quá giới hạn cho phép!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInput.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Nhập sai định dạng!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInput.Focus();
                    return;
                }
            }
            if (content == "")
            {
                MessageBox.Show("Dữ liệu trống!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInput.Focus();
                return;
            }
            status = true;
            this.Close();
        }

        public string getText() {
            this.ShowDialog();
            if (status) {
                return content;
            }
            else
                return null;
        }
    }
}
