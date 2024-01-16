using Microsoft.EntityFrameworkCore;
using RMS_Backend.Data;
using RMS_Backend.Interfaces;
using RMS_Backend.Models;

namespace RMS_Backend.Repository
{
    public class PublicationRepository : IPublicationRepository
    {
        private readonly RMSDbContext _context;
        public PublicationRepository(RMSDbContext context)
        {
            _context = context;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Publication> GetUserPublications(string userPersonellNumber)
        {
            return _context.Publications.Where(p => p.User.PersonnelNumber.Equals(userPersonellNumber)).Include(p => p.PublicationScopus).Include(p => p.PublicationWebOfScience).ToList();
        }

        public bool CreatePublication(string userPersonnelNumber, Publication publication)
        {
            //var userEntity = _context.Users.Where(u => u.PersonnelNumber == userPersonnelNumber).FirstOrDefault();

            _context.Add(publication);

            return Save();
        }
    }
}
