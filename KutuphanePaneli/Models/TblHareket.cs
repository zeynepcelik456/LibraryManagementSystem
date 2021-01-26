using System;
using System.Collections.Generic;

#nullable disable

namespace KutuphanePaneli.Models
{
    public partial class TblHareket
    {
        public int Id { get; set; }
        public int? Kitap { get; set; }
        public int? Uye { get; set; }
        public DateTime? Alistarihi { get; set; }
        public DateTime? Iadetarihi { get; set; }
        public byte? Personel { get; set; }
        public bool? Islemdurum
        {

            get; set;

        }

       

        public virtual TblKitap KitapNavigation { get; set; }
    public virtual TblPersonel PersonelNavigation { get; set; }
    public virtual TblUye UyeNavigation { get; set; }
}
}
