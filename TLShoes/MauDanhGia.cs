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
    
    public partial class MauDanhGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MauDanhGia()
        {
            this.ChiTietMauDanhGias = new HashSet<ChiTietMauDanhGia>();
            this.DanhGias = new HashSet<DanhGia>();
        }
    
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public Nullable<long> CreatedDate { get; set; }
        public Nullable<long> ModifiedDate { get; set; }
        public Nullable<bool> IsActived { get; set; }
        public string GhiChu { get; set; }
        public string TenMau { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietMauDanhGia> ChiTietMauDanhGias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
