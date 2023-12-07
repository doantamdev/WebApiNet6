using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebAppApi6.Data
{

        [Table("HangHoa")]
        public class HangHoaData
        {
            [Key]
            public Guid MaHh { get; set; }

            [Required]
            [MaxLength(100)]
            public string? TenHh { get; set; }

            public string? MoTa { get; set; }

            [Range(0, double.MaxValue)]
            public double DonGia { get; set; }

            public byte GiamGia { get; set; }

            public int? MaLoai { get; set; }
           [ForeignKey("MaLoai")]
            public Loai? Loai { get; set; }

            public ICollection<DonHangChiTiet>? DonHangChiTiets { get; set; }
            public HangHoaData()
            {
                DonHangChiTiets = new HashSet<DonHangChiTiet>();
            }
    }
    
}
