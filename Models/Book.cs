using System.ComponentModel.DataAnnotations;

namespace Kitabim.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kitap Adı")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Yazar")]
        public string Author { get; set; }

        [Display(Name = "Tür")]
        public string Genre { get; set; }

        [Display(Name = "Yayınevi")]
        public string Publisher { get; set; }

        [Required]
        [Display(Name = "Fiyat")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Resim URL")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Stok")]
        public int Stock { get; set; }
       
    }
}
