using System.ComponentModel.DataAnnotations;

namespace Kitabim.ViewModels
{
    public class ProfileViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Phone]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        
    }
}
