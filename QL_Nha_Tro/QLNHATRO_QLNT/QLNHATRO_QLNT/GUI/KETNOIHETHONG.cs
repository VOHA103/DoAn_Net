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
    public partial class KETNOIHETHONG : Form
    {
        XULYDULIEU db = new XULYDULIEU();
        AppSetting appset = new AppSetting();
        string connectionString;
        public KETNOIHETHONG()
        {
            InitializeComponent();
            cbbAuthen.Items.Add("Windows Authentication");
            cbbAuthen.Items.Add("SQL Server Authentication");
            cbbAuthen.SelectedIndex = 0;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbAuthen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbAuthen.SelectedIndex != -1)
            {
                if (cbbAuthen.SelectedIndex == 0)
                    pnAcc.Enabled = false;
                else
                    pnAcc.Enabled = true;
            }
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
      

        private void btText_Click_1(object sender, EventArgs e)
        {
           
                if (TienIch.ktRong(txtServer) || TienIch.ktRong(txtData))
                    return;
                if (cbbAuthen.SelectedIndex == 0)
                    connectionString = string.Format("server={0};database={1};Integrated Security=True;", txtServer.Text, txtData.Text);
                else
                {
                    if (TienIch.ktRong(txtID) || TienIch.ktRong(txtPass))
                        return;
                    connectionString = string.Format("server={0};database={1};Integrated Security=False;uid={2};pwd={3}",
                   txtServer.Text, txtData.Text, txtID.Text, txtPass.Text);

                }
                //QLPHONGTRO
                //ACER-THUHA

                if (db.testConnection(connectionString))
                {
                    MessageBox.Show("Success", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                   
                }
                else
                    MessageBox.Show("Connect Fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


         
        }

        private void btSave_Click_1(object sender, EventArgs e)
        {
            
                if (TienIch.ktRong(txtServer) || TienIch.ktRong(txtData))
                    return;
                if (cbbAuthen.SelectedIndex == 0)
                    connectionString = string.Format("server={0};database={1};Integrated Security=True;", txtServer.Text, txtData.Text);
                else
                {
                    if (TienIch.ktRong(txtID) || TienIch.ktRong(txtPass))
                        return;
                    connectionString = string.Format("server={0};database={1};Integrated Security=False;uid={2};pwd={3}",
                   txtServer.Text, txtData.Text, txtID.Text, txtPass.Text);

                }
                //QLPHONGTRO
                //ACER-THUHA

                if (db.testConnection(connectionString))
                {
                    appset.setConnectionString("QLNHATRO_QLNT.Properties.Settings.QLPHONGTROConnectionString", connectionString);
                    MessageBox.Show("Save Success", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                new MDIParent1().ShowDialog();

                Close();
                }

                else
                    MessageBox.Show("Save Fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

          
        }

        private void KETNOIHETHONG_Load(object sender, EventArgs e)
        {

        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
