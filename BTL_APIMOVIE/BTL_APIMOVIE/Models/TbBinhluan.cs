using System;
using System.Collections.Generic;

namespace BTL_APIMOVIE.Models
{
    public partial class TbBinhluan
    {
        public int Mabinhluan { get; set; }
        public int Mataikhoan { get; set; }
        public int Maphim { get; set; }
        public string? Noidung { get; set; }
        public DateTime? Thoigian { get; set; }

        public TbBinhluan(int mataikhoan, int maphim, string? noidung, DateTime? thoigian)
        {
          
            Mataikhoan = mataikhoan;
            Maphim = maphim;
            Noidung = noidung;
            Thoigian = thoigian;
        }

        public virtual TbPhim MaphimNavigation { get; set; } = null!;
        public virtual TbNguoidung MataikhoanNavigation { get; set; } = null!;
    }
}
