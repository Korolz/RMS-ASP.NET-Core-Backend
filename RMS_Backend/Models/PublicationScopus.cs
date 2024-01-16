using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RMS_Backend.Models
{
    public class PublicationScopus
    {
        //Enter Scopus Fields
        public string DOI { get; set; }
        [JsonIgnore]
        public Publication Publication { get; set; }
    }
}
