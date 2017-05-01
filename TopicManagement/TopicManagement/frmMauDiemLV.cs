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
    public partial class frmMauDiemLV : Form
    {
        private string id;

        public frmMauDiemLV(string title, string id, string studentname, string studentid, string date)
        {
            //String Title, String PersonName, String StudentCode, String DayStart
            InitializeComponent();
            //Gán thông tin đề tài
            txtTopicName.Text = title;
            lblStudentID.Text = studentid;
            lblStudentName.Text = studentname;
            lblDateStart.Text = date;
            this.id = id;
            lblMarkerID.Text = Database.getSingelData("select lecturerid from account","string")[0];
            //Gán thời gian và địa điểm 
            setTime();

        }
        //Cập nhật điểm mục 1
        private double setMark1()
        {
            double mark1 = 0;
            try
            {
                mark1 += Convert.ToDouble(txtMark11.Text);
            }
            catch
            {
            }
            try
            {
                mark1 += Convert.ToDouble(txtMark12.Text);
            }
            catch { }
            try
            {
                mark1 += Convert.ToDouble(txtMark13.Text);
            }
            catch { }
            try
            {
                mark1 += Convert.ToDouble(txtMark14.Text);
            }
            catch { }
            return mark1;
        }
        //Cập nhật điểm mục 2
        private double setMark2()
        {
            double mark2 = 0;
            try
            {
                mark2 += Convert.ToDouble(txtMark21.Text);
            }
            catch
            {
            }
            try
            {
                mark2 += Convert.ToDouble(txtMark22.Text);
            }
            catch { }
            try
            {

                mark2 += Convert.ToDouble(txtMark23.Text);
            }
            catch
            {
            }
            return mark2;
        }
        //Cập nhật điểm mục 3
        private double setMark3()
        {
            double mark3 = 0;
            try
            {
                mark3 += Convert.ToDouble(txtMark31.Text);
            }
            catch
            {

            }
            try
            {

                mark3 += Convert.ToDouble(txtMark32.Text);
            }
            catch
            {

            }
            try
            {

                mark3 += Convert.ToDouble(txtMark33.Text);
            }
            catch
            {

            }
            return mark3;
        }
        //Cập nhật điểm mục 4
        private double setMark4()
        {
            double mark4 = 0;
            try
            {
                mark4 += Convert.ToDouble(txtMark41.Text);
            }
            catch
            {

            }
            try
            {
                mark4 += Convert.ToDouble(txtMark42.Text);
            }
            catch
            {

            }
            return mark4;
        }
        //Cập nhật điểm mục Tổng
        private double setMarkSum()
        {
            double markSum = 0;
            try
            {
                markSum += Convert.ToDouble(txtMark1.Text);
                markSum += Convert.ToDouble(txtMark2.Text);
                markSum += Convert.ToDouble(txtMark3.Text);
                markSum += Convert.ToDouble(txtMark4.Text);
            }
            catch (Exception)
            {

            }
            return markSum;
        }
        
        //Cập nhật điểm chữ
        private void setMarkText()
        {
            //Đầu tiên phải phải lấy được điểm trong tổng
            double markSum = double.Parse(txtMarkSum.Text);
            //Truy xuất CSDL bảng mark và so sánh điểm
            string sql;
            sql = "select * from mark";
            DataTable table = Database.fillDataToTable(sql);
            string mark = "";
            double min = 0;
            double max = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                mark = table.Select()[i].ItemArray[0].ToString().Trim();
                min = double.Parse(table.Select()[i].ItemArray[1].ToString().Trim());
                max = double.Parse(table.Select()[i].ItemArray[2].ToString().Trim());
                //Nếu điểm tổng nằm trong khoảng >= min <= max thì gán điểm chữ!
                if (markSum >= min && markSum <= max)
                {
                    lblMark.Text = mark;
                    return;
                }
                else
                {
                    continue;
                }
            }
        }
        //Cập nhật điểm phần 1
        private void txtMark11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double mark = Convert.ToDouble(txtMark11.Text);
                if (mark > 0.5)
                {
                    MessageBox.Show("Nhập quá số điểm cho phép!");
                    txtMark13.Text = "";
                    txtMark13.Focus();
                }
                else
                {
                    txtMark1.Text = setMark1().ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMark12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double mark = Convert.ToDouble(txtMark12.Text);
                if (mark > 0.5)
                {
                    MessageBox.Show("Nhập quá số điểm cho phép!");
                    txtMark12.Text = "";
                    txtMark12.Focus();
                }
                else
                {
                    txtMark1.Text = setMark1().ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMark13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double mark = Convert.ToDouble(txtMark13.Text);
                if (mark > 1.0)
                {
                    MessageBox.Show("Nhập quá số điểm cho phép!");
                    txtMark13.Text = "";
                    txtMark13.Focus();
                }
                else
                {
                    txtMark1.Text = setMark1().ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMark14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double mark = Convert.ToDouble(txtMark14.Text);
                if (mark > 2)
                {
                    MessageBox.Show("Nhập quá số điểm cho phép!");
                    txtMark13.Text = "";
                    txtMark13.Focus();
                }
                else
                {
                    txtMark1.Text = setMark1().ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMark11_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtMark11.Text);
            }
            catch
            {
                txtMark11.Text = "0";
            }
        }

        private void txtMark12_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtMark12.Text);
            }
            catch
            {
                txtMark12.Text = "0";
            }
        }

        private void txtMark13_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtMark13.Text);
            }
            catch
            {
                txtMark13.Text = "0";
            }
        }

        private void txtMark14_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtMark14.Text);
            }
            catch
            {
                txtMark14.Text = "0";
            }
        }

        //Cập nhật điểm phần 2
        private void txtMark21_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double mark = Convert.ToDouble(txtMark21.Text);
                if (mark > 2.0)
                {
                    MessageBox.Show("Nhập quá số điểm cho phép!");
                    txtMark21.Text = "";
                    txtMark21.Focus();
                }
                else
                {
                    txtMark2.Text = setMark2().ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMark22_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double mark = Convert.ToDouble(txtMark22.Text);
                if (mark > 1.0)
                {
                    MessageBox.Show("Nhập quá số điểm cho phép!");
                    txtMark22.Text = "";
                    txtMark22.Focus();
                }
                else
                {
                    txtMark2.Text = setMark2().ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMark23_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double mark = Convert.ToDouble(txtMark23.Text);
                if (mark > 0.5)
                {
                    MessageBox.Show("Nhập quá số điểm cho phép!");
                    txtMark23.Text = "";
                    txtMark23.Focus();
                }
                else
                {
                    txtMark2.Text = setMark2().ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMark21_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtMark21.Text);
            }
            catch
            {
                txtMark21.Text = "0";
            }
        }

        private void txtMark22_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtMark22.Text);
            }
            catch
            {
                txtMark22.Text = "0";
            }
        }

        private void txtMark23_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtMark23.Text);
            }
            catch
            {
                txtMark23.Text = "0";
            }
        }

        //Cập nhật điểm phần 3
        private void txtMark31_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double mark = Convert.ToDouble(txtMark31.Text);
                if (mark > 1.0)
                {
                    MessageBox.Show("Nhập quá số điểm cho phép!");
                    txtMark31.Text = "";
                    txtMark31.Focus();
                }
                else
                {
                    txtMark3.Text = setMark3().ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMark32_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double mark = Convert.ToDouble(txtMark32.Text);
                if (mark > 0.25)
                {
                    MessageBox.Show("Nhập quá số điểm cho phép!");
                    txtMark32.Text = "";
                    txtMark32.Focus();
                }
                else
                {
                    txtMark3.Text = setMark3().ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMark33_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double mark = Convert.ToDouble(txtMark33.Text);
                if (mark > 0.25)
                {
                    MessageBox.Show("Nhập quá số điểm cho phép!");
                    txtMark33.Text = "";
                    txtMark33.Focus();
                }
                else
                {
                    txtMark3.Text = setMark3().ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMark31_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtMark31.Text);
            }
            catch
            {
                txtMark31.Text = "0";
            }
        }

        private void txtMark32_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtMark32.Text);
            }
            catch
            {
                txtMark32.Text = "0";
            }
        }

        private void txtMark33_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtMark33.Text);
            }
            catch
            {
                txtMark33.Text = "0";
            }
        }

        //Cập nhật điểm phần 4
        private void txtMark41_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double mark = Convert.ToDouble(txtMark41.Text);
                if (mark > 0.5)
                {
                    MessageBox.Show("Nhập quá số điểm cho phép!");
                    txtMark41.Text = "";
                    txtMark41.Focus();
                }
                else
                {
                    txtMark4.Text = setMark4().ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMark42_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double mark = Convert.ToDouble(txtMark42.Text);
                if (mark > 0.5)
                {
                    MessageBox.Show("Nhập quá số điểm cho phép!");
                    txtMark42.Text = "";
                    txtMark42.Focus();
                }
                else
                {
                    txtMark4.Text = setMark4().ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMark41_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtMark41.Text);
            }
            catch
            {
                txtMark41.Text = "0";
            }
        }

        private void txtMark42_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(txtMark42.Text);
            }
            catch
            {
                txtMark42.Text = "0";
            }
        }

        //Cập nhật điểm tổng
        private void txtMark1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMarkSum.Text = setMarkSum().ToString();
            }
            catch
            {

            }
        }

        private void txtMark2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMarkSum.Text = setMarkSum().ToString();
            }
            catch
            {

            }
        }

        private void txtMark3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMarkSum.Text = setMarkSum().ToString();
            }
            catch
            {

            }
        }

        private void txtMark4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMarkSum.Text = setMarkSum().ToString();
            }
            catch
            {

            }
        }

        //Cập nhật điểm chữ
        private void txtMarkSum_TextChanged(object sender, EventArgs e)
        {
            setMarkText();

        }
        //Lấy ngày hệ thống
        private void setTime()
        {
            DateTime time = DateTime.Now;
            int day = time.Day;
            int month = time.Month;
            int year = time.Year;
            txtDay.Text = day.ToString();
            txtMonth.Text = month.ToString();
            txtYear.Text = year.ToString();
        }

        //Chấm điểm lại
        private void btnReMark_Click(object sender, EventArgs e)
        {
            txtMark1.Text = "";
            txtMark2.Text = "";
            txtMark3.Text = "";
            txtMark4.Text = "";
            txtMarkSum.Text = "";

            txtMark11.Text = "";
            txtMark12.Text = "";
            txtMark13.Text = "";
            txtMark14.Text = "";

            txtMark21.Text = "";
            txtMark22.Text = "";
            txtMark23.Text = "";

            txtMark31.Text = "";
            txtMark32.Text = "";
            txtMark33.Text = "";

            txtMark41.Text = "";
            txtMark42.Text = "";

        }

        //Lưu điểm
        private void btnSaveMark_Click(object sender, EventArgs e)
        {
            //Lưu lại các ghi chú
            string note = "";
            string a = "; ";
            if (txtNote11.Text != "") note += txtNote11.Text + a;
            if (txtNote12.Text != "") note += txtNote12.Text + a;
            if (txtNote13.Text != "") note += txtNote13.Text + a;
            if (txtNote14.Text != "") note += txtNote14.Text + a;
            if (txtNote141.Text != "") note += txtNote141.Text + a;
            if (txtNote21.Text != "") note += txtNote21.Text + a;
            if (txtNote22.Text != "") note += txtNote22.Text + a;
            if (txtNote23.Text != "") note += txtNote23.Text + a;
            if (txtNote3.Text != "") note += txtNote3.Text + a;
            if (txtNote4.Text != "") note += txtNote4.Text + a;
            if (note != "")
                note = note.Substring(0, note.Length - 2);

            //Cập nhật điểm cho luận văn
            if (MessageBox.Show("Điểm số: " + txtMarkSum.Text + ", điểm chữ: '" + lblMark.Text + "'. Xác nhận lưu điểm?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "";
                sql = "insert into marker values('" + lblMarkerID.Text + "',N'" + lblMarkerName.Text +
                    "'," + txtMarkSum.Text + ",N'" + note + "'," + id + ")";
                if (Database.updateData(sql))
                {
                    MessageBox.Show("Lưu điểm thành công.");
                    this.Close();
                }
                else
                    MessageBox.Show("Lưu điểm thất bại!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
