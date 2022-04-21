using System;
using System.Collections.Generic;

namespace BTL_APIMOVIE.Models
{
    public partial class TbPhimLoaiPhim
    {
        public int Ma { get; set; }
        public int Maphim { get; set; }
        public int Maloaiphim { get; set; }

        public TbPhimLoaiPhim(int Ma, int Maphim, int Maloaiphim)
        {
            this.Ma = Ma;
            this.Maphim = Maphim;
            this.Maloaiphim = Maloaiphim;
        }

        public virtual TbLoaiphim MaloaiphimNavigation { get; set; } = null!;
        public virtual TbPhim MaphimNavigation { get; set; } = null!;
    }
}
