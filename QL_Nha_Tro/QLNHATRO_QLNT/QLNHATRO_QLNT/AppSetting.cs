using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace QLNHATRO_QLNT
{
    public class AppSetting
    {
        Configuration config;
        public AppSetting()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        }

        public string getConnectionString(string name)
        {
            //ten---tung ong--chuoi
            return config.ConnectionStrings.ConnectionStrings[name].ConnectionString;

        }

        //thay doi
        public void setConnectionString(string name, string newvalue)
        {
            config.ConnectionStrings.ConnectionStrings[name].ConnectionString = newvalue;
            config.ConnectionStrings.ConnectionStrings[name].ProviderName = "System.Data.SqlClient";

        }
    }
}
