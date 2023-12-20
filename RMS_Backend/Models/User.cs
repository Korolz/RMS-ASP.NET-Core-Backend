namespace RMS_Backend.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public int PersonnelNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Status { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        

        /*
         * TODO:
         *  add Publication List properties for database
         *  ask about data relationship in database
        */
    }
}
