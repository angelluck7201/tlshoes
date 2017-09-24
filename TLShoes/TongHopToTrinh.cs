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
    
    public partial class TongHopToTrinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TongHopToTrinh()
        {
            this.ToTrinhs = new HashSet<ToTrinh>();
        }
    
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsActived { get; set; }
        public string SoPhieu { get; set; }
        public string TrangThai { get; set; }
        public Nullable<long> NguoiLapId { get; set; }
        public System.DateTime NgayLap { get; set; }
        public Nullable<long> NguoiDuyetId { get; set; }
        public System.DateTime NgayDuyet { get; set; }
        public string GhiChu { get; set; }
    
        public virtual UserAccount UserAccount { get; set; }
        public virtual UserAccount NguoiLap { get; set; }
        public virtual UserAccount NguoiDuyet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToTrinh> ToTrinhs { get; set; }
    }
}
