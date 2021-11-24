using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNHATRO_QLNT.BC
{
    public partial class fr_BCHDON : Form
    {
        public fr_BCHDON()
        {
        }

        public fr_BCHDON(string formname,DataTable dulieu)
        {
            InitializeComponent();
            if (formname == "BCHDON")
            {
                BCHDON_Report baocao = new BCHDON_Report();
                baocao.SetDataSource(dulieu);
               // baocao.SetParameterValue("NguoiLapBaoCao","Vo Thi Thu Ha");
                crystalReportViewer1.ReportSource = baocao;

            }
            else
                if (formname == "demo_CTHD")
            {
                CTHD_Report baocao = new CTHD_Report();
                baocao.SetDataSource(dulieu);
               // baocao.SetParameterValue("NguoiLapBaoCao", "Vo Thi Thu Ha");
                crystalReportViewer1.ReportSource = baocao;
            }
       }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
