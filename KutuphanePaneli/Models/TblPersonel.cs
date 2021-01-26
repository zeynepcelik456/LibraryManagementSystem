using System;
using System.Collections.Generic;

#nullable disable

namespace KutuphanePaneli.Models
{
    public partial class TblPersonel
    {
        public TblPersonel()
        {
            TblHarekets = new HashSet<TblHareket>();
        }

        public byte Id { get; set; }
        public string Personel { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TblHareket> TblHarekets { get; set; }
    }
}
