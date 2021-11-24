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
    public partial class TraPhong : Form
    {
        string maPhong;
        DataTable dtKH, dtHD;
        XULYDULIEU xldl = new XULYDULIEU();
        public TraPhong(string ma)
        {
            InitializeComponent();
            maPhong = ma;
            loadDataKH();
            loadDataHD();
            txtTenPhong.Text = xldl.Chuoi("select TENPHONG from PHONG where MAPHONG='"+maPhong+"'");
        }

        private void TraPhong_Load(object sender, EventArgs e)
        {

        }
        void loadDataKH() {
            string sql = "select KHACHHANG.* from HOADON,CTHD,KHACHHANG where KHACHHANG.MAKHACHHANG=CTHD.MAKHACHHANG and CTHD.MAHOADON=HOADON.MAHOADON and MAPHONG='" + maPhong + "'";
            dtKH = xldl.readData(sql);
            foreach (DataRow dong in dtKH.Rows)
            {
                txtTenKhach.Text = dong[1].ToString();
                txtDiaChi.Text = dong[2].ToString();
                txtCMND.Text = dong[3].ToString();
                txtSDT.Text = dong[4].ToString();
            }
        }
        void loadDataHD() {
            string sql = "select * from HOPDONG where MAPHONG='"+maPhong+"'";
            dtHD = xldl.readData(sql);
            foreach (DataRow dong in dtHD.Rows)
            {
                txtSoHopDong.Text = dong[0].ToString();
                txtTienCoc.Text = dong[2].ToString();
            }
        }

        private void txtTenPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtSoHopDong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTienCoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgayTraPhong_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTra_Click_1(object sender, EventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}", dtpNgayTraPhong.Value);
            string sqlP = "update PHONG set TRANGTHAI = null where MAPHONG='" + maPhong + "'";
            string sqlHD = "update HOPDONG set NGAYTRA = '" + ngay + "' where SOHOPDONG = '" + txtSoHopDong.Text + "'";
            if (xldl.insertUpdateDelete(sqlP) != -1 && xldl.insertUpdateDelete(sqlHD) != -1)
            {
                MessageBox.Show("Trả Phòng Thành Công");
            }
        }

       
    }
}
