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
    public partial class LoaiPhong : Form
    {
        XULYDULIEU xldl = new XULYDULIEU();
        DataTable dtLoaiPhong;
        public LoaiPhong()
        {
            InitializeComponent();
            loadData();
            maLP();
        }
        void maLP()
        {
            txtMaLoai.Enabled = false;
            string sqlSLP = "select COUNT(*) from LOAIPHONG";
            string malp = "L" + (xldl.CountSumMax(sqlSLP) + 1);
            txtMaLoai.Text = malp;
        }
     

        private void LoaiPhong_Load(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txtMaLoai.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txtTenLoai.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txtGiaPhong.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txtGhiChu.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
            loadData();
        }
        public void LoaiPhongreset()
        {
            txtGhiChu.Text = "";
            txtGiaPhong.Text = "";
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
        }
        public void loadData()
        {
            dtLoaiPhong = xldl.readData("select * from LOAIPHONG");
            listView1.Items.Clear();
            foreach (DataRow dong in dtLoaiPhong.Rows)
            {
                ListViewItem lvi = listView1.Items.Add(dong[0].ToString());
                lvi.SubItems.Add(dong[1].ToString());
                lvi.SubItems.Add(dong[2].ToString());
                lvi.SubItems.Add(dong[3].ToString());
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            LoaiPhongreset();
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = true;

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txtMaLoai.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txtTenLoai.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txtGiaPhong.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txtGhiChu.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
            loadData();
        }

       

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (TienIch.ktRong(txtMaLoai) || TienIch.ktRong(txtTenLoai) || TienIch.ktRong(txtGiaPhong))
                {
                    return;
                }
                listView1.Items.Clear();
                string sql2 = string.Format("update LOAIPHONG set TENLOAI = N'" + txtTenLoai.Text + "',GIAPHONG = '" + float.Parse(txtGiaPhong.Text) + "',GHICHU = N'" + txtGhiChu.Text + "' where MALOAI = '" + txtMaLoai.Text + "'");
                if (xldl.insertUpdateDelete(sql2) != -1)
                    loadData();
                MessageBox.Show("Sửa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi khi sửa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                string sql = "delete from LOAIPHONG where MALOAI='" + txtMaLoai.Text + "'";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadData();
                    MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi khi xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (TienIch.ktRong(txtMaLoai) || TienIch.ktRong(txtTenLoai)|| TienIch.ktRong(txtGiaPhong))
                {
                    return;
                }
                maLP();
                listView1.Items.Clear();
                string sql = "insert into LOAIPHONG values('" + txtMaLoai.Text + "', N'" + txtTenLoai.Text + "', " + float.Parse(txtGiaPhong.Text) + ", N'" + txtGhiChu.Text + "')";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadData();
                    MessageBox.Show("Thêm Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
    }

