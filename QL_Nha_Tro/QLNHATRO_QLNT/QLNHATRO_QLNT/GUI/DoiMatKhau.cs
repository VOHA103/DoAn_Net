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
    public partial class DoiMatKhau : Form
    {
        XULYDULIEU xldl = new XULYDULIEU();
        DataTable dttaikhoan;
        string pass;
        public DoiMatKhau()
        {
            InitializeComponent();
        }

      

        private void btnDoiMK_Click_2(object sender, EventArgs e)
        {
            try
            {

                if (txtMatKhau.Text == "" && txtNewPass.Text == "" && txtNewPass2.Text == "" && txtTaiKhoan.Text == "")
                {
                    MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin");
                    txtTaiKhoan.Text = txtNewPass2.Text = txtNewPass.Text = txtMatKhau.Text = "";
                    txtTaiKhoan.Focus();
                }
                else
                {
                    string sql = "select * from TAIKHOAN where TAIKHOAN='" + txtTaiKhoan.Text + "'";
                    dttaikhoan = xldl.readData(sql);
                    foreach (DataRow dong in dttaikhoan.Rows)
                    {
                        pass = dong[1].ToString();
                    }
                    if (pass.Trim().Equals(TienIch.md_5(txtMatKhau.Text)))
                    {
                        if (txtNewPass.Text.Equals(txtNewPass2.Text))
                        {
                            string sql2 = "update TAIKHOAN set MATKHAU='" + TienIch.md_5(txtMatKhau.Text) + "' where TAIKHOAN='" + txtTaiKhoan.Text + "'";
                            if (xldl.insertUpdateDelete(sql2) != -1)
                            {
                                MessageBox.Show("Đổi Mật Khẩu Thành Công");
                                new login().Show();
                                Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nhập sai mật khẩu mới");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Sai Mật Khẩu Cũ");
                    }
                }
                }
            catch(Exception ex)
            {
                MessageBox.Show("Loi");

            }
        }

        private void btnThoat_Click_2(object sender, EventArgs e)
        {
            new login().Show();
            Close();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
