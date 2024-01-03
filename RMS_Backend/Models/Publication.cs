using System.ComponentModel.DataAnnotations;

namespace RMS_Backend.Models
{
    public class Publication
    {
        public string DOI { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int? Vol { get; set; }
        public int? No { get; set; }
        public int? Pages { get; set; }
        public int? AuthorsNo { get; set; }
        public string? Authors { get; set; }

        public string? JournalTitle { get; set; }
        public string? JournalISSN { get; set; }

        public string PersonnelNumber { get; set; }

        public User User { get; set; }

        public PublicationScopus? PublicationScopus { get; set; }
        public PublicationWebOfScience? PublicationWebOfScience { get; set; }
    }
}
