using System.ComponentModel.DataAnnotations;


namespace _876Access.ViewModels
{
    public class EstablishmentViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Telephone Number")]
        [Required(ErrorMessage = "Telephone # Required.")]
        // [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string TeleNum { get; set; }




        [Display(Name = " Cellphone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string CellNum { get; set; }

        [Required(ErrorMessage = "Email Required.")]
        [EmailAddress]
        [Display(Name = "Email", Prompt = "example@example.org")]
        public string Email { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [Required(ErrorMessage = "Parish is required.")]
        [Display(Name = "Parish")]
        public string Parish { get; set; }

        [Required(ErrorMessage = "The Street Address is required.")]
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Display(Name = "Opening Hours")]
        public string OpenHours { get; set; }

        [Display(Name = "Closing Hours")]
        public string CloseHours { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public IFormFile Photo { get; set; }
    }
}
