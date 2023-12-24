using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS_Backend.Models
{
    public class User
    {
        [Required]
        [Key]
        public string PersonnelNumber { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Faculty { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public List<PublicationScopus>? PublicationsScopus { get; set; }
        public List<PublicationWebOfScience>? PublicationsWebOfScience { get; set; }
    }
}
