namespace RMS_Backend.Dto
{
    public class UserDto
    {
        public string PersonnelNumber { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Status { get; set; }
        public string? Faculty { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
