namespace AppTuyenSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocBa")]
    public partial class HocBa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocBa()
        {
            KetQuas = new HashSet<KetQua>();
        }

        [Key]
        public long HocBa_ID { get; set; }

        public int HocBa_HocKi { get; set; }

        public int HocBa_Lop { get; set; }

        public double? HocBa_DiemToan { get; set; }

        public double? HocBa_DiemLi { get; set; }

        public double? HocBa_DiemHoa { get; set; }

        public double? HocBa_DiemVan { get; set; }

        public double? HocBa_DiemAnh { get; set; }

        public double? HocBa_DiemGDCD { get; set; }

        public double? HocBa_DiemSinh { get; set; }

        public double? HocBa_DiemSu { get; set; }

        public double? HocBa_DiemDia { get; set; }

        public int? HocBa_HocLuc { get; set; }

        public long ThiSinh_ID { get; set; }

        public virtual ThiSinh ThiSinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQua> KetQuas { get; set; }
    }
}
