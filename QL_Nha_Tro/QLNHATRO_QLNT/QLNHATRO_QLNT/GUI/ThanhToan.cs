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
    public partial class ThanhToan : Form
    {
        XULYDULIEU xldl = new XULYDULIEU();
        DataTable dtCTHD;
        DataTable dtHD;
        DataTable dtP;
        public ThanhToan(string ma)
        {
            InitializeComponent();
            txtMaPhong.Text = ma;
            loadDataCTHD();
        }
        void loadDataCTHD()
        {
            try
            {
                dtHD = xldl.readData("select * from HOADON where maphong='" + txtMaPhong.Text + "' and THANG_THANHTOAN is null");
                foreach (DataRow dong in dtHD.Rows)
                {
                    int mahd = Int32.Parse(dong[0].ToString());
                    listViewCTHD.Items.Clear();
                    dtCTHD = xldl.readData("select * from CTHD where MAHOADON='" + mahd + "'");
                    int tongtienDV = 0;
                    MessageBox.Show(mahd + "");
                    foreach (DataRow dong1 in dtCTHD.Rows)
                    {
                        ListViewItem lvi1 = listViewCTHD.Items.Add(dong1[0].ToString());
                        lvi1.SubItems.Add(dong1[1].ToString());
                        lvi1.SubItems.Add(dong1[2].ToString());
                        lvi1.SubItems.Add(xldl.Chuoi("select distinct(TENKHACHHANG) from KHACHHANG,CTHD where KHACHHANG.MAKHACHHANG=CTHD.MAKHACHHANG and KHACHHANG.MAKHACHHANG='" + dong1[2].ToString() + "'"));
                        lvi1.SubItems.Add(xldl.Chuoi("select distinct(TENDICHVU) from DICHVU,CTHD where DICHVU.MADICHVU=CTHD.MADICHVU and DICHVU.MADICHVU='" + dong1[1].ToString() + "'"));
                        lvi1.SubItems.Add(dong1[3].ToString());
                        lvi1.SubItems.Add(dong1[4].ToString());
                        tongtienDV += Int32.Parse(dong1[4].ToString());
                    }
                    txtTongTienDV.Text = tongtienDV + "";
                }
                dtP = xldl.readData("select TENPHONG,GIAPHONG from PHONG,LOAIPHONG where PHONG.MALOAI=LOAIPHONG.MALOAI and MAPHONG='" + txtMaPhong.Text + "'");
                foreach (DataRow dong in dtP.Rows)
                {
                    txtTenPhong.Text = dong[0].ToString();
                    txtGiaPhong.Text = dong[1].ToString();
                }
                int tongtien = Int32.Parse(txtTongTienDV.Text) + Int32.Parse(txtGiaPhong.Text);
                txtTongTien.Text = tongtien + "";
            }
            catch (Exception)
            {
                MessageBox.Show("Hóa Đơn Đã Được Thanh Toán ");
            }
           

        }
        void loadTinhTien() {
            //int tongtien = Int32.Parse(txtTongTienDV.Text) + Int32.Parse(txtGiaPhong.Text);
            //txtTongTien.Text = (Int32.Parse(txtTongTienDV.Text) + Int32.Parse(txtGiaPhong.Text)) + "";
        }
        private void ThanhToan_Load(object sender, EventArgs e)
        {
            //int tongtien = Int32.Parse(txtTongTienDV.Text) + Int32.Parse(txtGiaPhong.Text);
            //txtTongTien.Text = tongtien + "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}", dtpNgayThanhToan.Value);
            string sqlupdateHD = "update HOADON set THANG_THANHTOAN = '" + ngay + "' where MAPHONG = '" + txtMaPhong.Text + "'";
            string sqlinsertHD = "insert into HOADON values('" + txtMaPhong.Text + "', null, null)";
            if (xldl.insertUpdateDelete(sqlupdateHD) != -1)
            {
                if (xldl.insertUpdateDelete(sqlinsertHD) != -1)
                {
                    MessageBox.Show("Thanh Toán Thành Công");
                    //new fr_BCHDON("CTHD", ds.Tables[0]).Show();
                }
            }

            //new fr_BCHDON("CTHD", dttam).Show();
            //new demo_CTHD().Show();
        }

     
    }
}
