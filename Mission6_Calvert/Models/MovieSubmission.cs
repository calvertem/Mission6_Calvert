using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Calvert.Models
{
    public class MovieSubmission
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage ="Please enter a movie Title")]
        public string Title { get; set; }
        [Required (ErrorMessage = "Please enter a year")]
        [Range(1888, int.MaxValue, ErrorMessage = "The Release Year must be 1888 or greater (no movies existed before 1888.)")]
        public int Year { get; set; }

        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }

        [Required]
        public bool CopiedtoPlex { get; set; }
        [StringLength(25)]
        public string? Notes { get; set; }
    }
}
