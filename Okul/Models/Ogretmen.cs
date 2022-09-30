using System.ComponentModel.DataAnnotations;

namespace Okul.Models
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "ÖĞRETMEN ADI - SOYADI")]
        public string? OgretmenName { get; set; }
        
        [MaxLength(11, ErrorMessage = "Only 11 caretters entered"), MinLength(10)]
        [Display(Name = "TC KİMLİK NUMARASI")]
        public string? OgretmenTcNo { get; set; }

        [Display(Name = "DOĞUM TARİHİ")]
        public DateTime? OgretmenDogumTarih { get; set; }
        
        [Display(Name = "DERS")]
        public int? DersID { get; set; }
        [Display(Name = "DERS ADI")]
        public Ders? Ders { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }

    }
}
