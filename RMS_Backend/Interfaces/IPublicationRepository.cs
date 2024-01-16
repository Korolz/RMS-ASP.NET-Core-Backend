using RMS_Backend.Data;
using RMS_Backend.Models;

namespace RMS_Backend.Interfaces
{
    public interface IPublicationRepository
    {
        bool CreatePublication(string userPersonnelNumber, Publication publication);
        bool Save();
        ICollection<Publication> GetUserPublications(string userPersonnelNumber);
    }
}
