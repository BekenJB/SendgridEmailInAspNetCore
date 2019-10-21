using System.ComponentModel.DataAnnotations;

namespace SendgridEmailInAspNetCore.Models
{
    public class EmailModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
