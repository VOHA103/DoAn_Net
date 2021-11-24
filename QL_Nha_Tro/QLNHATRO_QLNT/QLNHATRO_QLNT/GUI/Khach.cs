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
    public partial class Khach : Form
    {
        XULYDULIEU xldl = new XULYDULIEU();
        DataTable dtKhachHang;
        public Khach()
        {
            InitializeComponent();
            loadData();
            txt_makh.Enabled = false;
            maKH();
        }
        public void loadData() {
            listView1.Items.Clear();
            dtKhachHang = xldl.readData("select * from KHACHHANG");
            foreach (DataRow dong in dtKhachHang.Rows)
            {
                ListViewItem lvi = listView1.Items.Add(dong[0].ToString());
                lvi.SubItems.Add(dong[1].ToString());
                lvi.SubItems.Add(dong[2].ToString());
                lvi.SubItems.Add(dong[3].ToString());
                lvi.SubItems.Add(dong[4].ToString());
            }
        }

     
        void maKH()
        {
            txt_makh.Enabled = false;
            string sqlSKH = "select COUNT(*) from KHACHHANG";
            string maKhachHang = "KH" + (xldl.CountSumMax(sqlSKH) + 1);
            txt_makh.Text = maKhachHang;
        }
        private void Khach_Load(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txt_makh.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txt_tenkh.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txt_diachi.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txt_cmnd.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txt_sdt.Text = listView1.SelectedItems[0].SubItems[4].Text;
            }
            loadData();
        }




        void reset()
        {
            txt_sdt.Text = "";
            txt_tenkh.Text = "";
            txt_makh.Text = "";
            txt_diachi.Text = "";
            txt_cmnd.Text = "";
            maKH();
        }

        private void txtTim_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtTim.Text == string.Empty)
                    loadData();
                else
                {
                    listView1.Items.Clear();
                    foreach (DataRow dong in dtKhachHang.Rows)
                    {
                        if (dong[1].ToString().Contains(txtTim.Text) || dong[2].ToString().Contains(txtTim.Text))
                        {
                            ListViewItem lvi = listView1.Items.Add(dong[0].ToString());
                            lvi.SubItems.Add(dong[1].ToString());
                            lvi.SubItems.Add(dong[2].ToString());
                            lvi.SubItems.Add(dong[3].ToString());
                            lvi.SubItems.Add(dong[4].ToString());
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Loi");

            }
        }
   




    
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void btn_them_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (btnReset.Enabled == false)
                {
                    listView1.Items.Clear();
                    string sql = "insert into KHACHHANG values ('" + txt_makh.Text + "', N'" + txt_tenkh.Text + "',N'" + txt_diachi.Text + "','" + txt_cmnd.Text + "','" + txt_sdt.Text + "')";
                    if (xldl.insertUpdateDelete(sql) != -1)
                    {
                        loadData();
                        MessageBox.Show("Thêm Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    reset();
                }
                else
                {
                    MessageBox.Show("Vui Lòng Bấm Reset", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                string sql = "delete from KHACHHANG where MAKHACHHANG='" + txt_makh.Text + "'";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadData();
                    MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                reset();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                string sql = "update KHACHHANG set TENKHACHHANG='" + txt_tenkh.Text + "', DIACHI='" + txt_diachi.Text + "', CMND='" + txt_cmnd.Text + "', SDT='" + txt_sdt.Text + "' where MAKHACHHANG='" + txt_makh.Text + "'";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadData();
                    MessageBox.Show("Sửa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                reset();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                btnReset.Enabled = true;
                txt_makh.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txt_tenkh.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txt_diachi.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txt_cmnd.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txt_sdt.Text = listView1.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            reset();
        }
    }
}
