//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyShopThoiTrang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            this.CTDonHang = new HashSet<CTDonHang>();
        }
    
        public int MaDH { get; set; }
        public string NgayDat { get; set; }
        public string DiaChi { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> TongTien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonHang> CTDonHang { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
