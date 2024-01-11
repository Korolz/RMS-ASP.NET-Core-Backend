using System.ComponentModel.DataAnnotations;

namespace RMS_Backend.Models
{
    public class PublicationScopus
    {
        //Enter Scopus Fields
        public string DOI { get; set; }
        public Publication Publication { get; set; }
    }
}
