using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;

namespace _876Access.Models
{
    public class Establishments
    {

        [Key]
        public int Id { get; set; }

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
        public string Parish {  get; set; }

        [Required(ErrorMessage = "The Street Address is required.")]
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Display(Name = "Opening Hours")]
        [BindProperty, DataType(DataType.Time)]
        public DateTime OpenHours { get; set; }

        [Display(Name = "Closing Hours")]
        [BindProperty, DataType(DataType.Time)]
        public DateTime CloseHours { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }


        [DisplayName("Image Name")]
        public string FileName {  get; set; }

        [DisplayName("Rating 0-5")]
        public int Rating { get; set; }


        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }



    }
}
