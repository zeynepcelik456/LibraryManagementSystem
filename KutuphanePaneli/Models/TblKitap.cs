using System;
using System.Collections.Generic;

#nullable disable

namespace KutuphanePaneli.Models
{
    public partial class TblKitap
    {
        public TblKitap()
        {
            TblHarekets = new HashSet<TblHareket>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public byte? Kategori { get; set; }
        public int? Yazar { get; set; }
        public string Basimyili { get; set; }
        public string Yayinevi { get; set; }
        public string Sayfasayisi { get; set; }
        public bool? Durum { get; set; }

        public virtual TblKategori KategoriNavigation { get; set; }
        public virtual TblYazar YazarNavigation { get; set; }
        public virtual ICollection<TblHareket> TblHarekets { get; set; }
    }
}
