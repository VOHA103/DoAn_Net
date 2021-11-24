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
    public partial class QuanLyUser : Form
    {
        XULYDULIEU xldl = new XULYDULIEU();
        DataTable dttaikhoan;
        public QuanLyUser()
        {
            InitializeComponent();
            radUser.Checked = true;
        }
        void loadListView()
        {
            dttaikhoan = xldl.readData("select * from TAIKHOAN");
            listView1.Items.Clear();
            foreach (DataRow rows in dttaikhoan.Rows)
            {
                ListViewItem lvi = listView1.Items.Add(rows[0].ToString());
                lvi.SubItems.Add(rows[1].ToString());
                lvi.SubItems.Add(rows[2].ToString());
            }
        }
     
       

        void reset()
        {
            txt_taikhoan.Text = "";
            txt_matkhau.Text = "";
            txt_taikhoan.Focus();
        }
        private void QuanLyUser_Load(object sender, EventArgs e)
        {
            loadListView();

        }
        bool kt_TaiKhoan()
        {
            foreach (ListViewItem ls in listView1.Items)
            {
                if (txt_taikhoan.Text.Equals(ls.SubItems[1].Text))
                {
                    MessageBox.Show("Trung tai khoan", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txt_taikhoan.Text = "";
                    txt_taikhoan.Focus();
                    return true;
                }
            }
            return false;
        }
      

        private void btn_them_Click_1(object sender, EventArgs e)
        {
            try
            {



                string sqlKT = "select COUNT(*) from TAIKHOAN where TAIKHOAN= '" + txt_taikhoan.Text + "'";
                if (xldl.CountSumMax(sqlKT) == 0)
                {
                    string sql = "";
                    if (radAdmin.Checked)
                        sql += "insert into TAIKHOAN values('" + txt_taikhoan.Text + "','" + TienIch.md_5(txt_matkhau.Text) + "',1)";
                    if (radUser.Checked)
                        sql += "insert into TAIKHOAN values('" + txt_taikhoan.Text + "','" + TienIch.md_5(txt_matkhau.Text) + "', 0)";
                    if (xldl.insertUpdateDelete(sql) != -1)
                    {
                        MessageBox.Show("Đăng Ký Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        new login().Show();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Tài Khoản Đã Tồn Tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txt_taikhoan.Text = "";
                    txt_matkhau.Text = "";
                    radUser.Checked = true;
                    txt_taikhoan.Focus();
                }
            }
            catch
            {
              MessageBox.Show("Loi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txt_taikhoan.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txt_matkhau.Text = listView1.SelectedItems[0].SubItems[1].Text;
                string pq = listView1.SelectedItems[0].SubItems[2].Text;
                if (pq == "1")
                    radAdmin.Checked = true;
                else
                    radUser.Checked = true;
            }
        }

        private void btn_thoat_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co muon thoat chuong trinh khong", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btn_sua_Click_1(object sender, EventArgs e)
        {
            int pq = 0;
            if (radAdmin.Checked)
            {
                pq = 1;
            }
            try
            {
                string sql = string.Format("update TAIKHOAN set MATKHAU='{0}', PHANQUYEN={1} where TAIKHOAN='{2}'", TienIch.md_5(txt_matkhau.Text),pq, txt_taikhoan.Text);
                if (listView1.SelectedItems.Count == 1)
                {
                    if (xldl.insertUpdateDelete(sql) != -1)
                    {
                        loadListView();
                        MessageBox.Show("Sua thanh cong", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("Hay chon dong can sua", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("delete TAIKHOAN where TAIKHOAN='{0}'", txt_taikhoan.Text);
                if (listView1.SelectedItems.Count == 1)
                {
                    if (xldl.insertUpdateDelete(sql) != -1)
                    {
                        loadListView();
                        MessageBox.Show("Xoa thanh cong", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        reset();
                    }
                }
                else
                {
                    MessageBox.Show("Hay chon dong can xoa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
