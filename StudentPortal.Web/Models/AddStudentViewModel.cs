using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    public class AddStudentViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(150, ErrorMessage = "Email cannot be longer than 150 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 digits.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string Phone { get; set; }

        public bool Subscribed { get; set; }
    }
}
