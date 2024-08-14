using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APINEW.DATA
{
    [Table("Tours")]
    public class ToursEntity
    {
        [Key]
        public int kitapid { get; set; }

        [Required] 
        public string kitapAd { get; set; }

        [Required]
        public string yazar { get; set; }

        [Required]
        public string tur { get; set; }

        [Required]
        public int sayfa { get; set; } 
    }

    [Table("SoldTours")]
    public class SoldToursEntity
    {
        [Key]
        public int id { get; set; }

        public int Userid { get; set; }

        public int? Tourid { get; set; } 

        [ForeignKey("Tourid")]
        public ToursEntity tour { get; set; }
    }
}
