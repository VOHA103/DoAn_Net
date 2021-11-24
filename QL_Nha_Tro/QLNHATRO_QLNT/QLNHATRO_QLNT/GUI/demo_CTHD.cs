using QLNHATRO_QLNT.BC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNHATRO_QLNT.GUI
{
    public partial class demo_CTHD : Form
    {

        XULYDULIEU db = new XULYDULIEU();
        DataTable dt_cthd,dtHD_tam;

        private void btn_in_Click(object sender, EventArgs e)
        {
            new fr_BCHDON("demo_CTHD", dtHD_tam).Show();

        }

        public demo_CTHD()
        {
            InitializeComponent();
        }
        void load()
        {


            dt_cthd = db.readData("select*from View_CTHD_TT");
            dataGridView1.DataSource = dt_cthd;
            dtHD_tam = dt_cthd.Copy();



        }
        private void demo_CTHD_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
