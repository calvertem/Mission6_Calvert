using System.ComponentModel.DataAnnotations;

namespace Mission6_Calvert.Models
{
    public class MovieSubmission
    {
        [Key]
        public int MovieSubmissionID {  get; set; }
        public string category {  get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string director { get; set; }
        public RatingEnum Rating { get; set; }
        public bool edited { get; set; }
        public string lent_to { get; set; }
        public string notes { get; set; }

    }

    public enum RatingEnum
    {
        G,
        PG,
        PG13,
        R
    }

}