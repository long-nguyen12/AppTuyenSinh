namespace AppTuyenSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonVi")]
    public partial class DonVi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonVi()
        {
            Nganhs = new HashSet<Nganh>();
        }

        [Key]
        public int DonVi_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string DonVi_Ma { get; set; }

        [Required]
        [StringLength(50)]
        public string DonVi_Ten { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nganh> Nganhs { get; set; }
    }
}
