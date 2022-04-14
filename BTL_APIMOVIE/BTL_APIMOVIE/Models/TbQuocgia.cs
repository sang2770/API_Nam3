using System;
using System.Collections.Generic;

namespace BTL_APIMOVIE.Models
{
    public partial class TbQuocgia
    {
        public TbQuocgia()
        {
            TbPhimQuocgia = new HashSet<TbPhimQuocgia>();
        }

        public int Maquocgia { get; set; }
        public string Tenquocgia { get; set; } = null!;

        public virtual ICollection<TbPhimQuocgia> TbPhimQuocgia { get; set; }
    }
}
