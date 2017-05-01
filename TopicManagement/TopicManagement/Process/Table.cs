using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopicManagement.Process
{
    class Table
    {
        private Main main;

        public Table(Main main) {
            this.main = main;
        }

        public void setViewTopic(String topic, String Semester, String schoolyear, String search="") {
            string sql = "";
            if (topic == "Luận văn view")
            //if (search != "")
            //    sql = "Select t.topicid, topicname from topic t, time ti " +
            //            "where t.topicid = ti.topicid and typeoftopic=N'" + topic + "' " +
            //            "and semester=" + Semester + " and schoolyear='" + schoolyear + "'";
            //else
                sql = "Select t.topicid, topicname, date from topic t, time ti " +
                        "where t.topicid = ti.topicid and typeoftopic=N'Luận văn' " +
                        "and semester=" + Semester + " and schoolyear='" + schoolyear +
                        "' and topicname like N'" + search + "%'";
            else
                sql = "Select t.topicid, topicname, date from topic t, time ti " +
                        "where t.topicid = ti.topicid and typeoftopic=N'" + topic + "' " +
                        "and semester=" + Semester + " and schoolyear='" + schoolyear +
                        "' and topicname like N'" + search + "%'";
            DataTable table = Database.fillDataToTable(sql);
            if (table == null) return;
            if (topic == "Luận văn view")
            {
                main.dgvViewTopicLV.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    main.dgvViewTopicLV.Rows.Add();
                    main.dgvViewTopicLV.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                    main.dgvViewTopicLV.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                    main.dgvViewTopicLV.Rows[i].Cells[2].Value = DateTime.Parse(table.Select()[i].ItemArray[2].ToString().Trim()).ToShortDateString();
                }
            }
            if (topic == "Luận văn")
            {
                main.dgvMarkTopicLV.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    main.dgvMarkTopicLV.Rows.Add();
                    main.dgvMarkTopicLV.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                    main.dgvMarkTopicLV.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                    main.dgvMarkTopicLV.Rows[i].Cells[2].Value = DateTime.Parse(table.Select()[i].ItemArray[2].ToString().Trim()).ToShortDateString();
                }
            }
            if (topic == "Niên luận")
            {
                main.dgvViewTopicNL.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    main.dgvViewTopicNL.Rows.Add();
                    main.dgvViewTopicNL.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                    main.dgvViewTopicNL.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                    main.dgvViewTopicNL.Rows[i].Cells[2].Value = DateTime.Parse(table.Select()[i].ItemArray[2].ToString().Trim()).ToShortDateString();
                }
            }
            if (topic == "Đồ án")
            {
                main.dgvViewTopicDA.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    main.dgvViewTopicDA.Rows.Add();
                    main.dgvViewTopicDA.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                    main.dgvViewTopicDA.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                    main.dgvViewTopicDA.Rows[i].Cells[2].Value = DateTime.Parse(table.Select()[i].ItemArray[2].ToString().Trim()).ToShortDateString();
                }
            }
        }

        public void setViewStudent(String topic, String topicid)
        {
            string sql;
            sql = "select s.studentid, studentname, status, mark, markchar, specializedid, id from student s, topicdetail d " +
                "where topicid = " + topicid + " and d.studentid = s.studentid";
            DataTable table = Database.fillDataToTable(sql);
            if (table == null) return;
            if (topic == "Luận văn view") {
                main.dgvViewStudentLV.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    main.dgvViewStudentLV.Rows.Add();
                    main.dgvViewStudentLV.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                    main.dgvViewStudentLV.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                    main.dgvViewStudentLV.Rows[i].Cells[2].Value = table.Select()[i].ItemArray[2].ToString().Trim();
                    main.dgvViewStudentLV.Rows[i].Cells[3].Value = table.Select()[i].ItemArray[3].ToString().Trim();
                    main.dgvViewStudentLV.Rows[i].Cells[4].Value = table.Select()[i].ItemArray[4].ToString().Trim();
                    main.dgvViewStudentLV.Rows[i].Cells[5].Value = table.Select()[i].ItemArray[5].ToString().Trim();
                    main.dgvViewStudentLV.Rows[i].Cells[6].Value = table.Select()[i].ItemArray[6].ToString().Trim();
                }
            }
            if (topic == "Luận văn")
            {
                main.dgvMarkStudentLV.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    main.dgvMarkStudentLV.Rows.Add();
                    main.dgvMarkStudentLV.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                    main.dgvMarkStudentLV.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                    main.dgvMarkStudentLV.Rows[i].Cells[2].Value = table.Select()[i].ItemArray[2].ToString().Trim();
                    main.dgvMarkStudentLV.Rows[i].Cells[3].Value = table.Select()[i].ItemArray[3].ToString().Trim();
                    main.dgvMarkStudentLV.Rows[i].Cells[4].Value = table.Select()[i].ItemArray[4].ToString().Trim();
                    main.dgvMarkStudentLV.Rows[i].Cells[5].Value = table.Select()[i].ItemArray[5].ToString().Trim();
                    main.dgvMarkStudentLV.Rows[i].Cells[6].Value = table.Select()[i].ItemArray[6].ToString().Trim();
                }
            }
            if (topic == "Niên luận")
            {
                main.dgvViewStudentNL.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    main.dgvViewStudentNL.Rows.Add();
                    main.dgvViewStudentNL.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                    main.dgvViewStudentNL.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                    main.dgvViewStudentNL.Rows[i].Cells[2].Value = table.Select()[i].ItemArray[2].ToString().Trim();
                    main.dgvViewStudentNL.Rows[i].Cells[3].Value = table.Select()[i].ItemArray[3].ToString().Trim();
                    main.dgvViewStudentNL.Rows[i].Cells[4].Value = table.Select()[i].ItemArray[4].ToString().Trim();
                    main.dgvViewStudentNL.Rows[i].Cells[5].Value = table.Select()[i].ItemArray[5].ToString().Trim();
                    main.dgvViewStudentNL.Rows[i].Cells[6].Value = table.Select()[i].ItemArray[6].ToString().Trim();
                }
            }
            if (topic == "Đồ án")
            {
                main.dgvViewStudentDA.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    main.dgvViewStudentDA.Rows.Add();
                    main.dgvViewStudentDA.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                    main.dgvViewStudentDA.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                    main.dgvViewStudentDA.Rows[i].Cells[2].Value = table.Select()[i].ItemArray[2].ToString().Trim();
                    main.dgvViewStudentDA.Rows[i].Cells[3].Value = table.Select()[i].ItemArray[3].ToString().Trim();
                    main.dgvViewStudentDA.Rows[i].Cells[4].Value = table.Select()[i].ItemArray[4].ToString().Trim();
                    main.dgvViewStudentDA.Rows[i].Cells[5].Value = table.Select()[i].ItemArray[5].ToString().Trim();
                    main.dgvViewStudentDA.Rows[i].Cells[6].Value = table.Select()[i].ItemArray[6].ToString().Trim();
                }
            }
        }

        public void setMarker(string id, string type="Mark") {
            string sql;
            sql = "select markerid, markername, mark, comment, id from marker where id=" + id;
            DataTable table = Database.fillDataToTable(sql);
            if (table == null) return;
            if (type == "Mark")
            {
                main.dgvMarkMarkerLV.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    main.dgvMarkMarkerLV.Rows.Add();
                    main.dgvMarkMarkerLV.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                    main.dgvMarkMarkerLV.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                    main.dgvMarkMarkerLV.Rows[i].Cells[2].Value = table.Select()[i].ItemArray[2].ToString().Trim();
                    main.dgvMarkMarkerLV.Rows[i].Cells[3].Value = table.Select()[i].ItemArray[3].ToString().Trim();
                }
            }
            else {
                main.dgvViewMarkerLV.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    main.dgvViewMarkerLV.Rows.Add();
                    main.dgvViewMarkerLV.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                    main.dgvViewMarkerLV.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                    main.dgvViewMarkerLV.Rows[i].Cells[2].Value = table.Select()[i].ItemArray[2].ToString().Trim();
                    main.dgvViewMarkerLV.Rows[i].Cells[3].Value = table.Select()[i].ItemArray[3].ToString().Trim();
                }
            }
        }

        public void tinhDiem(string id) {
            List<string> list = Database.getSingelData("select mark from marker where id=" + id, "float");
            if (list.Count == 0)
            {
                string sql = "update topicdetail set mark=null, markchar=null, status=N'Chưa hoàn thành' where id=" + id;
                Database.updateData(sql);
                return;
            }
            if (list != null)
            {
                double sum = 0;
                for (int i = 0; i < list.Count; i++)
                    sum += double.Parse(list[i]);
                double avg = sum / list.Count;
                avg = Math.Round(avg, 1);
                string mark = "";
                DataTable table = Database.fillDataToTable("select * from mark");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    double min = double.Parse(table.Select()[i].ItemArray[1].ToString());
                    double max = double.Parse(table.Select()[i].ItemArray[2].ToString());
                    if (avg >= min && avg <= max) mark = table.Select()[i].ItemArray[0].ToString();
                }

                string sql = "update topicdetail set mark=" + avg.ToString() + ", markchar='" + mark + "', status=N'Đã hoàn thành' where id=" + id;
                Database.updateData(sql);
            }
        }

        public void setGuider(string topicid) {
            string sql;
            sql = "select guiderid, guidername, role from guider where topicid=" + topicid;
            DataTable table = Database.fillDataToTable(sql);
            if (table == null) return;
            main.dgvViewGuiderLV.Rows.Clear();
            for (int i = 0; i < table.Rows.Count; i++) {
                main.dgvViewGuiderLV.Rows.Add();
                main.dgvViewGuiderLV.Rows[i].Cells[0].Value = table.Select()[i].ItemArray[0].ToString().Trim();
                main.dgvViewGuiderLV.Rows[i].Cells[1].Value = table.Select()[i].ItemArray[1].ToString().Trim();
                main.dgvViewGuiderLV.Rows[i].Cells[2].Value = table.Select()[i].ItemArray[2].ToString().Trim();
            }
        }

        public void tinhDiem2(string id) {
            double mark = double.Parse(Database.getSingelData("select mark from topicdetail where id=" + id, "float")[0]);
            DataTable table = Database.fillDataToTable("select * from mark");
            for (int i = 0; i < table.Rows.Count; i++) {
                double min = double.Parse(table.Select()[i].ItemArray[1].ToString());
                double max = double.Parse(table.Select()[i].ItemArray[2].ToString());
                if (mark >= min && mark <= max) {
                    string sql = "update topicdetail set markchar='" + table.Select()[i].ItemArray[0].ToString() + "', status=N'Đã hoàn thành' where id=" + id;
                    Database.updateData(sql);
                    return;
                }
            }
        }
    }
}
