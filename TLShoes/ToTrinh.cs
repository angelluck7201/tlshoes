//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TLShoes
{
    using System;
    using System.Collections.Generic;
    
    public partial class ToTrinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ToTrinh()
        {
            this.ChiTietToTrinhs = new HashSet<ChiTietToTrinh>();
            this.DonDatHangs = new HashSet<DonDatHang>();
        }
    
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public Nullable<long> CreatedDate { get; set; }
        public Nullable<long> ModifiedDate { get; set; }
        public Nullable<bool> IsActived { get; set; }
        public Nullable<long> NguyenLieuId { get; set; }
        public Nullable<float> BoSung { get; set; }
        public Nullable<float> ThuHoi { get; set; }
        public Nullable<float> TonToTrinh { get; set; }
        public Nullable<float> TonTheKho { get; set; }
        public Nullable<float> TonThucTe { get; set; }
        public Nullable<float> DuKien { get; set; }
        public Nullable<float> HaoHut { get; set; }
        public string GhiChu { get; set; }
        public string DonDatHangList { get; set; }
        public Nullable<long> TongHopToTrinhId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietToTrinh> ChiTietToTrinhs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }
        public virtual TongHopToTrinh TongHopToTrinh { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
