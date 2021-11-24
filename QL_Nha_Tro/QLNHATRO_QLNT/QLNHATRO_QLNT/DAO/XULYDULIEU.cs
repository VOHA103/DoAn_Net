using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHATRO_QLNT
{
 public    class XULYDULIEU
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        AppSetting appsetting = new AppSetting();

        public XULYDULIEU()
        {
            string conStr = "Data Source= ACER-THUHA;Initial Catalog = QLPHONGTRO;User ID = sa;Password = 1003";
            con = new SqlConnection(conStr);

            //string chuoiketnoi = appsetting.getConnectionString("QLNHATRO_QLNT.Properties.Settings.QLPHONGTROConnectionString");
            //con = new SqlConnection(chuoiketnoi);
        }
        public XULYDULIEU(string sv, string db, bool au, string uid, string pwd)
        {
            //string chuoiketnoi = "";
            //if (au == true)
            //    chuoiketnoi = string.Format("server={0}; database={1};integrated security={2}", sv, db, au);
            //else
            //    chuoiketnoi = string.Format("Data Source= {0};Initial Catalog = {1};User ID = {2};Password = {3}", sv, db, uid, pwd);
            //con = new SqlConnection(chuoiketnoi);
        }
        public bool testConnection(string connectionString)
        {
            con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                con.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public DataTable readData(string sql)
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            return dt;
           
        }
        public SqlDataReader readDataTable(string sql)
        {
            SqlCommand com = new SqlCommand(sql, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataReader dr = com.ExecuteReader();
            return dr;
        }
        public int insertUpdateDelete(string sql)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(sql, con);
            int kq = cmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return kq;
        }
        public void CapNhap(string lenhsql, DataTable dt)
        {
            da = new SqlDataAdapter(lenhsql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(dt);
        }
        public int CountSumMax(string sql)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(sql, con);
            int kq = (int)cmd.ExecuteScalar();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return kq;
        }
        public string Chuoi(string sql)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(sql, con);
            string kq = (string)cmd.ExecuteScalar();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return kq;
        }
    }
}
