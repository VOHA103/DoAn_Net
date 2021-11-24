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
using QLNHATRO_QLNT.M_ODEL;

namespace QLNHATRO_QLNT.GUI
{
    public partial class BCHDON : Form
    {
        XULYDULIEU db = new XULYDULIEU();
        DataTable dtHD, dtPhong, dtHD_tam;

        private void button2_Click(object sender, EventArgs e)
        {
            dtHD_tam.Rows.Clear();
            foreach (DataRow r in dtHD.Rows)
            {

                if (r[1].ToString().Equals(cb_phong.Text))
                {

                    DataRow newrow = dtHD_tam.NewRow();
                    newrow[0] = r[0];
                    newrow[1] = r[1];
                    newrow[2] = r[2];
                    newrow[3] = r[3];
                    dtHD_tam.Rows.Add(newrow);

                }
            }
            dataGridView1.DataSource = dtHD_tam;
        }

       

        public BCHDON()
        {
            InitializeComponent();
        }

        private void btn_pRint_Click(object sender, EventArgs e)
        {
            new fr_BCHDON("BCHDON", dtHD_tam).Show();

        }

        private void btn_in_Click(object sender, EventArgs e)
        {

        }

        private void BCHDON_Load(object sender, EventArgs e)
        {
            load();
       }

        void load()
        {
            dtPhong = db.readData("select * from PHONG");
            cb_phong.DataSource = dtPhong;
            cb_phong.DisplayMember = "TENPHONG";
            cb_phong.ValueMember = "MAPHONG";

            dtHD = db.readData("select*from View_HD_PHONG");
            dataGridView1.DataSource = dtHD;
            dtHD_tam = dtHD.Copy();



        }
    }
}
