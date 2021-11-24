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
    public partial class ThuePhong : Form
    {
        XULYDULIEU xldl = new XULYDULIEU();
        DataTable dtComboboxLoai;
        DataTable dtPhong;
        string maphong;
        public ThuePhong()
        {
            InitializeComponent();
            loadCombobox();
            loadDataPhong();
            //btnTao.Enabled = false;
            gbHopDong.Visible = gbKhachHang.Visible = btnLuu.Visible = false;
        }
        void loadCombobox() {
            cbbTenLoaiPhong.Items.Clear();
            dtComboboxLoai = xldl.readData("select * from LOAIPHONG");
            foreach (DataRow dong in dtComboboxLoai.Rows)
            {
                cbbTenLoaiPhong.Items.Add(dong[1].ToString());
            }
        }
        void loadDataPhong() {
            listView1.Items.Clear();
            dtPhong = xldl.readData("select * from PHONG");
            foreach (DataRow dong in dtPhong.Rows)
            {
                ListViewItem lvi = listView1.Items.Add(dong[0].ToString());
                lvi.SubItems.Add(dong[1].ToString());
                lvi.SubItems.Add(dong[2].ToString());
                lvi.SubItems.Add(dong[3].ToString());
            }
        }
        
        void loadData() {
            listView1.Items.Clear();
            string sql="";
            string maloai = "";
            if (cbbTenLoaiPhong.Text != "")
            {
                maloai = xldl.Chuoi("select MALOAI from LOAIPHONG where TENLOAI=N'" + cbbTenLoaiPhong.SelectedItem.ToString() + "'");
              
            }
            else
            {
               MessageBox.Show("Vui Lòng Chọn Loại Phòng Khách Hàng Muốn Thuê");
                loadDataPhong();
            }
            if (radConTrong.Checked)
                sql="select * from PHONG where MALOAI='" + maloai + "' and TRANGTHAI is null";
            if (radDaThue.Checked)
                sql="select * from PHONG where MALOAI='" + maloai + "' and TRANGTHAI is not null";
            if (!radDaThue.Checked && !radConTrong.Checked) 
               sql = "select * from PHONG where MALOAI='" + maloai + "'";
            dtPhong = xldl.readData(sql);
            foreach (DataRow dong in dtPhong.Rows)
            {
                ListViewItem lvi = listView1.Items.Add(dong[0].ToString());
                lvi.SubItems.Add(dong[1].ToString());
                lvi.SubItems.Add(dong[2].ToString());
                lvi.SubItems.Add(dong[3].ToString());
            }
        }
   
        
        string maKH()
        {
            string sqlSKH = "select COUNT(*) from KHACHHANG";
            string maKhachHang = "KH" + (xldl.CountSumMax(sqlSKH) + 1);
            return maKhachHang;
        }
        string maHD()
        {
            string sqlSHD = "select COUNT(*) from HOPDONG";
            string maHopDong = "HD" + (xldl.CountSumMax(sqlSHD) + 1);
            return maHopDong;
        }

     

       
        private void btnTao_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 0)
            {
                MessageBox.Show("Vui lòng chọn mà khách hàng muốn thuê ");
            }
            btnTao.Enabled = false;
            gbHopDong.Visible = gbKhachHang.Visible = btnLuu.Visible = true;

        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            cbbTenLoaiPhong.ResetText();
            radConTrong.Checked = radDaThue.Checked = false;
            loadDataPhong();
            btnTao.Enabled = true;
            gbHopDong.Visible = gbKhachHang.Visible = btnLuu.Visible = false;

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                maphong = listView1.SelectedItems[0].SubItems[0].Text;
                //btnTao.Enabled = true;
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                string ngay = String.Format("{0:MM/dd/yyyy}", dtpNgayThue.Value);
                string sqlKH = "insert into KHACHHANG values ('" + maKH() + "', N'" + txtTenKhach.Text + "',N'" + txtDiaChi.Text + "','" + txtCMND.Text + "','" + txtDienThoai.Text + "')";
                string sqlHD = "insert into HOPDONG values('" + maHD() + "', '" + maphong + "', " + Int32.Parse(txtTienCoc.Text) + ", '" + ngay + "', null)";
                string sqlupdate = "update PHONG set TRANGTHAI=N'Đã Thuê' where MAPHONG='" + maphong + "'";
                string sqlHoaDon = "insert into HOADON values ('" + maphong + "',null,null)";
                if (xldl.insertUpdateDelete(sqlHD) != -1 && xldl.insertUpdateDelete(sqlupdate) != -1 && xldl.insertUpdateDelete(sqlHoaDon) != -1)
                {
                    if (txtTenKhach.Text != "")
                    {
                        if (xldl.insertUpdateDelete(sqlKH) != -1)
                        {
                            MessageBox.Show("Thêm Khách Hàng Thành Công");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hóa Đơn Đã Được Thêm Thành Công");
                    }
                }
            }
            catch (Exception ex)
            {

            }
           // gbHopDong.Visible = gbKhachHang.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
