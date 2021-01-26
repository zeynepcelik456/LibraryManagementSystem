using System;
using System.Collections.Generic;

#nullable disable

namespace KutuphanePaneli.Models
{
    public partial class TblUye
    {
        public TblUye()
        {
            TblHarekets = new HashSet<TblHareket>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Maİl { get; set; }
        public string Telefon { get; set; }

        public virtual ICollection<TblHareket> TblHarekets { get; set; }
    }
}
