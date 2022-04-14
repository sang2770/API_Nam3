using System;
using System.Collections.Generic;

namespace BTL_APIMOVIE.Models
{
    public partial class TbLoaiphim
    {
        public TbLoaiphim()
        {
            TbPhimLoaiPhims = new HashSet<TbPhimLoaiPhim>();
        }

        public int Maloaiphim { get; set; }
        public string Tenloaiphim { get; set; } = null!;

        public virtual ICollection<TbPhimLoaiPhim> TbPhimLoaiPhims { get; set; }
    }
}
