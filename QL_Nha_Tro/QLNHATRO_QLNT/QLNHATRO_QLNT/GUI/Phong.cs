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
    public partial class Phong : Form
    {
        XULYDULIEU xldl = new XULYDULIEU();
        DataTable dtPhong;
        DataTable dtComboboxKH;
        string maphong;
        public Phong()
        {
            InitializeComponent();
            loadData();
            maP();
        }
        string maP()
        {
            string sqlSLP = "select COUNT(*) from PHONG";
            string malp = "P" + (xldl.CountSumMax(sqlSLP) + 1);
            return malp;
        }
        public void reset()
        {
    
            txt_tenphong.Text = "";
            txt_tenphong.Focus();
            txt_trangthai.Text = "";
            maP();
        }
        void loadComboboxLoaiPhong()
        {
            cb_loai.Items.Clear();
            dtComboboxKH = xldl.readData("select * from LOAIPHONG");
            foreach (DataRow dong in dtComboboxKH.Rows)
            {
                cb_loai.Items.Add(dong[0].ToString());
            }
           
        }
        public void loadData()
        {
            dtPhong = xldl.readData("select * from PHONG");
            listView1.Items.Clear();
           
            foreach (DataRow dong in dtPhong.Rows)
            {
                ListViewItem lvi = listView1.Items.Add(dong[0].ToString());
                lvi.SubItems.Add(dong[1].ToString());
                lvi.SubItems.Add(dong[2].ToString());
                lvi.SubItems.Add(dong[3].ToString());
            }
        }
        private void Phong_Load(object sender, EventArgs e)
        {
            loadComboboxLoaiPhong();
            if (listView1.SelectedItems.Count > 0)
            {
                maphong = listView1.SelectedItems[0].SubItems[0].Text;
                cb_loai.SelectedItem = listView1.SelectedItems[0].SubItems[1].Text;
                txt_tenphong.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txt_trangthai.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
            cb_loai.SelectedIndex = 0;

            loadData();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Close();

        }
        bool ktraRong(TextBox txt)
        {
            if (String.IsNullOrEmpty(txt.Text))
            {
                MessageBox.Show(txt.Tag + " Không được rỗng", "Thông báo");
                txt.Focus();
                return true;
            }
            return false;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                maphong = listView1.SelectedItems[0].SubItems[0].Text;
                cb_loai.SelectedItem = listView1.SelectedItems[0].SubItems[1].Text;
                txt_tenphong.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txt_trangthai.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
            loadData();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktraRong(txt_tenphong))
                    return;
                if (cb_loai.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui long chon ma loai phong");
                    return;
                }
                listView1.Items.Clear();
                string sql = "insert into PHONG values ('" + maP() + "','" + cb_loai.Text + "', N'" + txt_tenphong.Text + "',null)";
                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadData();
                    MessageBox.Show("Thêm Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void button2_Click(object sender, EventArgs e)
        {
                MessageBox.Show(maphong);
                if (ktraRong(txt_tenphong))
                    return;
                listView1.Items.Clear();
                string sql = "update PHONG set MALOAI='"+cb_loai.Text+"',TENPHONG=N'"+txt_tenphong.Text+"',TRANGTHAI=N'"+txt_trangthai.Text+"' where MAPHONG='"+maphong +"'";
                //listView1.SelectedItems[0].SubItems[3].Text = cbbLop.SelectedItem.ToString();

                if (xldl.insertUpdateDelete(sql) != -1)
                {
                    loadData();
                    MessageBox.Show("Sửa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
                else
                {
                    MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktraRong(txt_tenphong))
                    return;
                listView1.Items.Clear();
                string sql = "delete from PHONG where MAPHONG='" + maphong + "'";
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
