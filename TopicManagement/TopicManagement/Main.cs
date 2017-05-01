using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopicManagement.Dialog;

namespace TopicManagement
{
    public partial class Main : Form
    {
        private Process.Table clstable;
        private Process.Statistical clsStatis;

        private string topicid = null;
        private string urlStudent = null;
        private string markID = null;
        private int count = 0;

        public Main()
        {
            InitializeComponent();
            Click(btnHome);
            clstable = new Process.Table(this);
            clsStatis = new Process.Statistical(this);
           // clstable = new Process.Table(this);
           // clsStatis = new Process.Statistical(this);
           // pnlViewDA.Visible = true;
           // //pnlViewNL.Visible = true;
           // pnlMarkLV.Visible = true;
           // pnlStatis.Visible = true;
           //// pnlViewLV.Visible = true;
        }

        //Bật hiệu ứng tiêu đề
        private void Click(Button b) {
            b.BackColor = Color.FromArgb(9, 77, 121);
        }

        //Tắt hiệu ứng tiêu đề
        private void lostFocus(Button b1, Button b2, Button b3, Button b4, Button b5)
        {
            b1.BackColor = Color.FromArgb(37, 130, 189);
            b2.BackColor = Color.FromArgb(37, 130, 189);
            b3.BackColor = Color.FromArgb(37, 130, 189);
            b4.BackColor = Color.FromArgb(37, 130, 189);
            b5.BackColor = Color.FromArgb(37, 130, 189);
        }

        private void showPanel(Panel pnl1, Panel pnl2, Panel pnl3, Panel pnl4, Panel pnl5, Panel pnl6, Panel pnl7) {
            pnl1.Visible = true;
            pnl2.Visible = false;
            pnl3.Visible = false;
            pnl4.Visible = false;
            pnl5.Visible = false;
            pnl6.Visible = false;
            pnl7.Visible = false;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Click(btnHome);
            lostFocus(btnLuanVan, btnNienLuan, btnAddNew, btnDoAn, btnStatistical);
            showPanel(pnlHome, pnlMarkLV, pnlViewLV, pnlViewNL, pnlViewDA, pnlImport, pnlStatis);
        }

        private void btnLuanVan_Click(object sender, EventArgs e)
        {
            Click(btnLuanVan);
            lostFocus(btnHome, btnNienLuan, btnAddNew, btnDoAn, btnStatistical);
            showPanel(pnlViewLV, pnlMarkLV, pnlHome, pnlViewNL, pnlViewDA, pnlImport, pnlStatis);
        }

        private void btnInputLV_Click(object sender, EventArgs e)
        {
            Click(btnLuanVan);
            btnInputLV.Visible = false;
            lostFocus(btnHome, btnNienLuan, btnAddNew, btnDoAn, btnStatistical);
            showPanel(pnlMarkLV, pnlHome, pnlViewLV, pnlViewNL, pnlViewDA, pnlImport, pnlStatis);
        }

        private void btnNienLuan_Click(object sender, EventArgs e)
        {
            Click(btnNienLuan);
            lostFocus(btnHome, btnLuanVan, btnDoAn, btnAddNew, btnStatistical);
            showPanel(pnlViewNL, pnlMarkLV, pnlViewLV, pnlHome, pnlViewDA, pnlImport, pnlStatis);
        }

        private void btnDoAn_Click(object sender, EventArgs e)
        {
            Click(btnDoAn);
            lostFocus(btnHome, btnNienLuan, btnLuanVan, btnAddNew, btnStatistical);
            showPanel(pnlViewDA, pnlMarkLV, pnlViewLV, pnlViewNL, pnlHome, pnlImport, pnlStatis);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Click(btnAddNew);
            lostFocus(btnLuanVan, btnNienLuan, btnHome, btnDoAn, btnStatistical);
            showPanel(pnlImport, pnlMarkLV, pnlViewLV, pnlViewNL, pnlViewDA, pnlHome, pnlStatis);
        }

        private void btnStatistical_Click(object sender, EventArgs e)
        {
            Click(btnStatistical);
            lostFocus(btnLuanVan, btnNienLuan, btnAddNew, btnDoAn, btnHome);
            showPanel(pnlStatis, pnlMarkLV, pnlViewLV, pnlViewNL, pnlViewDA, pnlImport, pnlHome);
        }

        /**
         * Set bảng chế độ read only ("Luận văn","Niên luận","Đồ án")
         **/
        private void setViewTable(String topic)
        {
            if (dgvViewTopicNL.Visible == false)
                return;
            dgvViewTopicNL.Rows.Clear();
            if (topic != "Luận văn") {
                String sql = "Select t.topicid, topicname from topic t, topicdetail d, time ti " +
                    "where t.topicid = d.topicid and d.id = ti.id and typeoftopic=N'" + topic + "' " +
                    "and semester=" + cboViewSemesterNL.Text + " and schoolyear='" + cboViewSYNL.Text + "'";
                DataTable table = Database.fillDataToTable(sql);
                for (int i = 0; i < table.Rows.Count; i++) {
                    dgvViewTopicNL.Rows.Add();
                    dgvViewTopicNL.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                    dgvViewTopicNL.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                }
            }
        }

        private void setTableStudent()
        {
            String sql = "Select studentid, studentname, status, mark, specialized, email from topic t, topicdetail d, student s" +
                "where t.topicid = d.topicid and s.id = d.id and t.topicid = " + dgvViewTopicNL.SelectedCells.ToString();
            DataTable table = Database.fillDataToTable(sql);
            dgvViewStudentNL.DataSource = table;
        }

        //Quản lí Thêm mới
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //Browse đến file cần import
            OpenFileDialog ofd = new OpenFileDialog();
            //Lấy đường dẫn file import vừa chọn
            txtFilePath.Text = ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : "";
        }

        //phương thức kiểm tra file nhập vào
        private bool ValidInput()
        {
            if (txtFilePath.Text.Trim() == "")
            {
                MessageBox.Show("Xin vui lòng chọn file từ tập tin excel cần import");
                return false;
            }
            return true;
        }

        private void btnHuyImportTM_Click(object sender, EventArgs e)
        {
            txtFilePath.Text = "";
            if(rdbSV.Checked)
            {
                while (dataGridView2.Rows.Count > 0)
                {
                    dataGridView2.Rows.RemoveAt(0);
                }
            }
            else
            {
                while (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.RemoveAt(0);
                }
            }
           
        }

        private DataTable ReadDataFromExcelFile(String Address, string url="")
        {   //Provider=Microsoft.ACE.OLEDB.12.0
            //Provider=Microsoft.Jet.OLEDB.4.0
            string conectionExcel;
            if (url != "") conectionExcel = "Provider=Microsoft.ACE.OLEDB.12.0; Extended Properties=Excel 8.0 ;Data Source=" + url.Trim();
            else conectionExcel = "Provider=Microsoft.ACE.OLEDB.12.0; Extended Properties=Excel 8.0 ;Data Source=" + txtFilePath.Text.Trim();
            //Tạo đối tượng kết nối
            OleDbConnection oledbConn = new OleDbConnection(conectionExcel);
            DataTable data = null;
            try
            {
                //Mở kết nối
                oledbConn.Open();

                //Tạo đối tượng OleDBCommand và Query data từ sheet có tên là "Sheet1"
                OleDbCommand cmd = new OleDbCommand(Address, oledbConn);

                //Tạo đối tượng OleDbDataApdapter để thực thi việc lấy query lấy dữ liệu từ tập tin excel
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                oleda.SelectCommand = cmd;

                //Tạo đối tượng Dataset để ghi dữ liệu từ excel
                DataSet ds = new DataSet();

                //Đổ dữ liệu từ tập tin excel vào DataSet
                oleda.Fill(ds);

                data = ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //Đóng chuỗi kết nỗi
                oledbConn.Close();
            }
            return data;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (rdbSV.Checked)
            {
                String Address = @"SELECT * FROM [Sheet1$B7:F100]";
                DataTable dt = ReadDataFromExcelFile(Address);
                try
                {
                    dataGridView2.DataSource = dt.DefaultView;
                    urlStudent = txtFilePath.Text;
                }
                catch (Exception)
                {
                    MessageBox.Show("Import file lỗi!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                String Address = @"SELECT * FROM [Sheet1$A1:A100]";
                try
                {
                    dataGridView1.DataSource = ReadDataFromExcelFile(Address).DefaultView;
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch
                {
                    MessageBox.Show("Import file lỗi!", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
        }

        //Xử lí sự kiện Hướng dẫn nạp file
        private void lbHelp_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHelp fh = new frmHelp();
            fh.ShowDialog();
            this.Show();
        }

        private void ptboxHelp_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHelp fh = new frmHelp();
            fh.ShowDialog();
            this.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Object value = dataGridView2.Rows.Ce
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBoxTenDeTai.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
        }
        //Xử lí sự kiện thay đổi thang điểm Luận văn
        private void ptboxChangeMark_Click(object sender, EventArgs e)
        {
            new frmChangeMark().ShowDialog();
        }
        private void lbChangeMark_Click(object sender, EventArgs e)
        {
            new frmChangeMark().ShowDialog();
        }

        //Xử lí sự kiện thay đổi mật khẩu
        private void ptboxChangePass_Click(object sender, EventArgs e)
        {
            new frmChangeInfo().ShowDialog();
        }

        private void lbChangePass_Click(object sender, EventArgs e)
        {
            new frmChangeInfo().ShowDialog();
        }
        //Xử lí check combobox sinh viên
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {

                if (Convert.ToBoolean(dataGridView2.Rows[e.RowIndex].Cells[0].Value) == true)
                {
                    count++;
                }
                else
                {
                    count--;
                }
                lbStdNum.Text = count.ToString();
            }

        }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView2.IsCurrentCellDirty)
            {
                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //Xử lí các vấn đề khác

        private void pnlViewNL_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlViewNL.Visible == true)
            {
                List<String> list = Database.getSingelData("Select distinct schoolyear from time ti, topic t where ti.topicid = t.topicid and typeoftopic=N'Niên luận'", "string");
                cboViewSYNL.DataSource = list;
                cboViewSemesterNL.SelectedIndex = 0;
                clstable.setViewTopic("Niên luận", cboViewSemesterNL.Text, cboViewSYNL.Text);
            }
        }

        private void cboViewSYNL_SelectedIndexChanged(object sender, EventArgs e)
        {
            clstable.setViewTopic("Niên luận", cboViewSemesterNL.Text, cboViewSYNL.Text);
        }

        private void cboViewSemesterNL_SelectedIndexChanged(object sender, EventArgs e)
        {
            clstable.setViewTopic("Niên luận", cboViewSemesterNL.Text, cboViewSYNL.Text);
        }

        private void txtSearchViewNL_TextChanged(object sender, EventArgs e)
        {
            clstable.setViewTopic("Niên luận", cboViewSemesterNL.Text, cboViewSYNL.Text, txtSearchViewNL.Text);
        }

        private void dgvViewTopicNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                topicid = dgvViewTopicNL.CurrentRow.Cells[0].Value.ToString();
                clstable.setViewStudent("Niên luận", topicid);
            }
            catch { }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnLuanVan_MouseEnter(object sender, EventArgs e)
        {
            btnInputLV.Visible = true;
        }

        private void Main_MouseEnter(object sender, EventArgs e)
        {
            btnInputLV.Visible = false;
        }

        private void btnNienLuan_MouseEnter(object sender, EventArgs e)
        {
            btnInputLV.Visible = false;
        }

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            btnInputLV.Visible = false;
        }

        private void btnInputLV_MouseLeave(object sender, EventArgs e)
        {
            btnInputLV.Visible = false;
        }

        private void dgvViewTopicNL_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id;
            try
            {
                id = dgvViewTopicNL.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                return;
            }
            if (dgvViewTopicNL.CurrentCellAddress.X == 1)
            {
                string content = new InputBox(500).getText();
                if (content == null)
                    return;
                if (MessageBox.Show("Xác nhận cập nhật?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string sql = "update topic set topicname=N'" + content + "' where topicid=" + id;
                    if (!Database.updateData(sql))
                        MessageBox.Show("Cập nhật thất bại!");
                    else
                        clstable.setViewTopic("Niên luận", cboViewSemesterNL.Text, cboViewSYNL.Text);
                }
            }
            if (dgvViewTopicNL.CurrentCellAddress.X == 2)
            {
                string content = new InputBox(10).getText();
                if (content == null)
                    return;
                if (MessageBox.Show("Xác nhận cập nhật?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string sql = "update time set date='" + content + "' where topicid=" + id;
                    if (!Database.updateData(sql))
                        MessageBox.Show("Cập nhật thất bại!");
                    else
                    {
                        clstable.setViewTopic("Niên luận", cboViewSemesterNL.Text, cboViewSYNL.Text);
                    }
                }
            }
        }

        private void dgvViewStudentNL_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvViewStudentNL.CurrentRow.IsNewRow && topicid != null) {
                new frmAddStudent(topicid).ShowDialog();
                clstable.setViewStudent("Niên luận", topicid);
                return;
            }
            string id, studentid;
            try
            {
                studentid = dgvViewStudentNL.CurrentRow.Cells[0].Value.ToString();
                id = dgvViewStudentNL.CurrentRow.Cells[6].Value.ToString();
            }
            catch
            {
                return;
            }
            string sql=null, content;
            switch (dgvViewStudentNL.CurrentCellAddress.X) {
                case 0:
                    return;
                case 1:
                    content = new InputBox(50).getText();
                    if (content == null)
                        return;
                    sql = "update student set studentname=N'" + content + "' where studentid='" +
                        studentid + "'";
                    break;

                case 2:
                    content = new Dialog.StatusBox().getText();
                    if (content == null)
                        return;
                    sql = "update topicdetail set status=N'" + content + "' where id=" + id;
                    break;

                case 3:
                    if (dgvViewStudentNL.CurrentCell.Value.ToString() == "")
                        content = new InputBox(4, "Nhập điểm mới cho sinh viên").getText();
                    else
                        content = new InputBox(4, "Nhập điểm thay thế").getText();
                    if (content == null)
                        return;
                    sql = "update topicdetail set mark=" + Math.Round(double.Parse(content),1) + " where id=" + id;
                    break;

                case 4:
                    return;

                case 5:
                    content = new InputBox(8).getText();
                    if (content == null)
                        return;
                    sql = "update student set specializedid='" + content + "' where studentid='" +
                        studentid + "'";
                    break;
            }
            if (MessageBox.Show("Xác nhận cập nhật?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            if (!Database.updateData(sql))
                MessageBox.Show("Cập nhật thất bại!");
            else {
                if (dgvViewStudentNL.CurrentCellAddress.X == 3) clstable.tinhDiem2(id);
                clstable.setViewStudent("Niên luận", topicid);
            }
        }

        private void pnlViewDA_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlViewDA.Visible == true)
            {
                List<String> list = Database.getSingelData("Select distinct schoolyear from time ti, topic t where t.topicid=ti.topicid and typeoftopic=N'Đồ án'", "string");
                cboViewSchoolYearDA.DataSource = list;
                cboViewSemesterDA.SelectedIndex = 0;
                clstable.setViewTopic("Đồ án", cboViewSemesterDA.Text, cboViewSchoolYearDA.Text);
            }
        }

        private void dgvViewTopicDA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                topicid = dgvViewTopicDA.CurrentRow.Cells[0].Value.ToString();
                clstable.setViewStudent("Đồ án", topicid);
            }
            catch { }
        }

        private void dgvViewTopicDA_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id;
            try
            {
                id = dgvViewTopicDA.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                return;
            }
            if (dgvViewTopicDA.CurrentCellAddress.X == 1)
            {
                if (MessageBox.Show("Xác nhận cập nhật?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string content = new InputBox(500).getText();
                    if (content == null)
                        return;
                    string sql = "update topic set topicname=N'" + content + "' where topicid=" + id;
                    if (!Database.updateData(sql))
                        MessageBox.Show("Cập nhật thất bại!");
                    else
                    {
                        clstable.setViewTopic("Đồ án", cboViewSemesterDA.Text, cboViewSchoolYearDA.Text);
                    }
                }
            }
            if (dgvViewTopicDA.CurrentCellAddress.X == 2)
            {
                if (MessageBox.Show("Xác nhận cập nhật?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string content = new InputBox(10).getText();
                    if (content == null)
                        return;
                    string sql = "update time set date='" + content + "' where topicid=" + id;
                    if (!Database.updateData(sql))
                        MessageBox.Show("Cập nhật thất bại!");
                    else
                    {
                        clstable.setViewTopic("Đồ án", cboViewSemesterDA.Text, cboViewSchoolYearDA.Text);
                    }
                }  
            }
        }

        private void dgvViewStudentDA_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvViewStudentDA.CurrentRow.IsNewRow) {
                if (topicid == null) return;
                new frmAddStudent(topicid).ShowDialog();
                clstable.setViewStudent("Đồ án", topicid);
                return;
            }
            string id, studentid;
            try
            {
                studentid = dgvViewStudentDA.CurrentRow.Cells[0].Value.ToString();
                id = dgvViewStudentDA.CurrentRow.Cells[6].Value.ToString();
            }
            catch
            {
                return;
            }
            string sql = null, content;
            switch (dgvViewStudentDA.CurrentCellAddress.X)
            {
                case 0:
                    return;
                case 1:
                    content = new InputBox(50).getText();
                    if (content == null)
                        return;
                    sql = "update student set studentname=N'" + content + "' where studentid='" +
                        studentid + "'";
                    break;

                case 2:
                    content = new Dialog.StatusBox().getText();
                    if (content == null)
                        return;
                    sql = "update topicdetail set status=N'" + content + "' where id=" + id;
                    break;

                case 3:
                    if (dgvViewStudentDA.CurrentCell.Value.ToString() == "")
                        content = new InputBox(10,"Nhập điểm mới cho sinh viên").getText();
                    else
                        content = new InputBox(10,"Nhập điểm thay thế").getText();
                    if (content == null)
                        return;
                    sql = "update topicdetail set mark=" + Math.Round(double.Parse(content), 1) + " where id=" + id;
                    break;

                case 4:
                    return;

                case 5:
                    content = new InputBox(8).getText();
                    if (content == null)
                        return;
                    sql = "update student set specializedid='" + content + "' where studentid='" +
                        studentid + "'";
                    break;
            }
            if (MessageBox.Show("Xác nhận cập nhật?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
                if (!Database.updateData(sql))
                MessageBox.Show("Cập nhật thất bại!");
            else {
                if (dgvViewStudentDA.CurrentCellAddress.X == 3) clstable.tinhDiem2(id);
                clstable.setViewStudent("Đồ án", topicid);
            }
        }

        private void txtSearchDA_TextChanged(object sender, EventArgs e)
        {
            clstable.setViewTopic("Đồ án", cboViewSemesterDA.Text, cboViewSchoolYearDA.Text, txtSearchDA.Text);
        }

        private void cboViewSemesterDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            clstable.setViewTopic("Đồ án", cboViewSemesterDA.Text, cboViewSchoolYearDA.Text);
        }

        private void cboViewSchoolYearDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            clstable.setViewTopic("Đồ án", cboViewSemesterDA.Text, cboViewSchoolYearDA.Text);
        }

        private void dgvViewTopicDA_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvViewStudentDA.Rows.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string role = null;
            if (txtBoxTenDeTai.Text == "") {
                MessageBox.Show("Chưa nhập tên đề tài!");
                return;
            }
            if (rdbtnLV.Checked) {
                role = cboRole.SelectedItem.ToString();
            }
            string sql;
            string type="";
            if (rdbtnLV.Checked == true) type = rdbtnLV.Text;
            if (rdbtnNL.Checked == true) type = rdbtnNL.Text;
            if (rdbtnDA.Checked == true) type = rdbtnDA.Text;
            sql = "insert into topic values(N'" + txtBoxTenDeTai.Text.Trim() + "',N'" + type + "')";
            Database.updateData(sql);
            List<string> list = Database.getSingelData("select max(topicid) from topic", "int");
            sql = "insert into time values('" + cboImportSchoolYear.Text + "'," + cboImportSemester.Text
                    + ",'" + DataTimePicker.Text + "'," + list[0] + ")";
            Database.updateData(sql);
            if (role != null)
            {
                List<string> list2 = Database.getSingelData("select name from account", "string");
                sql = "insert into guider values('" + Database.getSingelData("select lecturerid from account", "string")[0] + "',N'" + list2[0] + "',N'" + role + "'," + list[0] + ")";
                Database.updateData(sql);
            }
            for (int i = 0; i < dataGridView2.RowCount; i++) {
                if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "") continue;
                try
                {
                    dataGridView2.Rows[i].Cells[0].Value.ToString();
                }
                catch {
                    continue;
                }
                string id = dataGridView2.Rows[i].Cells[1].Value.ToString().Trim();
                string name = dataGridView2.Rows[i].Cells[2].Value.ToString().Trim() + " " + dataGridView2.Rows[i].Cells[3].Value.ToString().Trim();
                string specializedid = dataGridView2.Rows[i].Cells[5].Value.ToString().Trim();
                sql = "insert into student values('" + id + "',N'" + name + "','" + specializedid + "')";
                Database.updateData(sql);
                sql = "insert into topicdetail(topicid,status,studentid) values(" + list[0] + ",N'Chưa hoàn thành','" + id + "')";
                Database.updateData(sql);
            }
            MessageBox.Show("Quá trình thêm hoàn tất.");
            String Address = @"SELECT * FROM [Sheet1$B7:F100]";
            DataTable dt = ReadDataFromExcelFile(Address, urlStudent);
            try
            {
                dataGridView2.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
            }
            count = 0;
            lbStdNum.Text = "0";
        }

        private void rdbtnLV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnLV.Checked)
            {
                cboRole.Enabled = true;
                cboRole.SelectedIndex = 0;
            }
            else {
                cboRole.Enabled = false;
            }
        }

        private void dgvViewTopicNL_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgvViewStudentNL.Rows.Clear();
            topicid = null;
        }

        private void dgvViewTopicDA_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgvViewStudentDA.Rows.Clear();
            topicid = null;
        }

        private void pnlMarkLV_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlMarkLV.Visible == true)
            {
                List<String> list = Database.getSingelData("Select distinct schoolyear from time ti, topic t where ti.topicid = t.topicid and typeoftopic=N'Luận văn'", "string");
                cboMarkSchoolYearLV.DataSource = list;
                cboMarkSemesterLV.SelectedIndex = 0;
                clstable.setViewTopic("Luận văn", cboViewSemesterNL.Text, cboViewSYNL.Text);
            }
        }

        private void cboMarkSchoolYearLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            clstable.setViewTopic("Luận văn", cboMarkSemesterLV.Text, cboMarkSchoolYearLV.Text);
        }

        private void cboMarkSemesterLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            clstable.setViewTopic("Luận văn", cboMarkSemesterLV.Text, cboMarkSchoolYearLV.Text);
        }

        private void txtSearchLV_TextChanged(object sender, EventArgs e)
        {
            clstable.setViewTopic("Luận văn", cboMarkSemesterLV.Text, cboMarkSchoolYearLV.Text, txtSearchLV.Text);
        }

        private void dgvMarkStudentLV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                markID = dgvMarkStudentLV.CurrentRow.Cells[6].Value.ToString();
                clstable.setMarker(dgvMarkStudentLV.CurrentRow.Cells[6].Value.ToString());
                txtMarkTopic.Text = dgvMarkTopicLV.CurrentRow.Cells[1].Value.ToString().Trim();
                txtMarkStudent.Text = dgvMarkStudentLV.CurrentRow.Cells[1].Value.ToString().Trim();
            }
            catch { }
        }

        private void dgvMarkTopicLV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgvMarkStudentLV.Rows.Clear();
        }

        private void dgvMarkTopicLV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                topicid = dgvMarkTopicLV.CurrentRow.Cells[0].Value.ToString();
                clstable.setViewStudent("Luận văn", topicid);
            }
            catch { }
        }

        private void dgvMarkStudentLV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            markID = null;
            txtMarkStudent.Text = "";
            txtMarkTopic.Text = "";
            dgvMarkMarkerLV.Rows.Clear();
        }

        private void btnMarkInput_Click(object sender, EventArgs e)
        {
            if (markID == null)
            {
                MessageBox.Show("Mời chọn sinh viên cần nhập điểm?");
                return;
            }
            if (radType1.Checked)
            {
                string date = Database.getSingelData("select date from time where topicid=" + topicid, "date")[0];
                new frmMauDiemLV(txtMarkTopic.Text.Trim(),markID,txtMarkStudent.Text,dgvMarkStudentLV.CurrentRow.Cells[0].Value.ToString(),
                   date ).ShowDialog();
                clstable.tinhDiem(markID);
                try
                {
                    dgvMarkStudentLV.CurrentRow.Cells[3].Value = Database.getSingelData("select mark from topicdetail where id=" + markID, "float")[0];
                    dgvMarkStudentLV.CurrentRow.Cells[4].Value = Database.getSingelData("select markchar from topicdetail where id=" + markID, "string")[0];
                }
                catch { }
                clstable.setMarker(markID);

            }
            else {
                new frmNhapDiemHoiDong(markID).ShowDialog();
                clstable.tinhDiem(markID);
                try
                {
                    dgvMarkStudentLV.CurrentRow.Cells[3].Value = Database.getSingelData("select mark from topicdetail where id=" + markID, "float")[0];
                    dgvMarkStudentLV.CurrentRow.Cells[4].Value = Database.getSingelData("select markchar from topicdetail where id=" + markID, "string")[0];
                }
                catch { }
                clstable.setMarker(markID);
            }
        }

        private void pnlStatis_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlStatis.Visible == true)
            {
                cboStatisSchoolYear.DataSource = Database.getSingelData("select distinct schoolyear from time", "string");
                cboStatisSemester.SelectedIndex = 0;
                clsStatis.Statis(cboStatisSemester.Text, cboStatisSchoolYear.Text);
                lblStatisTitle.Text = "HỌC KỲ " + cboStatisSemester.Text + " --- NIÊN KHÓA " + cboStatisSchoolYear.Text;
            }
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                topicid = dgvViewTopicLV.CurrentRow.Cells[0].Value.ToString();
                clstable.setViewStudent("Luận văn view", topicid);
                clstable.setGuider(topicid);
            }
            catch {
            }
        }

        private void dgvViewTopicLV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgvViewStudentLV.Rows.Clear();
            dgvViewGuiderLV.Rows.Clear();
            dgvViewMarkerLV.Rows.Clear();
            topicid = null;
        }

        private void dgvViewStudentLV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dgvViewStudentLV.CurrentRow.Cells[6].Value.ToString();
                clstable.setMarker(id, "View");
            }
            catch {
            }
        }

        private void pnlViewLV_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlViewLV.Visible == true)
            {
                List<String> list = Database.getSingelData("Select distinct schoolyear from time ti, topic t where ti.topicid = t.topicid and typeoftopic=N'Luận văn'", "string");
                cboViewSchoolYearLV.DataSource = list;
                cboViewSemesterLV.SelectedIndex = 0;
                clstable.setViewTopic("Luận văn view", cboViewSemesterLV.Text, cboViewSchoolYearLV.Text);
            }
        }

        private void cboViewSchoolYearLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            clstable.setViewTopic("Luận văn view", cboViewSemesterLV.Text, cboViewSchoolYearLV.Text);
        }

        private void cboViewSemesterLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            clstable.setViewTopic("Luận văn view", cboViewSemesterLV.Text, cboViewSchoolYearLV.Text);
        }

        private void txtViewSearchLV_TextChanged(object sender, EventArgs e)
        {
            clstable.setViewTopic("Luận văn view", cboViewSemesterLV.Text, cboViewSchoolYearLV.Text, txtViewSearchLV.Text);
        }

        private void dgvViewStudentLV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgvViewMarkerLV.Rows.Clear();
        }

        private void dgvViewTopicLV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id;
            try
            {
                id = dgvViewTopicLV.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                return;
            }
            if (dgvViewTopicLV.CurrentCellAddress.X == 1)
            {
                string content = new InputBox(500).getText();
                if (content == null)
                    return;
                if (MessageBox.Show("Xác nhận cập nhật?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string sql = "update topic set topicname=N'" + content + "' where topicid=" + id;
                    if (!Database.updateData(sql))
                        MessageBox.Show("Cập nhật thất bại!");
                    else
                        clstable.setViewTopic("Luận văn view", cboViewSemesterLV.Text, cboViewSchoolYearLV.Text);
                }
            }
            if (dgvViewTopicLV.CurrentCellAddress.X == 2)
            {
                string content = new InputBox(10).getText();
                if (content == null)
                    return;
                if (MessageBox.Show("Xác nhận cập nhật?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string sql = "update time set date='" + content + "' where topicid=" + id;
                    if (!Database.updateData(sql))
                        MessageBox.Show("Cập nhật thất bại!");
                    else
                        clstable.setViewTopic("Luận văn view", cboViewSemesterLV.Text, cboViewSchoolYearLV.Text);
                }
            }
        }

        private void dgvViewStudentLV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvViewStudentLV.CurrentRow.IsNewRow && topicid != null)
            {
                new frmAddStudent(topicid).ShowDialog();
                clstable.setViewStudent("Luận văn view", topicid);
                return;
            }
            string id, studentid;
            try
            {
                id = dgvViewStudentLV.CurrentRow.Cells[6].Value.ToString();
                studentid = dgvViewStudentLV.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                return;
            }
            string sql = null, content;
            switch (dgvViewStudentLV.CurrentCellAddress.X)
            {
                case 0:
                    return;
                case 1:
                    content = new InputBox(50).getText();
                    if (content == null)
                        return;
                    sql = "update student set studentname=N'" + content + "' where studentid='" +
                        studentid + "'";
                    break;

                case 2:
                    content = new Dialog.StatusBox().getText();
                    if (content == null)
                        return;
                    sql = "update topicdetail set status=N'" + content + "' where id=" + id;
                    break;

                case 3:
                    return;

                case 4:
                    return;

                case 5:
                    content = new InputBox(8).getText();
                    if (content == null)
                        return;
                    sql = "update student set specializedid='" + content + "' where studentid='" +
                        studentid + "'";
                    break;
            }
            if (MessageBox.Show("Xác nhận cập nhật?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            if (!Database.updateData(sql))
                MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                clstable.setViewStudent("Luận văn view", topicid);
            }
        }

        private void dgvViewGuiderLV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvViewGuiderLV.CurrentRow.IsNewRow && topicid != null)
            {
                new frmAddGuider(topicid).ShowDialog();
                clstable.setGuider(topicid);
                return;
            }
            string guiderid;
            try
            {
                guiderid = dgvViewGuiderLV.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                return;
            }
            string sql = null, content;
            switch (dgvViewGuiderLV.CurrentCellAddress.X)
            {
                case 0:
                    return;
                case 1:
                    content = new InputBox(50).getText();
                    if (content == null)
                        return;
                    sql = "update guider set guidername=N'" + content + "' where guiderid='" +
                        guiderid + "' and topicid=" + topicid;
                    break;

                case 2:
                    new RoleBox(topicid, guiderid).ShowDialog();
                    clstable.setGuider(topicid);
                    return;
            }
            if (!Database.updateData(sql))
                MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                clstable.setGuider(topicid);
            }
        }

        private void dgvViewMarkerLV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id, markerid;
            try
            {
                id = dgvViewStudentLV.CurrentRow.Cells[6].Value.ToString();
                markerid = dgvViewMarkerLV.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                MessageBox.Show("fsdf");
                return;
            }
            string sql = null, content;
            switch (dgvViewMarkerLV.CurrentCellAddress.X)
            {
                case 0:
                    return;
                case 1:
                    content = new InputBox(50).getText();
                    if (content == null)
                        return;
                    sql = "update marker set markername=N'" + content + "' where markerid='" +
                        markerid + "' and id=" + id;
                    break;

                case 2:
                    content = new InputBox(10).getText();
                    if (content == null)
                        return;
                    sql = "update marker set mark=" + content + " where markerid='" +
                        markerid + "' and id=" + id;
                    break;

                case 3:
                    content = new InputBox(500).getText();
                    if (content == null)
                        return;
                    sql = "update marker set comment=N'" + content + "' where markerid='" +
                        markerid + "' and id=" + id;
                    break;
            }
            if (!Database.updateData(sql))
                MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Cập nhật hoàn tất.");
                clstable.tinhDiem(id);
                dgvViewStudentLV.CurrentRow.Cells[3].Value = Database.getSingelData("select mark from topicdetail where id=" + id, "float")[0];
                dgvViewStudentLV.CurrentRow.Cells[4].Value = Database.getSingelData("select markchar from topicdetail where id=" + id, "string")[0];
                clstable.setMarker(id, "View");
            }
        }

        private void cboStatisSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsStatis.Statis(cboStatisSemester.Text, cboStatisSchoolYear.Text);
            lblStatisTitle.Text = "HỌC KỲ " + cboStatisSemester.Text + " --- NIÊN KHÓA " + cboStatisSchoolYear.Text;
        }

        private void cboStatisSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsStatis.Statis(cboStatisSemester.Text, cboStatisSchoolYear.Text);
            lblStatisTitle.Text = "HỌC KỲ " + cboStatisSemester.Text + " --- NIÊN KHÓA " + cboStatisSchoolYear.Text;
        }

        private void cmsDeleteTopic_Click(object sender, EventArgs e)
        {
            cmsDeleteTopic.Hide();
            string topicid = "", type = "", sql = "", notifi = ""; // type là kiểu thể hiện dgv
            if (pnlViewLV.Visible == true)
            {
                type = "Luận văn view";
                try
                {
                    topicid = dgvViewTopicLV.CurrentRow.Cells[0].Value.ToString();
                    notifi = "Vị trí đã chọn:\n - " + topicid + "\n - " + dgvViewTopicLV.CurrentRow.Cells[1].Value.ToString()
                        + "\n - " + dgvViewTopicLV.CurrentRow.Cells[2].Value.ToString() + "\n\nXác nhận xóa?";
                }
                catch
                {
                    MessageBox.Show("Mời chọn dữ liệu cần xóa?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (pnlViewNL.Visible == true)
            {
                type = "Niên luận";
                try
                {
                    topicid = dgvViewTopicNL.CurrentRow.Cells[0].Value.ToString();
                    notifi = "Vị trí đã chọn:\n - " + topicid + "\n - " + dgvViewTopicNL.CurrentRow.Cells[1].Value.ToString()
                        + "\n - " + dgvViewTopicNL.CurrentRow.Cells[2].Value.ToString() + "\n\nXác nhận xóa?";
                }
                catch
                {
                    MessageBox.Show("Mời chọn dữ liệu cần xóa?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (pnlViewDA.Visible == true)
            {
                type = "Đồ án";
                try
                {
                    topicid = dgvViewTopicDA.CurrentRow.Cells[0].Value.ToString();
                    notifi = "Vị trí đã chọn:\n - " + topicid + "\n - " + dgvViewTopicDA.CurrentRow.Cells[1].Value.ToString()
                        + "\n - " + dgvViewTopicDA.CurrentRow.Cells[2].Value.ToString() + "\n\nXác nhận xóa?";
                }
                catch
                {
                    MessageBox.Show("Mời chọn dữ liệu cần xóa?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (MessageBox.Show(notifi, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (MessageBox.Show("Thao tác này sẽ làm toàn bộ dữ liệu liên quan đều bị xóa. Bạn thực sự muốn xóa?", "Xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    switch (type)
                    {
                        case "Luận văn view":
                            sql = "delete from guider where topicid=" + topicid;
                            Database.updateData(sql);
                            sql = "delete from time where topicid=" + topicid;
                            Database.updateData(sql);
                            for (int i = 0; i < dgvViewStudentLV.RowCount; i++)
                            {
                                sql = "delete from marker where id=" + dgvViewStudentLV.Rows[i].Cells[6].Value.ToString();
                                Database.updateData(sql);
                                sql = "delete from student where studentid='" + dgvViewStudentLV.Rows[i].Cells[0].Value + "'";
                                Database.updateData(sql);
                                sql = "delete from topicdetail where topicid=" + topicid;
                                Database.updateData(sql);
                                sql = "delete from topic where topicid=" + topicid;
                                Database.updateData(sql);
                                clstable.setViewTopic(type, cboViewSemesterLV.Text, cboViewSchoolYearLV.Text);
                            }
                            break;

                        case "Đồ án":
                            sql = "delete from time where topicid=" + topicid;
                            Database.updateData(sql);
                            sql = "delete from topicdetail where topicid=" + topicid;
                            Database.updateData(sql);
                            sql = "delete from topic where topicid=" + topicid;
                            Database.updateData(sql);
                            for (int i = 0; i < dgvViewStudentDA.RowCount; i++)
                            {
                                sql = "delete from student where studentid='" + dgvViewStudentDA.Rows[i].Cells[0].Value + "'";
                                Database.updateData(sql);
                            }
                            clstable.setViewTopic(type, cboViewSemesterDA.Text, cboViewSchoolYearDA.Text);
                            break;

                        case "Niên luận":
                            sql = "delete from time where topicid=" + topicid;
                            Database.updateData(sql);
                            sql = "delete from topicdetail where topicid=" + topicid;
                            Database.updateData(sql);
                            sql = "delete from topic where topicid=" + topicid;
                            Database.updateData(sql);
                            for (int i = 0; i < dgvViewStudentDA.RowCount; i++)
                            {
                                sql = "delete from student where studentid='" + dgvViewStudentNL.Rows[i].Cells[0].Value + "'";
                                Database.updateData(sql);
                            }
                            clstable.setViewTopic(type, cboViewSemesterNL.Text, cboViewSYNL.Text);
                            break;
                    }
                }
            }
        }

        private void cmsDeleteStudent_Click(object sender, EventArgs e)
        {
            cmsDeleteStudent.Hide();
            string id = "", sql = "", type = "", notifi = "";
            if (pnlViewLV.Visible == true) {
                type = "Luận văn view";
                try
                {
                    id = dgvViewStudentLV.CurrentRow.Cells[6].Value.ToString();
                    notifi = "Vị trí đã chọn:\n - " + dgvViewStudentLV.CurrentRow.Cells[0].Value.ToString()
                        + "\n - " + dgvViewStudentLV.CurrentRow.Cells[1].Value.ToString() + "\n - "
                        + dgvViewStudentLV.CurrentRow.Cells[2].Value.ToString() + "\n - "
                        + dgvViewStudentLV.CurrentRow.Cells[3].Value.ToString() + "\n - "
                        + dgvViewStudentLV.CurrentRow.Cells[4].Value.ToString() + "\n - "
                        + dgvViewStudentLV.CurrentRow.Cells[5].Value.ToString() + "\n\nXác nhận xóa?";
                }
                catch {
                    MessageBox.Show("Mời chọn dữ liệu cần xóa?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (pnlViewNL.Visible == true) {
                type = "Niên luận";
                try
                {
                    id = dgvViewStudentNL.CurrentRow.Cells[6].Value.ToString();
                    notifi = "Vị trí đã chọn:\n - " + dgvViewStudentNL.CurrentRow.Cells[0].Value.ToString()
                    + "\n - " + dgvViewStudentNL.CurrentRow.Cells[1].Value.ToString() + "\n - "
                    + dgvViewStudentNL.CurrentRow.Cells[2].Value.ToString() + "\n - "
                    + dgvViewStudentNL.CurrentRow.Cells[3].Value.ToString() + "\n - "
                    + dgvViewStudentNL.CurrentRow.Cells[4].Value.ToString() + "\n - "
                    + dgvViewStudentNL.CurrentRow.Cells[5].Value.ToString() + "\n\nXác nhận xóa?";
                }
                catch
                {
                    MessageBox.Show("Mời chọn dữ liệu cần xóa?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (pnlViewDA.Visible == true) {
                type = "Đồ án";
                try
                {
                    id = dgvViewStudentDA.CurrentRow.Cells[6].Value.ToString();
                    notifi = "Vị trí đã chọn:\n - " + dgvViewStudentDA.CurrentRow.Cells[0].Value.ToString()
                    + "\n - " + dgvViewStudentDA.CurrentRow.Cells[1].Value.ToString() + "\n - "
                    + dgvViewStudentDA.CurrentRow.Cells[2].Value.ToString() + "\n - "
                    + dgvViewStudentDA.CurrentRow.Cells[3].Value.ToString() + "\n - "
                    + dgvViewStudentDA.CurrentRow.Cells[4].Value.ToString() + "\n - "
                    + dgvViewStudentDA.CurrentRow.Cells[5].Value.ToString() + "\n\nXác nhận xóa?";
                }
                catch
                {
                    MessageBox.Show("Mời chọn dữ liệu cần xóa?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (MessageBox.Show(notifi, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                switch (type)
                {
                    case "Luận văn view":
                        sql = "delete from marker where id=" + id;
                        Database.updateData(sql);
                        sql = "delete from topicdetail where id=" + id;
                        Database.updateData(sql);
                        sql = "delete from student where studentid='" + id + "'";
                        Database.updateData(sql);
                        break;

                    case "Niên luận":
                        sql = "delete from topicdetail where id=" + id;
                        Database.updateData(sql);
                        sql = "delete from student where studentid='" + id + "'";
                        Database.updateData(sql);
                        break;

                    case "Đồ án":
                        sql = "delete from topicdetail where id=" + id;
                        Database.updateData(sql);
                        sql = "delete from student where studentid='" + id + "'";
                        Database.updateData(sql);
                        break;
                }
                clstable.setViewStudent(type, topicid);
            }
        }

        private void cmsDeleteGuider_Click(object sender, EventArgs e)
        {
            cmsDeleteGuider.Hide();
            string notifi = "";
            try
            {
                notifi = "Vị trí đã chọn:\n - " + dgvViewGuiderLV.CurrentRow.Cells[0].Value.ToString()
                + "\n - " + dgvViewGuiderLV.CurrentRow.Cells[1].Value.ToString() + "\n - "
                + dgvViewGuiderLV.CurrentRow.Cells[2].Value.ToString() + "\n\nXác nhận xóa?";
            }
            catch {
                MessageBox.Show("Mời chọn dữ liệu cần xóa?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show(notifi, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                string sql = "delete from guider where topicid=" + topicid + " and guiderid='" + dgvViewGuiderLV.CurrentRow.Cells[0].Value + "'";
                Database.updateData(sql);
                clstable.setGuider(topicid);
            }
        }

        private void cmsDeleteMarker_Click(object sender, EventArgs e)
        {
            cmsDeleteMarker.Hide();
            string notifi = "";
            try
            {
                notifi = "Vị trí đã chọn:\n - " + dgvViewMarkerLV.CurrentRow.Cells[0].Value.ToString()
                + "\n - " + dgvViewMarkerLV.CurrentRow.Cells[1].Value.ToString() + "\n - "
                + dgvViewMarkerLV.CurrentRow.Cells[2].Value.ToString() + "\n - ";
                if (dgvViewMarkerLV.CurrentRow.Cells[3].Value.ToString().Length > 20)
                {
                    notifi += dgvViewMarkerLV.CurrentRow.Cells[3].Value.ToString().Substring(0, 20) + "...\n\nXác nhận xóa?";
                }
                else
                    notifi += dgvViewMarkerLV.CurrentRow.Cells[3].Value.ToString() + "\n\nXác nhận xóa?";
            }
            catch
            {
                MessageBox.Show("Mời chọn dữ liệu cần xóa?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show(notifi, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                string id = dgvViewStudentLV.CurrentRow.Cells[6].Value.ToString();
                string sql = "delete from marker where id=" + id + " and markerid='" + dgvViewMarkerLV.CurrentRow.Cells[0].Value + "'";
                Database.updateData(sql);
                clstable.tinhDiem(id);
                try {
                    dgvViewStudentLV.CurrentRow.Cells[3].Value = Database.getSingelData("select mark from topicdetail where id=" + id, "float")[0];
                    dgvViewStudentLV.CurrentRow.Cells[4].Value = Database.getSingelData("select markchar from topicdetail where id=" + id, "string")[0];
                }
                catch
                {
                    dgvViewStudentLV.CurrentRow.Cells[3].Value = "";
                    dgvViewStudentLV.CurrentRow.Cells[4].Value = "";
                    dgvViewStudentLV.CurrentRow.Cells[2].Value = "Chưa hoàn thành";
                    dgvViewMarkerLV.Rows.Clear();
                }
                clstable.setMarker(id, "View");
            }
        }

        private void btnInputLV_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
