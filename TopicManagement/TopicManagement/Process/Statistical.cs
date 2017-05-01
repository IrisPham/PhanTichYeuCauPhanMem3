using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TopicManagement.Process
{
    class Statistical
    {
        private Main main;

        public Statistical(Main main)
        {
            this.main = main;
        }

        private void setTopic(int luanVan, int nienLuan, int doAn) {
            int max = 1;
            if (luanVan > max) max = luanVan;
            if (nienLuan > max) max = nienLuan;
            if (doAn > max) max = doAn;

            main.lblLuanVan2.Text = luanVan.ToString();
            main.lblNienLuan2.Text = nienLuan.ToString();
            main.lblDoAn2.Text = doAn.ToString();
            main.lblTopic.Text = (luanVan + nienLuan + doAn).ToString();

            main.lblLuanVan.Height = luanVan * 200 / max;
            main.lblNienLuan.Height = nienLuan * 200 / max;
            main.lblDoAn.Height = doAn * 200 / max;

            main.lblLuanVan.Location = new Point(main.lblLuanVan.Location.X, 274 - main.lblLuanVan.Height);
            main.lblLuanVan2.Location = new Point(main.lblLuanVan2.Location.X, main.lblLuanVan.Location.Y - 18);
            main.lblNienLuan.Location = new Point(main.lblNienLuan.Location.X, 274 - main.lblNienLuan.Height);
            main.lblNienLuan2.Location = new Point(main.lblNienLuan2.Location.X, main.lblNienLuan.Location.Y - 18);
            main.lblDoAn.Location = new Point(main.lblDoAn.Location.X, 274 - main.lblDoAn.Height);
            main.lblDoAn2.Location = new Point(main.lblDoAn2.Location.X, main.lblDoAn.Location.Y - 18);
        }

        /*
         * 0 - Chưa hoàn thành
         * 1 - Hoàn thành
         */
        private void setTopicStatus(int[] luanVan, int[] nienLuan, int[] doAn)
        {
            //Set gia tri
            int max = 1;
            for (int i = 0; i < 2; i++)
            {
                if (luanVan[i] > max)
                    max = luanVan[i];
                if (nienLuan[i] > max)
                    max = nienLuan[i];
                if (doAn[i] > max)
                    max = doAn[i];
            }
            main.lblCLuanVan.Height = luanVan[0] * 200 / max;
            main.lblCLuanVan2.Text = luanVan[0].ToString();
            main.lblHLuanVan.Height = luanVan[1] * 200 / max;
            main.lblHLuanVan2.Text = luanVan[1].ToString();

            main.lblCNienLuan.Height = nienLuan[0] * 200 / max;
            main.lblCNienLuan2.Text = nienLuan[0].ToString();
            main.lblHNienLuan.Height = nienLuan[1] * 200 / max;
            main.lblHNienLuan2.Text = nienLuan[1].ToString();

            main.lblCDoAn.Height = doAn[0] * 200 / max;
            main.lblCDoAn2.Text = doAn[0].ToString();
            main.lblHDoAn.Height = doAn[1] * 200 / max;
            main.lblHDoAn2.Text = doAn[1].ToString();

            //set vi tri - chuan 55
            main.lblCLuanVan.Location = new Point(main.lblCLuanVan.Location.X, 274 - main.lblCLuanVan.Height);
            main.lblCLuanVan2.Location = new Point(main.lblCLuanVan2.Location.X, main.lblCLuanVan.Location.Y - 18);
            main.lblCNienLuan.Location = new Point(main.lblCNienLuan.Location.X, 274 - main.lblCNienLuan.Height);
            main.lblCNienLuan2.Location = new Point(main.lblCNienLuan2.Location.X, main.lblCNienLuan.Location.Y - 18);
            main.lblCDoAn.Location = new Point(main.lblCDoAn.Location.X, 274 - main.lblCDoAn.Height);
            main.lblCDoAn2.Location = new Point(main.lblCDoAn2.Location.X, main.lblCDoAn.Location.Y - 18);

            main.lblHLuanVan.Location = new Point(main.lblHLuanVan.Location.X, 274 - main.lblHLuanVan.Height);
            main.lblHLuanVan2.Location = new Point(main.lblHLuanVan2.Location.X, main.lblHLuanVan.Location.Y - 18);
            main.lblHNienLuan.Location = new Point(main.lblHNienLuan.Location.X, 274 - main.lblHNienLuan.Height);
            main.lblHNienLuan2.Location = new Point(main.lblHNienLuan2.Location.X, main.lblHNienLuan.Location.Y - 18);
            main.lblHDoAn.Location = new Point(main.lblHDoAn.Location.X, 274 - main.lblHDoAn.Height);
            main.lblHDoAn2.Location = new Point(main.lblHDoAn2.Location.X, main.lblHDoAn.Location.Y - 18);

            main.lblTopicStatus.Text = (luanVan[0] + luanVan[1] + nienLuan[0] + nienLuan[1] + doAn[0] + doAn[1]).ToString();
        }

        /*
         * 0 - Đúng hạn
         * 1 - Trễ hạn
         */
        private void setCompleteStatus(int[] luanVan, int[] nienLuan)
        {
            //Set gia tri
            int max = 1;
            for (int i = 0; i < 2; i++)
            {
                if (luanVan[i] > max)
                    max = luanVan[i];
                if (nienLuan[i] > max)
                    max = nienLuan[i];
            }
            main.lblDHLuanVan.Height = luanVan[0] * 200 / max;
            main.lblDHLuanVan2.Text = luanVan[0].ToString();
            main.lblDHNienLuan.Height = nienLuan[0] * 200 / max;
            main.lblDHNienLuan2.Text = nienLuan[0].ToString();

            main.lblTHLuanVan.Height = luanVan[1] * 200 / max;
            main.lblTHLuanVan2.Text = luanVan[1].ToString();
            main.lblTHNienLuan.Height = nienLuan[1] * 200 / max;
            main.lblTHNienLuan2.Text = nienLuan[1].ToString();

            //Set vi tri - chuan 55
            main.lblDHLuanVan.Location = new Point(main.lblDHLuanVan.Location.X, 274 - main.lblDHLuanVan.Height);
            main.lblDHLuanVan2.Location = new Point(main.lblDHLuanVan2.Location.X, main.lblDHLuanVan.Location.Y - 18);
            main.lblDHNienLuan.Location = new Point(main.lblDHNienLuan.Location.X, 274 - main.lblDHNienLuan.Height);
            main.lblDHNienLuan2.Location = new Point(main.lblDHNienLuan2.Location.X, main.lblDHNienLuan.Location.Y - 18);

            main.lblTHLuanVan.Location = new Point(main.lblTHLuanVan.Location.X, 274 - main.lblTHLuanVan.Height);
            main.lblTHLuanVan2.Location = new Point(main.lblTHLuanVan2.Location.X, main.lblTHLuanVan.Location.Y - 18);
            main.lblTHNienLuan.Location = new Point(main.lblTHNienLuan.Location.X, 274 - main.lblTHNienLuan.Height);
            main.lblTHNienLuan2.Location = new Point(main.lblTHNienLuan2.Location.X, main.lblTHNienLuan.Location.Y - 18);

            main.lblCompleteStatus.Text = (luanVan[0] + luanVan[1] + nienLuan[0] + nienLuan[1]).ToString();
        }

        private void setRole(int hdc, int dhd)
        {
            int max = 1;
            if (hdc > max)
                max = hdc;
            if (dhd > max)
                max = dhd;
            main.lblHDC.Height = hdc * 200 / max;
            main.lblHDC2.Text = hdc.ToString();
            main.lblDHD.Height = dhd * 200 / max;
            main.lblDHD2.Text = dhd.ToString();

            main.lblHDC.Location = new Point(main.lblHDC.Location.X, 274 - main.lblHDC.Height);
            main.lblHDC2.Location = new Point(main.lblHDC2.Location.X, main.lblHDC.Location.Y - 18);
            main.lblDHD.Location = new Point(main.lblDHD.Location.X, 274 - main.lblDHD.Height);
            main.lblDHD2.Location = new Point(main.lblDHD2.Location.X, main.lblDHD.Location.Y - 18);

            main.lblRole.Text = (dhd + hdc).ToString();
        }

        /*
         * 0 - Đúng hạn + hướng dẫn chính
         * 1 - Đúng hạn + đồng hướng dẫn
         * 2 - Trễ hạn + hướng dẫn chính
         * 3 - Trễ hạn + đồng hướng dẫn
         */
        private void setToolTipCompleteStatus(string[] luanVan)
        {
            main.tltDetail.ToolTipTitle = "Thông tin chi tiết";
            main.tltDetail.SetToolTip(main.lblDHLuanVan, "Số lượng hướng dẫn chính: " + luanVan[0] + "\r\n"
                + "Số lượng đồng hướng dẫn: " + luanVan[1]);
            main.tltDetail.SetToolTip(main.lblTHLuanVan, "Số lượng hướng dẫn chính: " + luanVan[2] + "\r\n"
                + "Số lượng đồng hướng dẫn: " + luanVan[3]);
        }
        /*
         * 0 - Hướng dẫn chính - đúng hạn
         * 1 - Hướng dẫn chính - trễ hạn
         * 2 - Đồng hướng dẫn - đúng hạn
         * 3 - Đồng hướng dẫn - trễ hạn
         */
        private void setToolTipRole(string[] luanVan)
        {
            main.tltDetail.ToolTipTitle = "Thông tin chi tiết";
            main.tltDetail.SetToolTip(main.lblHDC, "Số lượng hoàn thành đúng hạn: " + luanVan[0] + "\r\n"
                + "Số lượng hoàn thành trễ hạn: " + luanVan[1]);
            main.tltDetail.SetToolTip(main.lblDHD, "Số lượng hoàn thành đúng hạn: " + luanVan[2] + "\r\n"
                + "Số lượng hoàn thành trễ hạn: " + luanVan[3]);
        }

        private int getData(string schoolyear, string semester, string type, string status)
        {
            string sql;
            sql = "select count(*) from topicdetail d, topic t, time ti where t.topicid = ti.topicid " +
                "and t.topicid=d.topicid and schoolyear='" + schoolyear + "' and " +
                "semester=" + semester + " and typeoftopic=N'" + type + "' and status=N'" + status + "'";
            
            List<string> list = Database.getSingelData(sql,"int");
            return int.Parse(list[0]);
        }

        public void Statis(string semester, string schoolyear)
        {
            if (semester == "" || schoolyear == "") return;
            //set so luong de tai
            string sql;
            sql = "select count(*) from topic t, time ti where t.topicid = ti.topicid and semester=" + semester + " and schoolyear='" + schoolyear + "' and typeoftopic=N'Luận văn'";
            int tluanVan = int.Parse(Database.getSingelData(sql, "int")[0]);
            sql = "select count(*) from topic t, time ti where t.topicid = ti.topicid and semester=" + semester + " and schoolyear='" + schoolyear + "' and typeoftopic=N'Niên luận'";
            int tnienLuan = int.Parse(Database.getSingelData(sql, "int")[0]);
            sql = "select count(*) from topic t, time ti where t.topicid = ti.topicid and semester=" + semester + " and schoolyear='" + schoolyear + "' and typeoftopic=N'Đồ án'";
            int tdoAn = int.Parse(Database.getSingelData(sql, "int")[0]);
            setTopic(tluanVan, tnienLuan, tdoAn);

            //set trang thai de tai
            int[] luanVan = new int[2]; //0 - chưa hoàn thành. 1 - hoàn thành
            int[] nienLuan = new int[2];
            int[] doAn = new int[2];
            luanVan[0] = getData(schoolyear, semester, "Luận văn", "Chưa hoàn thành");
            luanVan[1] = getData(schoolyear, semester, "Luận văn", "Đã hoàn thành") +
                getData(schoolyear, semester, "Luận văn", "Đã hoàn thành (trễ hạn)");
            nienLuan[0] = getData(schoolyear, semester, "Niên luận", "Chưa hoàn thành");
            nienLuan[1] = getData(schoolyear, semester, "Niên luận", "Đã hoàn thành") +
                getData(schoolyear, semester, "Niên luận", "Đã hoàn thành (trễ hạn)");
            doAn[0] = getData(schoolyear, semester, "Đồ án", "Chưa hoàn thành");
            doAn[1] = getData(schoolyear, semester, "Đồ án", "Đã hoàn thành") +
                getData(schoolyear, semester, "Đồ án", "Đã hoàn thành (trễ hạn)");
            setTopicStatus(luanVan, nienLuan, doAn);

            //set trang thai hoan thanh
            //0 - đúng hạn. 1 - trễ hạn
            luanVan[0] = getData(schoolyear, semester, "Luận văn", "Đã hoàn thành");
            luanVan[1] = getData(schoolyear, semester, "Luận văn", "Đã hoàn thành (trễ hạn)");
            nienLuan[0] = getData(schoolyear, semester, "Niên luận", "Đã hoàn thành");
            nienLuan[1] = getData(schoolyear, semester, "Niên luận", "Đã hoàn thành (trễ hạn)");
            setCompleteStatus(luanVan, nienLuan);

            //set vai tro
            sql = "select count(*) from topic t, time ti, guider g where t.topicid = ti.topicid " +
                "and g.topicid=t.topicid and schoolyear='" + schoolyear + "' and " +
                "semester=" + semester + " and typeoftopic=N'Luận văn' and role=N'Hướng dẫn chính'";
            int hdc = int.Parse(Database.getSingelData(sql, "int")[0]);
            sql = "select count(*) from topic t, time ti, guider g where t.topicid = ti.topicid " +
                "and g.topicid=t.topicid and schoolyear='" + schoolyear + "' and " +
                "semester=" + semester + " and typeoftopic=N'Luận văn' and role=N'Đồng hướng dẫn'";
            int dhd = int.Parse(Database.getSingelData(sql, "int")[0]);
            setRole(hdc, dhd);

            //set tooltip
            /*
             * 0 - Đúng hạn + hướng dẫn chính
             * 1 - Đúng hạn + đồng hướng dẫn
             * 2 - Trễ hạn + hướng dẫn chính
             * 3 - Trễ hạn + đồng hướng dẫn
             */
            string[] luanVan2 = new string[4];
            sql = "select count(id) from topic t, topicdetail d, time ti, guider g where t.topicid = ti.topicid " +
                "and g.topicid=t.topicid and d.topicid = t.topicid and schoolyear='" + schoolyear + "' and " +
                "semester=" + semester + " and typeoftopic=N'Luận văn' and role=N'Hướng dẫn chính' and " +
                "status = N'Đã hoàn thành'";
            luanVan2[0] = Database.getSingelData(sql, "int")[0];
            sql = "select count(id) from topic t, topicdetail d, time ti, guider g where t.topicid = ti.topicid " +
                "and g.topicid=t.topicid and d.topicid = t.topicid and schoolyear='" + schoolyear + "' and " +
                "semester=" + semester + " and typeoftopic=N'Luận văn' and role=N'Đồng hướng dẫn' and " +
                "status = N'Đã hoàn thành'";
            luanVan2[1] = Database.getSingelData(sql, "int")[0];
            sql = "select count(id) from topic t, topicdetail d, time ti, guider g where t.topicid = ti.topicid " +
                "and g.topicid=t.topicid and d.topicid = t.topicid and schoolyear='" + schoolyear + "' and " +
                "semester=" + semester + " and typeoftopic=N'Luận văn' and role=N'Hướng dẫn chính' and " +
                "status = N'Đã hoàn thành (trễ hạn)'";
            luanVan2[2] = Database.getSingelData(sql, "int")[0];
            sql = "select count(id) from topic t, topicdetail d, time ti, guider g where t.topicid = ti.topicid " +
                "and g.topicid=t.topicid and d.topicid = t.topicid and schoolyear='" + schoolyear + "' and " +
                "semester=" + semester + " and typeoftopic=N'Luận văn' and role=N'Đồng hướng dẫn' and " +
                "status = N'Đã hoàn thành (trễ hạn)'";
            luanVan2[3] = Database.getSingelData(sql, "int")[0];
            setToolTipCompleteStatus(luanVan2);
            setToolTipRole(luanVan2);
        }
    }
}
