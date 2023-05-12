
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Logic.ViewModels
{
    public class ContactViewModels
    {
        [Required]
        public string? Name { get; set; }
        [EmailAddress, Required]
        public string? Email { get; set; }
        [Required]
        public string? Subject { get; set; }
        [Required]
        public string? Message { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
    }
}
