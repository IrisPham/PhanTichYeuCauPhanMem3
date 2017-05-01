using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopicManagement
{
    static class Program
    {
        /**
         * Quy tắc đặt tên:
         *      - đối với các bảng trong panel con: [dgv][tên chức năng][tên hiển thị][loại đề tài]
         *      - vd: dgvViewTopicLV
        **/
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new frmMauDiemLV());
            //Application.Run(new frmDTDLV());
            //Application.Run(new Main());
        }
    }
}
