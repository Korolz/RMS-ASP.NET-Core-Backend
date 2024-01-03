using System.ComponentModel.DataAnnotations;

namespace RMS_Backend.Models
{
    public class PublicationScopus
    {
        //Enter Scopus Fields
        public int ID { get; set; }

        public string DOI { get; set; }
        public Publication Publication { get; set; }
    }
}
