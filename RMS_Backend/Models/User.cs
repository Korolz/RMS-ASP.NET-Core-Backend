using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace RMS_Backend.Models
{
    public class User
    {
        public string PersonnelNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Status { get; set; }
        public string? Faculty { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<Publication>? Publications { get; set; }
    }
}
