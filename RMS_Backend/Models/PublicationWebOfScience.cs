using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RMS_Backend.Models
{
    public class PublicationWebOfScience
    {
        public string DOI { get; set; }
        public string WOSNumber { get; set; }
        public bool HasAbroadAuthor { get; set; }
        public bool IsAbroadAuthorTop400 { get; set; }
        public string? Top400UniversityName { get; set; }
        [JsonIgnore]
        public Publication Publication { get; set; }
    }
}
