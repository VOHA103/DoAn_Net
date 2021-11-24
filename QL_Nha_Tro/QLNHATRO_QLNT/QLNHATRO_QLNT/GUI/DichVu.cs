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
    public partial class DichVu : Form
    {

        XULYDULIEU xldl = new XULYDULIEU();
        DataTable dtDichVu;
        public DichVu()
        {
            InitializeComponent();
            loadDataDV();
            maDV();
        }
        void maDV() {
            txtMaDichVu.Enabled = false;
            string sqlSDV = "select COUNT(*) from DICHVU";
            string madv = "DV" + (xldl.CountSumMax(sqlSDV) + 1);
            txtMaDichVu.Text = madv;
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
        
        private void DichVu_Load(object sender, EventArgs e)
        {
            if (listViewDV.SelectedItems.Count > 0)
            {
                txtMaDichVu.Text = listViewDV.SelectedItems[0].SubItems[0].Text;
                txtTenDichVu.Text = listViewDV.SelectedItems[0].SubItems[1].Text;
                txtGiaTien.Text = listViewDV.SelectedItems[0].SubItems[2].Text;
                txtGhiChu.Text = listViewDV.SelectedItems[0].SubItems[3].Text;
            }
            loadDataDV();
        }
        public void DVResetText()
        {
            txtGhiChu.Text = "";
            txtGiaTien.Text = "";
            txtMaDichVu.Text = "";
            txtTenDichVu.Text = "";
            txtMaDichVu.Focus();
        }
        private void btn_sua_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (TienIch.ktRong(txtMaDichVu) || TienIch.ktRong(txtTenDichVu) || TienIch.ktRong(txtGiaTien))
                {
                    return;
                }
                listViewDV.Items.Clear();
                string sql2 = string.Format("update DICHVU set TENDICHVU = N'" + txtTenDichVu.Text + "',GIATIEN = '" + float.Parse(txtGiaTien.Text) + "',GHICHU = N'" + txtGhiChu.Text + "' where MADICHVU = '" + txtMaDichVu.Text + "'");
                if (xldl.insertUpdateDelete(sql2) != -1)
                    loadDataDV();
                MessageBox.Show("Sửa Thành Công");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi khi sửa");

            }


        }

        private void listViewDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDV.SelectedItems.Count > 0)
            {
                txtMaDichVu.Text = listViewDV.SelectedItems[0].SubItems[0].Text;
                txtTenDichVu.Text = listViewDV.SelectedItems[0].SubItems[1].Text;
                txtGiaTien.Text = listViewDV.SelectedItems[0].SubItems[2].Text;
                txtGhiChu.Text = listViewDV.SelectedItems[0].SubItems[3].Text;
            }
            loadDataDV();
        }

        private void btn_them_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(TienIch.ktRong(txtMaDichVu)|| TienIch.ktRong(txtTenDichVu)|| TienIch.ktRong(txtGiaTien))
                {
                    return;
                }
                maDV();
                listViewDV.Items.Clear();
                string sql = "insert into DICHVU values('" + txtMaDichVu.Text + "', N'" + txtTenDichVu.Text + "', " + Int32.Parse(txtGiaTien.Text) + ", N'" + txtGhiChu.Text + "')";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadDataDV();
                    MessageBox.Show("Thêm Thành Công");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi khi thêm");
            }
        }

    

        private void btn_xoa_Click_1(object sender, EventArgs e)
        {

            try
            {
                listViewDV.Items.Clear();
                string sql = "delete from DICHVU where MADICHVU='" + txtMaDichVu.Text + "'";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadDataDV();
                    MessageBox.Show("Xóa Thành Công");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi khi xóa");

            }
        }

        private void btn_reset_Click_1(object sender, EventArgs e)
        {
            DVResetText();
            btn_sua.Enabled = btn_them.Enabled = btn_xoa.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (TienIch.ktRong(txtMaDichVu) || TienIch.ktRong(txtTenDichVu) || TienIch.ktRong(txtGiaTien))
                {
                    return;
                }
                maDV();
                listViewDV.Items.Clear();
                string sql = "insert into DICHVU values('" + txtMaDichVu.Text + "', N'" + txtTenDichVu.Text + "', " + Int32.Parse(txtGiaTien.Text) + ", N'" + txtGhiChu.Text + "')";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadDataDV();
                    MessageBox.Show("Thêm Thành Công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {

                if (TienIch.ktRong(txtMaDichVu) || TienIch.ktRong(txtTenDichVu) || TienIch.ktRong(txtGiaTien))
                {
                    return;
                }
                listViewDV.Items.Clear();
                string sql2 = string.Format("update DICHVU set TENDICHVU = N'" + txtTenDichVu.Text + "',GIATIEN = '" + float.Parse(txtGiaTien.Text) + "',GHICHU = N'" + txtGhiChu.Text + "' where MADICHVU = '" + txtMaDichVu.Text + "'");
                if (xldl.insertUpdateDelete(sql2) != -1)
                    loadDataDV();
                MessageBox.Show("Sửa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                listViewDV.Items.Clear();
                string sql = "delete from DICHVU where MADICHVU='" + txtMaDichVu.Text + "'";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadDataDV();
                    MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            DVResetText();
            btn_sua.Enabled = btn_them.Enabled = btn_xoa.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
