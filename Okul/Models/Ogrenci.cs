using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Okul.Models
{
    public class Ogrenci
    {

        [Key]
        public int OgrenciID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "ÖĞRENCİ ADI - SOYADI")]
        public string? OgrenciName { get; set; }

        [MaxLength(11)]
        [Display(Name = "TC KİMLİK NUMARASI")]
        public string? OgrenciTcNo { get; set; }

        [Display(Name = "DOĞUM TARİHİ")]
        public DateTime? OgrenciDogumTarih { get; set; }

        [Display(Name = "SINIFI")]
        public string? OgrenciSinif { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }

    }
}
