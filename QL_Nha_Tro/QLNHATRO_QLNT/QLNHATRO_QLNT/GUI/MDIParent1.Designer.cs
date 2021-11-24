
namespace QLNHATRO_QLNT.GUI
{
    partial class MDIParent1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDX = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDMK = new System.Windows.Forms.ToolStripMenuItem();
            this.itemKNHT = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDK = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemLoaiPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHopDong = new System.Windows.Forms.ToolStripMenuItem();
            this.itemQLUser = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelshow = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnThuePhong = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.panelshow.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip.BackgroundImage")));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.itemDanhMuc});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(938, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemDX,
            this.itemDMK,
            this.itemKNHT,
            this.itemDK});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hệThốngToolStripMenuItem.ForeColor = System.Drawing.Color.AliceBlue;
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(111, 29);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // itemDX
            // 
            this.itemDX.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemDX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDX.ForeColor = System.Drawing.Color.AliceBlue;
            this.itemDX.Name = "itemDX";
            this.itemDX.Size = new System.Drawing.Size(246, 30);
            this.itemDX.Text = "Đăng Xuất";
            this.itemDX.Click += new System.EventHandler(this.itemDX_Click);
            // 
            // itemDMK
            // 
            this.itemDMK.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemDMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDMK.ForeColor = System.Drawing.Color.AliceBlue;
            this.itemDMK.Name = "itemDMK";
            this.itemDMK.Size = new System.Drawing.Size(246, 30);
            this.itemDMK.Text = "Đổi Mật Khẩu";
            this.itemDMK.Click += new System.EventHandler(this.itemDMK_Click);
            // 
            // itemKNHT
            // 
            this.itemKNHT.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemKNHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemKNHT.ForeColor = System.Drawing.Color.AliceBlue;
            this.itemKNHT.Name = "itemKNHT";
            this.itemKNHT.Size = new System.Drawing.Size(246, 30);
            this.itemKNHT.Text = "Kết Nối Hệ Thống";
            this.itemKNHT.Click += new System.EventHandler(this.itemKNHT_Click);
            // 
            // itemDK
            // 
            this.itemDK.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDK.ForeColor = System.Drawing.Color.AliceBlue;
            this.itemDK.Name = "itemDK";
            this.itemDK.Size = new System.Drawing.Size(246, 30);
            this.itemDK.Text = "Đăng Ký";
            this.itemDK.Click += new System.EventHandler(this.itemDK_Click);
            // 
            // itemDanhMuc
            // 
            this.itemDanhMuc.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemPhong,
            this.itemDichVu,
            this.itemLoaiPhong,
            this.itemHopDong,
            this.itemQLUser,
            this.itemHoaDon});
            this.itemDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDanhMuc.ForeColor = System.Drawing.Color.AliceBlue;
            this.itemDanhMuc.Name = "itemDanhMuc";
            this.itemDanhMuc.Size = new System.Drawing.Size(113, 29);
            this.itemDanhMuc.Text = "Danh mục";
            // 
            // itemPhong
            // 
            this.itemPhong.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemPhong.ForeColor = System.Drawing.Color.AliceBlue;
            this.itemPhong.Name = "itemPhong";
            this.itemPhong.Size = new System.Drawing.Size(211, 30);
            this.itemPhong.Text = "Phòng";
            this.itemPhong.Click += new System.EventHandler(this.itemPhong_Click);
            // 
            // itemDichVu
            // 
            this.itemDichVu.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDichVu.ForeColor = System.Drawing.Color.AliceBlue;
            this.itemDichVu.Name = "itemDichVu";
            this.itemDichVu.Size = new System.Drawing.Size(211, 30);
            this.itemDichVu.Text = "Dịch Vụ";
            this.itemDichVu.Click += new System.EventHandler(this.itemDichVu_Click);
            // 
            // itemLoaiPhong
            // 
            this.itemLoaiPhong.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemLoaiPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemLoaiPhong.ForeColor = System.Drawing.Color.AliceBlue;
            this.itemLoaiPhong.Name = "itemLoaiPhong";
            this.itemLoaiPhong.Size = new System.Drawing.Size(211, 30);
            this.itemLoaiPhong.Text = "Loại Phòng";
            this.itemLoaiPhong.Click += new System.EventHandler(this.itemLoaiPhong_Click);
            // 
            // itemHopDong
            // 
            this.itemHopDong.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemHopDong.ForeColor = System.Drawing.Color.AliceBlue;
            this.itemHopDong.Name = "itemHopDong";
            this.itemHopDong.Size = new System.Drawing.Size(211, 30);
            this.itemHopDong.Text = "Hợp Đồng";
            this.itemHopDong.Click += new System.EventHandler(this.itemHopDong_Click);
            // 
            // itemQLUser
            // 
            this.itemQLUser.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemQLUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemQLUser.ForeColor = System.Drawing.Color.AliceBlue;
            this.itemQLUser.Name = "itemQLUser";
            this.itemQLUser.Size = new System.Drawing.Size(211, 30);
            this.itemQLUser.Text = "Quan Lý User";
            this.itemQLUser.Click += new System.EventHandler(this.itemQLUser_Click);
            // 
            // itemHoaDon
            // 
            this.itemHoaDon.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemHoaDon.ForeColor = System.Drawing.Color.AliceBlue;
            this.itemHoaDon.Name = "itemHoaDon";
            this.itemHoaDon.Size = new System.Drawing.Size(211, 30);
            this.itemHoaDon.Text = "Hóa Đơn";
            this.itemHoaDon.Click += new System.EventHandler(this.itemHoaDon_Click);
            // 
            // panelshow
            // 
            this.panelshow.BackColor = System.Drawing.Color.White;
            this.panelshow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelshow.BackgroundImage")));
            this.panelshow.Controls.Add(this.button2);
            this.panelshow.Controls.Add(this.btnLogin);
            this.panelshow.Controls.Add(this.btnThanhToan);
            this.panelshow.Controls.Add(this.btnThuePhong);
            this.panelshow.Controls.Add(this.button1);
            this.panelshow.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelshow.Location = new System.Drawing.Point(0, 33);
            this.panelshow.Name = "panelshow";
            this.panelshow.Size = new System.Drawing.Size(185, 449);
            this.panelshow.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.AliceBlue;
            this.button2.Location = new System.Drawing.Point(12, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 88);
            this.button2.TabIndex = 15;
            this.button2.Text = "Hiện Chức Năng";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnLogin.Location = new System.Drawing.Point(12, 29);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(151, 88);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.Transparent;
            this.btnThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnThanhToan.Location = new System.Drawing.Point(12, 330);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(152, 85);
            this.btnThanhToan.TabIndex = 13;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnThuePhong
            // 
            this.btnThuePhong.BackColor = System.Drawing.Color.Transparent;
            this.btnThuePhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThuePhong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThuePhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuePhong.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnThuePhong.Location = new System.Drawing.Point(11, 231);
            this.btnThuePhong.Name = "btnThuePhong";
            this.btnThuePhong.Size = new System.Drawing.Size(152, 89);
            this.btnThuePhong.TabIndex = 12;
            this.btnThuePhong.Text = "Thuê Phòng";
            this.btnThuePhong.UseVisualStyleBackColor = false;
            this.btnThuePhong.Click += new System.EventHandler(this.btnThuePhong_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.AliceBlue;
            this.button1.Location = new System.Drawing.Point(12, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 92);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thêm Dịch Vụ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(938, 482);
            this.Controls.Add(this.panelshow);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MDIParent1";
            this.Text = "MDIParent1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelshow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemDX;
        private System.Windows.Forms.ToolStripMenuItem itemDMK;
        private System.Windows.Forms.ToolStripMenuItem itemKNHT;
        private System.Windows.Forms.ToolStripMenuItem itemDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem itemPhong;
        private System.Windows.Forms.ToolStripMenuItem itemLoaiPhong;
        private System.Windows.Forms.ToolStripMenuItem itemDichVu;
        private System.Windows.Forms.Panel panelshow;
        private System.Windows.Forms.ToolStripMenuItem itemHopDong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem itemQLUser;
        private System.Windows.Forms.Button btnThuePhong;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem itemDK;
        private System.Windows.Forms.ToolStripMenuItem itemHoaDon;
    }
}



