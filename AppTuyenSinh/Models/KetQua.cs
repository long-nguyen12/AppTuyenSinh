namespace AppTuyenSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KetQua")]
    public partial class KetQua
    {
        [Key]
     
        public int KetQua_ID { get; set; }

        public double? KetQua_DiemTH1 { get; set; }

        public double? KetQua_DiemTH2 { get; set; }

        public double? KetQua_DiemTH3 { get; set; }

        public double? KetQua_DiemTH4 { get; set; }

        public bool? TrangThai { get; set; }

        public long? HocBa_ID { get; set; }

        public virtual HocBa HocBa { get; set; }
    }
}
