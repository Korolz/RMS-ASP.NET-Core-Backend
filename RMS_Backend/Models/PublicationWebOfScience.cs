namespace RMS_Backend.Models
{
    public class PublicationWebOfScience
    {
        public string DOINumber { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Pages { get; set; }

        /*
         * TODO: add one-to-many ICollection of authors(users) (what if we have author that is not a user?)
         */

    }
}
