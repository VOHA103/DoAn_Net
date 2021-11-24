using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace QLNHATRO_QLNT.MODEL
{
  public  class TienIch
    {

        public TienIch() { }

        /// <summary>
        /// 
        /// link tham khao :https: //tuandc.com/lap-trinh/huong-dan-ma-hoa-mat-khau-1-chieu-voi-md5-trong-c.html
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static string md_5(string pass)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(pass));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
