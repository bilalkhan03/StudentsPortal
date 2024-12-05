using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public Boolean Subscribed { get; set; }
    }
}
