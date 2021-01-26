using System;
using System.Collections.Generic;

#nullable disable

namespace KutuphanePaneli.Models
{
    public partial class TblKategori
    {
        public TblKategori()
        {
            TblKitaps = new HashSet<TblKitap>();
        }

        public byte Id { get; set; }
        public string Ad { get; set; }

        public virtual ICollection<TblKitap> TblKitaps { get; set; }
    }
}
