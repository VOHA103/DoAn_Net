using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHATRO_QLNT.DAO
{
   public  class TAIKHOAN
    {
        string taiKhoan;
        string matKhau;
        int phanQuyen;

        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int PhanQuyen { get => phanQuyen; set => phanQuyen = value; }

    }
}
