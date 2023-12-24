using System.ComponentModel.DataAnnotations;

namespace RMS_Backend.Models
{
    public class PublicationWebOfScience
    {
        [Required]
        [Key]
        public string DOI { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
        public int? Pages { get; set; }
        public int? AuthorsNo { get; set; }
        public string? Authors { get; set; }

        [Required]
        public string PersonnelNumber { get; set; }
        public User User { get; set; }
    }
}
