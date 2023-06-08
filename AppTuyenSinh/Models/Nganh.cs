namespace AppTuyenSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Nganh")]
    public partial class Nganh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nganh()
        {
            ThiSinhs = new HashSet<ThiSinh>();
        }

        [Key]
        public int Nganh_ID { get; set; }


        [Display(Name = "Mã ngành")]
        [Required(ErrorMessage = "Vui lòng nhập mã ngành.")]
        [StringLength(20)]
        public string Nganh_Ma { get; set; }

        [Display(Name = "Tên ngành")]
        [Required(ErrorMessage = "Vui lòng nhập tên ngành.")]
        [StringLength(250)]
        public string Nganh_Ten { get; set; }
               
        [Display(Name = "Ngành")] /*Thêm để hiển thị cả mã ngành và tên ngành trong dropdownlist*/
        public string Nganh_Ma_Ten { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Nganh_ToHopXT { get; set; }

        public bool Nganh_SP { get; set; }

        public int DonVi_ID { get; set; }

        public virtual DonVi DonVi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThiSinh> ThiSinhs { get; set; }
       
    }
}
