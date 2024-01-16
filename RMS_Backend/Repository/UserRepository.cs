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

        public ICollection<Publication> GetUserPublications(string userPersonnelNumber)
        {
            return _context.Publications.Where(p => p.User.PersonnelNumber.Equals(userPersonnelNumber)).Include(p => p.PublicationScopus).Include(p => p.PublicationWebOfScience).ToList();
        }

        public bool UserExist(string userPersonellNumber)
        {
            return _context.Users.Any(u => u.PersonnelNumber == userPersonellNumber);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePassword(User user)
        {
            _context.Update(user);
            return Save();
        }

    }
}
