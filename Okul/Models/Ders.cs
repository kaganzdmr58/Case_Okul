using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Okul.Models
{
    public class Ders
    {
        [Key]
        [Display(Name = "DERS")]
        public int DersID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "DERS ADI")]
        public string? DersName { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }

    }
}
