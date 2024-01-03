using System.Text;
using RMS_Backend.Data;
using RMS_Backend.Models;
using static RMS_Backend.HashHelper;

namespace RMS_Backend
{
    public class SeedDb
    {
        private readonly RMSDbContext dbContext;
        public SeedDb(RMSDbContext context)
        {
            dbContext = context;
        }
        public void SeedDataContext() //seeding Database with content
        {
            if (!dbContext.Users.Any())
            {
                var initialUsers = new List<User>()
                {
                    new User()
                    {
                        PersonnelNumber = "P12345",
                        Username = "korolz",
                        Password = HashHelper.ComputeSHA256Hash("12345"),
                        IsAdmin = true
                    },
                    new User()
                    {
                        PersonnelNumber = "P00001",
                        Username = "askat",
                        Password = HashHelper.ComputeSHA256Hash("00001"),
                        IsAdmin= true
                    },
                    new User()
                    {
                        PersonnelNumber = "P55555",
                        Username = "ibrahim",
                        Password = HashHelper.ComputeSHA256Hash("55555"),
                    }
                };

                var initialPublications = new List<Publication>()
                {
                    new Publication()
                    {
                        DOI = "10.1080/10494820.2023.2253858",
                        Title = "The opportunities and challenges of ChatGPT in education",
                        PublicationDate = new DateTime(2023, 9, 2),
                        PersonnelNumber = "P55555",
                        PublicationWebOfScience = new PublicationWebOfScience{ DOI = "10.1080/10494820.2023.2253858", ID = 1, WOSNumber = "4124354543242"}
                    }
                };

                dbContext.Users.AddRange(initialUsers);
                dbContext.Publications.AddRange(initialPublications);

                dbContext.SaveChanges();
            }
        }
    }
}
