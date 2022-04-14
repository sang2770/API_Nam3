using System;
using System.Collections.Generic;

namespace BTL_APIMOVIE.Models
{
    public partial class TbPhim
    {
        public TbPhim()
        {
            TbBinhluans = new HashSet<TbBinhluan>();
            TbPhimLoaiPhims = new HashSet<TbPhimLoaiPhim>();
            TbPhimQuocgia = new HashSet<TbPhimQuocgia>();
        }

        public int Maphim { get; set; }
        public string? Tenphim { get; set; }
        public string? Motaphim { get; set; }
        public int Thoiluong { get; set; }
        public string? Anh { get; set; }
        public string? Ngonngu { get; set; } = null!;
        public string? Duongdan { get; set; } = null!;
        public int Nam { get; set; }
        public int Danhgiaphim { get; set; }

        public virtual ICollection<TbBinhluan> TbBinhluans { get; set; }
        public virtual ICollection<TbPhimLoaiPhim> TbPhimLoaiPhims { get; set; }
        public virtual ICollection<TbPhimQuocgia> TbPhimQuocgia { get; set; }
    }
}
