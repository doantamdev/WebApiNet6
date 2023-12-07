using System.ComponentModel.DataAnnotations;

namespace MyWebAppApi6.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string? TenLoai {  get; set; }
    }
}
