using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebAppApi6.Data
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string? TenLoai { get; set; }
        
        public virtual ICollection<HangHoaData>? HangHoas { get; set;}
    }
}
