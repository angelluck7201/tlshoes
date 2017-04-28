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
    
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            this.NhaCungCapVatTus = new HashSet<NhaCungCapVatTu>();
            this.DonDatHangs = new HashSet<DonDatHang>();
            this.DonDatHangs1 = new HashSet<DonDatHang>();
            this.ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
        }
    
        public long Id { get; set; }
        public Nullable<long> AuthorId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool IsActived { get; set; }
        public string TenCongTy { get; set; }
        public string TenNguoiDaiDien { get; set; }
        public string DiaChi { get; set; }
        public string Dienthoai { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string MatHang { get; set; }
        public int DungYeuCauKyThuat { get; set; }
        public int DungThoiGian { get; set; }
        public int DungMau { get; set; }
        public int DatTestLy { get; set; }
        public int DatTestHoa { get; set; }
        public int Gia { get; set; }
        public int DichVuGiaoHang { get; set; }
        public int DichVuHauMai { get; set; }
        public int Khac { get; set; }
        public string GhiChuNoiBo { get; set; }
        public string GhiChu { get; set; }
    
        public virtual UserAccount UserAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhaCungCapVatTu> NhaCungCapVatTus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
    }
}
