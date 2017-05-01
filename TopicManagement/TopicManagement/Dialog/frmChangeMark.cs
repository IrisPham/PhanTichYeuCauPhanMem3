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
    public partial class frmChangeMark : Form
    {
        public frmChangeMark()
        {
            InitializeComponent();
            LoadDatabase();
        }
        private void LoadDatabase()
        {
            string sql;
            sql = "select mark,min,max from mark ORDER BY max DESC ";
            DataTable table = Database.fillDataToTable(sql);
            dgvMarkThesis.Rows.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                dgvMarkThesis.Rows.Add();
                dgvMarkThesis.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                dgvMarkThesis.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                dgvMarkThesis.Rows[i].Cells[2].Value = table.Select()[i].ItemArray[2].ToString().Trim();
            }
        }

        //Lưu điểm
        private void btnSaveMark_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(txtMax.Text.Trim()) > 10 || double.Parse(txtMin.Text.Trim()) < 0)
                {
                    MessageBox.Show("Vượt quá giới hạn điểm số!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Sai định dạng điểm!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql = "insert into mark values('" + txtMarkChar.Text.Trim() + "'," + txtMin.Text.Trim()
                + "," + txtMax.Text + ")";
            if (Database.updateData(sql))
            {
                MessageBox.Show("Thêm thành công.");
                LoadDatabase();
                return;
            }
            else
            {
                if (MessageBox.Show("Xác nhận chỉnh sửa điểm '" + txtMarkChar.Text.Trim() + "'?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    sql = "update mark set min=" + txtMin.Text.Trim() + ", max=" + txtMax.Text.Trim() + " where mark='" + txtMarkChar.Text.Trim() + "'";
                    Database.updateData(sql);
                    MessageBox.Show("Chỉnh sửa thành công.");
                    LoadDatabase();
                    return;
                }
            }
        }
        //Xóa điểm
        private void btnDeleteMark_Click(object sender, EventArgs e)
        {
            string markchar = "";
            try
            {
                markchar = dgvMarkThesis.CurrentRow.Cells[0].Value.ToString();
            }
            catch { }
            String sql;
            sql = "delete from mark where mark = '" + markchar + "'";
            if (MessageBox.Show("Xác nhấn xóa điểm " + markchar+ "?","",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Database.updateData(sql);
            }
            LoadDatabase();
        }

        private void dgvMarkThesis_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtMarkChar.Text = "";
            txtMax.Text = "";
            txtMin.Text = "";
        }

        private void dgvMarkThesis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                txtMarkChar.Text = dgvMarkThesis.CurrentRow.Cells[0].Value.ToString();
                txtMin.Text = dgvMarkThesis.CurrentRow.Cells[1].Value.ToString();
                txtMax.Text = dgvMarkThesis.CurrentRow.Cells[2].Value.ToString();
            }
            catch {
            }
        }
    }
}
