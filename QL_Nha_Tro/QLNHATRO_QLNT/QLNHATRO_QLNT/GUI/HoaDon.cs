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
    public partial class HoaDon : Form
    {
        XULYDULIEU xldl = new XULYDULIEU();
        DataTable dtHDon;
        DataTable dtComboboxphong;

        public HoaDon()
        {
            InitializeComponent();
          
        }
        public void reset()
        {

            txttien.Text = "";
            txttien.Focus();
        }
       
    
        void loadComboboxLoaiPhong()
        {
            cb_phong.Items.Clear();
            dtComboboxphong = xldl.readData("select * from PHONG");
            foreach (DataRow dong in dtComboboxphong.Rows)
            {
                cb_phong.Items.Add(dong[0].ToString());
            }

        }
        public void loadData()
        {
            dtHDon = xldl.readData("select * from HOADON");
            listView1.Items.Clear();

            foreach (DataRow dong in dtHDon.Rows)
            {
                ListViewItem lvi = listView1.Items.Add(dong[0].ToString());
                lvi.SubItems.Add(dong[1].ToString());
                lvi.SubItems.Add(dong[2].ToString());
                lvi.SubItems.Add(dong[3].ToString());
            }
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            loadComboboxLoaiPhong();
            if (listView1.SelectedItems.Count > 0)
            {
                txt_mahd.Text = listView1.SelectedItems[0].SubItems[0].Text;
                cb_phong.SelectedItem = listView1.SelectedItems[0].SubItems[1].Text;
                txttien.Text = listView1.SelectedItems[0].SubItems[2].Text;
                date_tt.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }

            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txt_mahd.Text = listView1.SelectedItems[0].SubItems[0].Text;
                cb_phong.SelectedItem = listView1.SelectedItems[0].SubItems[1].Text;
                txttien.Text = listView1.SelectedItems[0].SubItems[2].Text;
                date_tt.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
            loadData();
        }

        private void btnThem_Click_5(object sender, EventArgs e)
        {
            //try
            //{
                if (TienIch.ktRong(txttien))
                {
                    return;

                }
                if (cb_phong.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui long chon ma loai phong");
                    return;
                }
                listView1.Items.Clear();
                string sql = "SET DATEFORMAT dmy;insert into HOADON values ('" + cb_phong.Text + "', '" + txttien.Text + "','" + date_tt.Text + "')";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadData();
                    MessageBox.Show("Thêm Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                reset();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("Loi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    reset();
            //    loadData();
            //}

        }


        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (TienIch.ktRong(txttien))
                    return;
                listView1.Items.Clear();
                string sql = "SET DATEFORMAT dmy;update HOADON set MAPHONG='" + cb_phong.Text + "', TONGTIEN='" + txttien.Text + "', THANG_THANHTOAN='" + date_tt.Text + "' where MAHOADON='" + txt_mahd.Text + "'";

                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadData();
                    MessageBox.Show("Sửa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                reset();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reset();
                loadData();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
              
                listView1.Items.Clear();
                string sql = "SET DATEFORMAT dmy;delete from HOADON where MAHOADON='" + txt_mahd.Text + "'";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadData();
                    MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                reset();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi khoa ngoai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reset();
                loadData();

            }

        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            new BCHDON().ShowDialog();

        }

      
    }
}
