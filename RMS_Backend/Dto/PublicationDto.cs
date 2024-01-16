using RMS_Backend.Models;

namespace RMS_Backend.Dto
{
    public class PublicationDto
    {
        public string DOI { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int? Vol { get; set; }
        public int? No { get; set; }
        public string? Pages { get; set; }
        public int? AuthorsNo { get; set; }
        public string? Authors { get; set; }
        public string? JournalTitle { get; set; }
        public string? JournalISSN { get; set; }
    }
}
