using System;
using System.Collections.Generic;

#nullable disable

namespace KutuphanePaneli.Models
{
    public partial class TblYazar
    {
        public TblYazar()
        {
            TblKitaps = new HashSet<TblKitap>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public virtual ICollection<TblKitap> TblKitaps { get; set; }
    }
}
