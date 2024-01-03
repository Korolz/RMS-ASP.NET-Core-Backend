using System.ComponentModel.DataAnnotations;

namespace RMS_Backend.Models
{
    public class PublicationWebOfScience
    {
        public int ID { get; set; }

        public string WOSNumber { get; set; }
        public bool HasAbroadAuthor { get; set; }
        public bool IsAbroadAuthorTop400 { get; set; }
        public string? Top400UniversityName { get; set; }

        public string DOI { get; set; }
        public Publication Publication { get; set; }
    }
}
