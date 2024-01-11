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
                        Name = "Roman",
                        Surname = "Korolev",
                        IsAdmin = true
                    },
                    new User()
                    {
                        PersonnelNumber = "P00001",
                        Username = "askat",
                        Password = HashHelper.ComputeSHA256Hash("00001"),
                        Name = "Askat",
                        Surname = "Seitakunov",
                        IsAdmin= true
                    },
                    new User()
                    {
                        PersonnelNumber = "P55555",
                        Username = "ibrahim",
                        Password = HashHelper.ComputeSHA256Hash("55555"),
                        Name = "Ibrahim",
                        Surname = "Adeshola",
                        Publications = new List<Publication>()
                        {
                            new Publication()
                            {
                                DOI = "10.1080/10494820.2023.2253858",
                                Title = "The opportunities and challenges of ChatGPT in education",
                                PublicationDate = new DateTime(2023, 9, 2, 10, 5, 56),
                                Pages = "1-14",
                                AuthorsNo = 2,
                                Authors = "Ibrahim Adeshola, Adeola Praise Adepoju",
                                JournalTitle = "Interactive Learning Environments",
                                PublicationWebOfScience = new PublicationWebOfScience{ DOI = "10.1080/10494820.2023.2253858", WOSNumber = "16"}
                            },
                            new Publication()
                            {
                                DOI = "10.1007/s11356-021-17708-8",
                                Title = "Wavelet analysis of impact of renewable energy consumption and technological innovation on CO2 emissions: evidence from Portugal",
                                PublicationDate = new DateTime(2021, 11, 24, 10, 2, 43),
                                Vol = 29,
                                Pages = "23887-23904",
                                AuthorsNo = 4,
                                Authors = "Tomiwa Sunday Adebayo, Seun Damola Oladipupo, Ibrahim Adeshola, Husam Rjoub",
                                JournalTitle = "Environmental Science and Pollution Research",
                                PublicationScopus = new PublicationScopus{ DOI = "10.1007/s11356-021-17708-8" }
                            }
                        }
                    }
                };

                //var initialPublications = new List<Publication>()
                //{
                //    new Publication()
                //    {
                //        DOI = "10.1080/10494820.2023.2253858",
                //        Title = "The opportunities and challenges of ChatGPT in education",
                //        PublicationDate = new DateTime(2023, 9, 2),
                //        PublicationWebOfScience = new PublicationWebOfScience{ ID = 1, WOSNumber = "4124354543242"}
                //    }
                //};

                dbContext.Users.AddRange(initialUsers);
                //dbContext.Publications.AddRange(initialPublications);

                dbContext.SaveChanges();
            }
        }
    }
}
