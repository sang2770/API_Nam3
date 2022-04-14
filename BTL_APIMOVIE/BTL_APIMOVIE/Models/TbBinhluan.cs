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

        public virtual TbPhim MaphimNavigation { get; set; } = null!;
        public virtual TbNguoidung MataikhoanNavigation { get; set; } = null!;
    }
}
