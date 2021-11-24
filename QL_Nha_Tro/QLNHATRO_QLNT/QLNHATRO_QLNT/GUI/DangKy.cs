using QLNHATRO_QLNT.M_ODEL;
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
    public partial class DangKy : Form
    {
        XULYDULIEU xldl = new XULYDULIEU();
        public DangKy()
        {
            InitializeComponent();
        }

        
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                if (TienIch.ktRong(txtTaiKhoan) || TienIch.ktRong(txtMatKhau))
                {
                    return;
                }

                string sql = "insert into TAIKHOAN values('" + txtTaiKhoan.Text + "','" + TienIch.md_5(txtMatKhau.Text) + "', 0)";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    MessageBox.Show("Đăng Ký Thành Công");
                    new login().Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tài Khoản Đã Tồn Tại");
                txtTaiKhoan.Text = "";
                txtMatKhau.Text = "";
                txtTaiKhoan.Focus();
            }

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            new login().Show();
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DangKy_Load(object sender, EventArgs e)
        {

        }
    }
}
