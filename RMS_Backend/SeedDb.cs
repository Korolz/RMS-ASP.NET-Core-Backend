using RMS_Backend.Data;
using RMS_Backend.Models;

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
                        Password = "12345", //change when do encryption
                        IsAdmin = true
                    },
                    new User()
                    {
                        PersonnelNumber = "P00001",
                        Username = "askat",
                        Password = "00001", //change when do encryption
                        IsAdmin= true
                    },
                    new User()
                    {
                        PersonnelNumber = "P55555",
                        Username = "ibrahim",
                        Password = "55555", //change when do encryption
                    }
                };

                var initialScopus = new List<PublicationScopus>()
                {
                    new PublicationScopus()
                    {
                        DOI = "10.1080/10494820.2023.2253858",
                        Title = "The opportunities and challenges of ChatGPT in education",
                        PublicationDate = new DateTime(2023, 9, 2),
                        PersonnelNumber = "P55555"
                    }
                };

                dbContext.Users.AddRange(initialUsers);
                dbContext.PublicationsScopus.AddRange(initialScopus);

                dbContext.SaveChanges();
            }
        }
    }
}
