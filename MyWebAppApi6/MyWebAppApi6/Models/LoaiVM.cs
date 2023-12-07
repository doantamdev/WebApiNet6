using System.ComponentModel.DataAnnotations;

namespace MyWebAppApi6.Models
{
    public class LoaiVM
    {
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string? TenLoai { get; set; }
    }
}
