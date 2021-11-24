using QLNHATRO_QLNT.GUI;
using QLNHATRO_QLNT.M_ODEL;
using System;
using System.Windows.Forms;
using QLNHATRO_QLNT.DAO;
using System.Data;

namespace QLNHATRO_QLNT
{
    public partial class login : Form
    {
        XULYDULIEU xldl = new XULYDULIEU();
        TAIKHOAN tk = new TAIKHOAN();
         DataTable dttaikhoan;
        public login()
        {
            InitializeComponent();
        }

    

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            if (txt_pass.Text != "" || txt_taikhoan.Text != "")
            {
                string sql = "select * from TAIKHOAN where TAIKHOAN='" + txt_taikhoan.Text + "'";
                dttaikhoan = xldl.readData(sql);
                foreach (DataRow dong in dttaikhoan.Rows)
                {
                    tk.TaiKhoan = dong[0].ToString();
                    tk.MatKhau = dong[1].ToString();
                    tk.PhanQuyen = Int32.Parse(dong[2].ToString());
                }
                if (tk.MatKhau.Trim().Equals(TienIch.md_5(txt_pass.Text) ))
                {
                    MDIParent1.xuat(tk);
                    Close();
                }
                else
                {
                    MessageBox.Show("Sai Mật Khẩu");
                }
            }
            else
            {
                MessageBox.Show("Chưa Nhập Tài Khoản Hoặc Mật Khẩu");
            }

        }
        void loaddata()
        {

            string sql = "select * from TAIKHOAN where TAIKHOAN='" + txt_taikhoan.Text + "'";
            dttaikhoan = xldl.readData(sql);
            foreach (DataRow dong in dttaikhoan.Rows)
            {
                tk.TaiKhoan = dong[0].ToString();
                tk.MatKhau = dong[1].ToString();
                tk.PhanQuyen = Int32.Parse(dong[2].ToString());
            }
        }
       
        private void btnDoiMK_Click_1(object sender, EventArgs e)
        {
            Close();
            new DoiMatKhau().Show();
        }

        private void btnDangKy_Click_1(object sender, EventArgs e)
        {
            Close();
            new DangKy().Show();
        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
