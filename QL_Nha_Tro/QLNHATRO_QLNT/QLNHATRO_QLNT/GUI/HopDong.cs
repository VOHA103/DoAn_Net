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
    public partial class HopDong : Form
    {
        DataTable dtHOPDONG;
        DataTable Ph;
        XULYDULIEU xldl = new XULYDULIEU();
        public HopDong()
        {
            InitializeComponent();
            loaddata();
        }
        string maHopDong()
        {
            string sqlSLP = "select COUNT(*) from HOPDONG";
            string maHD = "HD" + (xldl.CountSumMax(sqlSLP) + 1);
            return maHD;
        }
        void loadComboboxMaPhong()
        {
            comboBox1.Items.Clear();
            Ph = xldl.readData("select * from PHONG");
            foreach (DataRow dong in Ph.Rows)
            {
                comboBox1.Items.Add(dong[0].ToString());
            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {


                string ngaythue = String.Format("{0:MM/dd/yyyy}", dtpNgayThue.Value);
                lsHopDong.Items.Clear();
                string sql = "insert into HOPDONG values ('" + maHopDong() + "','" + comboBox1.Text + "', '" +txtTongTien.Text + "','" + ngaythue + "', null)";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loaddata();
                    MessageBox.Show("Thêm Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            {
                MessageBox.Show("Loi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void loaddata(){
            dtHOPDONG = xldl.readData("select * from HOPDONG");
            lsHopDong.Items.Clear();

            foreach (DataRow dong in dtHOPDONG.Rows)
            {
                ListViewItem lvi = lsHopDong.Items.Add(dong[0].ToString());
                lvi.SubItems.Add(dong[1].ToString());
                lvi.SubItems.Add(dong[2].ToString());
                lvi.SubItems.Add(dong[3].ToString());
                lvi.SubItems.Add(dong[4].ToString());
            }
        }

        private void lsHopDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsHopDong.SelectedItems.Count > 0)
            {
                txtMaHopDong.Text = lsHopDong.SelectedItems[0].SubItems[0].Text;
                comboBox1.Text = lsHopDong.SelectedItems[0].SubItems[1].Text;
                txtTenPhong.Text = xldl.Chuoi("select TENPHONG from PHONG where MAPHONG='" + comboBox1.Text + "'");
                txtTongTien.Text = lsHopDong.SelectedItems[0].SubItems[2].Text;
                dtpNgayThue.Text = lsHopDong.SelectedItems[0].SubItems[3].Text;
                
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {


                string ngaythue = String.Format("{0:MM/dd/yyyy}", dtpNgayThue.Value);
                lsHopDong.Items.Clear();
                string sql = "delete from HOPDONG where SOHOPDONG='" + txtMaHopDong.Text + "'";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loaddata();
                    MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            {
                MessageBox.Show("Loi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {


                string ngaythue = String.Format("{0:MM/dd/yyyy}", dtpNgayThue.Value);
                lsHopDong.Items.Clear();
                string sql = "update HOPDONG set MAPHONG='" + comboBox1.Text + "',TIENCOC='" + Int32.Parse(txtTongTien.Text) + "',NGAYTHUE='" + ngaythue + "' where SOHOPDONG='" + txtMaHopDong.Text + "'";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loaddata();
                    MessageBox.Show("Sửa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            {
                MessageBox.Show("Loi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HopDong_Load(object sender, EventArgs e)
        {
            loadComboboxMaPhong();
            //comboBox1.SelectedIndex = 0;
        }
    }
}
