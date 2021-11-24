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
    public partial class ChiTietHoaDon : Form
    {
        XULYDULIEU xldl = new XULYDULIEU();
        DataTable dtCTHD;
        DataTable dtComboboxKH;
        DataTable dtDichVu;
        public ChiTietHoaDon()
        {
            InitializeComponent();
            loadDataCTHD();
            listViewCTHD.Items.Clear();
            txtThanhTien.Enabled = false;
            loadDataDV();
        }
        void loadDataCTHD()
        {
            listViewCTHD.Items.Clear();
            dtCTHD = xldl.readData("select * from CTHD");
            addListViewCTHD();
        }
        void loadDataCTHDMa(string ma)
        {
            listViewCTHD.Items.Clear();
            dtCTHD = xldl.readData("select * from CTHD where MAHOADON='" + ma + "'");
            addListViewCTHD();
            
        }
        public void loadDataDV()
        {
            listViewDV.Items.Clear();
            dtDichVu = xldl.readData("select * from DICHVU");
            foreach (DataRow dong in dtDichVu.Rows)
            {
                ListViewItem lvi = listViewDV.Items.Add(dong[0].ToString());
                lvi.SubItems.Add(dong[1].ToString());
                lvi.SubItems.Add(dong[2].ToString());
                lvi.SubItems.Add(dong[3].ToString());
            }
        }
        void addListViewCTHD()
        {
            foreach (DataRow dong in dtCTHD.Rows)
            {
                ListViewItem lvi = listViewCTHD.Items.Add(dong[0].ToString());
                lvi.SubItems.Add(dong[1].ToString());
                lvi.SubItems.Add(dong[2].ToString());
                lvi.SubItems.Add(dong[3].ToString());
                lvi.SubItems.Add(dong[4].ToString());
                lvi.SubItems.Add(xldl.Chuoi("select distinct(TENKHACHHANG) from KHACHHANG,CTHD where KHACHHANG.MAKHACHHANG=CTHD.MAKHACHHANG and KHACHHANG.MAKHACHHANG='" + dong[2].ToString() + "'"));
                lvi.SubItems.Add(xldl.Chuoi("select distinct(TENDICHVU) from DICHVU,CTHD where DICHVU.MADICHVU=CTHD.MADICHVU and DICHVU.MADICHVU='" + dong[1].ToString() + "'"));
            }

        }
        void loadComboboxKH()
        {
            cbbKhachHang.Items.Clear();
            dtComboboxKH = xldl.readData("select distinct(KHACHHANG.MAKHACHHANG) from CTHD,KHACHHANG where CTHD.MAKHACHHANG=KHACHHANG.MAKHACHHANG and CTHD.MAHOADON="+ Int32.Parse(txtTimHD.Text) +"");
            foreach (DataRow dong in dtComboboxKH.Rows)
            {
                cbbKhachHang.Items.Add(dong[0].ToString());
            }
        }

       
        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
        }

       
        private void cbbMaHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtTimHD.Text = "";
            //if (txtTimHD.Text!="")
            //{
            //    listViewCTHD.Items.Clear();
            //    foreach (DataRow dong in dtCTHD.Rows)
            //    {
            //        if (dong[0].ToString().StartsWith(txtTimHD.Text))
            //        {
            //            ListViewItem lvi = listViewCTHD.Items.Add(dong[0].ToString());
            //            lvi.SubItems.Add(dong[1].ToString());
            //            lvi.SubItems.Add(dong[2].ToString());
            //            lvi.SubItems.Add(dong[3].ToString());
            //            lvi.SubItems.Add(dong[4].ToString());
            //            lvi.SubItems.Add(xldl.Chuoi("select distinct(TENKHACHHANG) from KHACHHANG,CTHD where KHACHHANG.MAKHACHHANG=CTHD.MAKHACHHANG and KHACHHANG.MAKHACHHANG='" + dong[2].ToString() + "'"));
            //            lvi.SubItems.Add(xldl.Chuoi("select distinct(TENDICHVU) from DICHVU,CTHD where DICHVU.MADICHVU=CTHD.MADICHVU and DICHVU.MADICHVU='" + dong[1].ToString() + "'"));
            //        }
            //    }
            //}
        }

       
        

      

       

        private void btnThemDichVu_Click_2(object sender, EventArgs e)
        {

            int thanhtien = (Int32.Parse(txtSoLuong.Text) * Int32.Parse(txtGiaTien.Text));
            string sql = "insert into CTHD values('" + Int32.Parse(txtTimHD.Text) + "', '" + txtMaDichVu.Text + "', '" + cbbKhachHang.SelectedItem.ToString() + "', " + Int32.Parse(txtSoLuong.Text) + ", " + thanhtien + ")";
            if (xldl.insertUpdateDelete(sql) != -1)
            {
                MessageBox.Show("Thêm Thành Công");
            }
            loadDataCTHDMa(txtTimHD.Text);
        }

        private void btnXoa_Click_2(object sender, EventArgs e)
        {
            string sql = "delete from CTHD where MADICHVU='" + txtMaDichVu.Text + "' and MAHOADON='" + txtTimHD.Text + "'";
            if (xldl.insertUpdateDelete(sql) != -1)
            {
                MessageBox.Show("Xóa Thành Công");
            }
            loadDataCTHDMa(txtTimHD.Text);
        }

        private void btnSua_Click_2(object sender, EventArgs e)
        {
            int thanhtien = (Int32.Parse(txtSoLuong.Text) * Int32.Parse(txtGiaTien.Text));
            string sql = "update CTHD set SOLUONG='" + Int32.Parse(txtSoLuong.Text) + "' , THANHTIEN='" + thanhtien + "' where MAHOADON='" + txtTimHD.Text + "' and MADICHVU='" + txtMaDichVu.Text + "'";
            if (xldl.insertUpdateDelete(sql) != -1)
            {
                MessageBox.Show("Sửa Thành Công");
            }
            loadDataCTHDMa(txtTimHD.Text);
        }

        private void listViewDV_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (listViewDV.SelectedItems.Count > 0)
            {
                txtMaDichVu.Text = listViewDV.SelectedItems[0].SubItems[0].Text;
                txtTenDV.Text = listViewDV.SelectedItems[0].SubItems[1].Text;
                txtGiaTien.Text = listViewDV.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void listViewCTHD_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (listViewCTHD.SelectedItems.Count > 0)
            {
                txtTimHD.Text = listViewCTHD.SelectedItems[0].SubItems[0].Text;
                txtMaDichVu.Text = listViewCTHD.SelectedItems[0].SubItems[1].Text;
                cbbKhachHang.Text = listViewCTHD.SelectedItems[0].SubItems[2].Text;
                txtSoLuong.Text = listViewCTHD.SelectedItems[0].SubItems[3].Text;
                txtThanhTien.Text = listViewCTHD.SelectedItems[0].SubItems[4].Text;
                txtTenKhach.Text = listViewCTHD.SelectedItems[0].SubItems[5].Text;
                txtTenDV.Text = listViewCTHD.SelectedItems[0].SubItems[6].Text;
                txtGiaTien.Text = (xldl.CountSumMax("select GIATIEN from DICHVU where MADICHVU='" + txtMaDichVu.Text + "'")) + "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTimHD_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (txtTimHD.Text == string.Empty)
            {
                //loadDataCTHD();
                MessageBox.Show("Bạn hãy nhập mã hóa đơn");
                listViewCTHD.Items.Clear();
            }
            else
            {
                string sql = "select COUNT(*) from HOADON where MAHOADON=" + Int32.Parse(txtTimHD.Text) + "";
                int kq = xldl.CountSumMax(sql);
                if (kq == 0)
                {
                    MessageBox.Show("Không có mã hóa đơn này");
                    txtTimHD.Text = "";
                    txtTimHD.Focus();
                }
                else
                {
                    listViewCTHD.Items.Clear();
                    foreach (DataRow dong in dtCTHD.Rows)
                    {
                        if (dong[0].ToString().StartsWith(txtTimHD.Text))
                        {
                            ListViewItem lvi = listViewCTHD.Items.Add(dong[0].ToString());
                            lvi.SubItems.Add(dong[1].ToString());
                            lvi.SubItems.Add(dong[2].ToString());
                            lvi.SubItems.Add(dong[3].ToString());
                            lvi.SubItems.Add(dong[4].ToString());
                            lvi.SubItems.Add(xldl.Chuoi("select distinct(TENKHACHHANG) from KHACHHANG,CTHD where KHACHHANG.MAKHACHHANG=CTHD.MAKHACHHANG and KHACHHANG.MAKHACHHANG='" + dong[2].ToString() + "'"));
                            lvi.SubItems.Add(xldl.Chuoi("select distinct(TENDICHVU) from DICHVU,CTHD where DICHVU.MADICHVU=CTHD.MADICHVU and DICHVU.MADICHVU='" + dong[1].ToString() + "'"));
                            txtTenKhach.Text = xldl.Chuoi("select distinct(TENKHACHHANG) from KHACHHANG,CTHD where KHACHHANG.MAKHACHHANG=CTHD.MAKHACHHANG and KHACHHANG.MAKHACHHANG='" + dong[2].ToString() + "'");
                        }
                    }
                    loadComboboxKH();
                    loadDataCTHDMa(txtTimHD.Text);
                    cbbKhachHang.SelectedIndex = 0;
                }
            }
        }

        private void txtTimHD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
