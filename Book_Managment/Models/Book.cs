using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Book_Managment.API.Models
{
    [Table("tbl_Books")]
    public class Book : BaseModel
    {
        public long Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }
        public string PageNumbers { get; set; }
        public string JournalTitle { get; set; }
        public int IssueNo { get; set; }
        public int VolumeNo { get; set; }
        public string UrlOrDoi { get; set; }

        [JsonIgnore]
        // Property for MLA style citation
        public string MLACitation
        {
            get
            {
               return $"{AuthorLastName}, {AuthorFirstName}. \"{Title}\", {JournalTitle}, {Publisher}, {PublicationYear}, pp. {PageNumbers}.";
            }
        }

        [JsonIgnore]
        // Property for Chicago style citation
        public string ChicagoCitation
        {
            get
            {
                var citation = $"{AuthorLastName}, {AuthorFirstName}. \"{Title}.\" {JournalTitle} {VolumeNo}, no. {IssueNo} ({PublicationYear}): {PageNumbers}.";
                if (!string.IsNullOrEmpty(UrlOrDoi))
                {
                    citation += $" {UrlOrDoi}.";
                }
                return citation;
            }
        }
    }


    public class TempBooks
    {
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }
        public string PageNumbers { get; set; }
        public string JournalTitle { get; set; }
        public int IssueNo { get; set; }
        public int VolumeNo { get; set; }
        public string UrlOrDoi { get; set; }
    }
}
