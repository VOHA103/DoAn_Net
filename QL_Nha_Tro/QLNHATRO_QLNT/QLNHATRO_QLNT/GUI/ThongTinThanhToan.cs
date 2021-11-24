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
    public partial class ThongTinThanhToan : Form
    {
        XULYDULIEU xldl = new XULYDULIEU();
        public ThongTinThanhToan()
        {
            InitializeComponent();
        }

       

        private void btnTra_Click_1(object sender, EventArgs e)
        {
            if (txtMaPhong.Text == "")

            {

                MessageBox.Show("Vui Lòng Nhập Mã Phòng");

                txtMaPhong.Focus();

                return;

            }

            int a = xldl.CountSumMax("select count(*) from PHONG where TRANGTHAI is not null and MAPHONG='" + txtMaPhong.Text + "'");

            if (a > 0)

            {

                TraPhong tp = new TraPhong(txtMaPhong.Text);

                tp.MdiParent = this.MdiParent;

                tp.Show();

            }

            else

            {

                MessageBox.Show("Phòng này chưa được thuê");

                txtMaPhong.Text = "";

                return;

            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text == "")

            {

                MessageBox.Show("Vui Lòng Nhập Mã Phòng");

                txtMaPhong.Focus();

                return;

            }

            int a = xldl.CountSumMax("select count(*) from HOADON where maphong='" + txtMaPhong.Text + "' and THANG_THANHTOAN is null");

            if (a > 0)

            {

                ThanhToan tt = new ThanhToan(txtMaPhong.Text);

                tt.MdiParent = this.MdiParent;

                tt.Show();

            }

            else

            {

                MessageBox.Show("Hóa Đơn Đã Được Thanh Toán ");

                txtMaPhong.Text = "";

                return;

            }

        }

        private void ThongTinThanhToan_Load(object sender, EventArgs e)
        {

        }
    }
}
