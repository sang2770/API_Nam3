using System;
using System.Collections.Generic;

namespace BTL_APIMOVIE.Models
{
    public partial class TbPhimQuocgia
    {
        public int Ma { get; set; }
        public int Maquocgia { get; set; }
        public int Maphim { get; set; }

        public virtual TbPhim MaphimNavigation { get; set; } = null!;
        public virtual TbQuocgia MaquocgiaNavigation { get; set; } = null!;
    }
}
