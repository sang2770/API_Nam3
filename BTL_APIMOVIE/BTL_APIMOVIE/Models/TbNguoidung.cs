using System;
using System.Collections.Generic;

namespace BTL_APIMOVIE.Models
{
    public partial class TbNguoidung
    {
        public TbNguoidung()
        {
            TbBinhluans = new HashSet<TbBinhluan>();
        }

        public TbNguoidung(string tendangnhap, string loaitaikhoan, string matkhau)
        {
            Tendangnhap = tendangnhap;
            Loaitaikhoan = loaitaikhoan;
            Matkhau = matkhau;
        }

        public int Mataikhoan { get; set; }
        public string Tendangnhap { get; set; } = null!;
        public string Loaitaikhoan { get; set; } = null!;
        public string Matkhau { get; set; } = null!;

        public virtual ICollection<TbBinhluan> TbBinhluans { get; set; } = null!;
    }
}
