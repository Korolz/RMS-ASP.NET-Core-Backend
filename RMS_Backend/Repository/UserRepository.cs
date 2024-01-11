using Microsoft.EntityFrameworkCore;
using RMS_Backend.Data;
using RMS_Backend.Interfaces;
using RMS_Backend.Models;

namespace RMS_Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RMSDbContext _context;

        public UserRepository(RMSDbContext context)
        {
            _context = context;
        }

        public User GetUser(string userPersonellNumber)
        {
            return _context.Users.Where(u => u.PersonnelNumber == userPersonellNumber).FirstOrDefault();
        }

        public ICollection<Publication> GetUserPublications(string userPersonellNumber)
        {
            return _context.Publications.Where(p => p.User.PersonnelNumber.Equals(userPersonellNumber)).ToList();
        }

        public bool UserExist(string userPersonellNumber)
        {
            return _context.Users.Any(u => u.PersonnelNumber == userPersonellNumber);
        }
    }
}
