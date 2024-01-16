using RMS_Backend.Models;

namespace RMS_Backend.Interfaces
{
    public interface IUserRepository
    {
        ICollection<Publication> GetUserPublications(string userPersonnelNumber);
        User GetUser(string userPersonnelNumber);
        bool UserExist(string userPersonnelNumber);
        bool UpdatePassword(User user);
        bool Save();
    }
}
