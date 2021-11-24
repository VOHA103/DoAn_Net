using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNHATRO_QLNT.DAO;

namespace QLNHATRO_QLNT.GUI
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        login lg;
       static TAIKHOAN tk = new TAIKHOAN();

        public MDIParent1()
        {
            InitializeComponent();
            button2.Visible = false;
            itemDX.Enabled =false;
            itemKNHT.Visible = false;
        }
        void load()
        {
            if (tk.PhanQuyen == 1)
            {
                menuStrip.Enabled = true;
                itemDanhMuc.Visible = true;
                button1.Enabled = true;
                btnThanhToan.Enabled = true;
                btnThuePhong.Enabled = true;
                itemKNHT.Visible = true;
                itemDX.Enabled = true;
            }
            else 
            {

                itemDX.Enabled = itemDMK.Enabled = itemDK.Enabled = true;
                itemDanhMuc.Visible = false;
                button1.Enabled = true;
                btnThanhToan.Enabled = true;
                btnThuePhong.Enabled = true;
                itemDX.Enabled = true;
            }
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon cthd = new ChiTietHoaDon();
            cthd.MdiParent = this;
            cthd.Show();
        }

        private void btnThuePhong_Click(object sender, EventArgs e)
        {
            ThuePhong thuephong = new ThuePhong();
            thuephong.MdiParent = this;
            thuephong.Show();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            ThongTinThanhToan ttthanhtoan = new ThongTinThanhToan();
            ttthanhtoan.MdiParent = this;
            ttthanhtoan.Show();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login lg = new login();
            lg.MdiParent = this;
            lg.Show();
            button2.Visible = true;
            btnLogin.Visible = false;
        }
        
        public static void xuat(TAIKHOAN tk2) {
            tk = tk2;
            if (tk.PhanQuyen == 1)
            {
                MessageBox.Show("Xin chào Admin");
            }
            if (tk.PhanQuyen == 0)
            {
                MessageBox.Show("Xin chào User");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnLogin.Visible = false;
            load();
            button2.Enabled = false;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void itemDX_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void itemDMK_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            dmk.MdiParent = this;
            dmk.Show();

        }

        private void itemKNHT_Click(object sender, EventArgs e)
        {
            KETNOIHETHONG knht = new KETNOIHETHONG();
            knht.MdiParent = this;
            knht.Show();
        }

        private void itemDK_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.MdiParent = this;
            dk.Show();

        }

        private void itemPhong_Click(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            phong.MdiParent = this;
            phong.Show();

        }

        private void itemLoaiPhong_Click(object sender, EventArgs e)
        {
            LoaiPhong lp = new LoaiPhong();
            lp.MdiParent = this;
            lp.Show();
        }

        private void itemDichVu_Click(object sender, EventArgs e)
        {
            DichVu dv = new DichVu();
            dv.MdiParent = this;
            dv.Show();
        }

        private void itemHopDong_Click(object sender, EventArgs e)
        {
            HopDong hd = new HopDong();
            hd.MdiParent = this;
            hd.Show();
        }

        private void itemQLUser_Click(object sender, EventArgs e)
        {
            QuanLyUser qluser = new QuanLyUser();
            qluser.MdiParent = this;
            qluser.Show();
        }

        private void itemHoaDon_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.MdiParent = this;
            hd.Show();
        }
    }
}
