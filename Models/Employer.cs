using System.ComponentModel.DataAnnotations;
namespace bootcamp.Models
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public ICollection<JobListing> JobListings { get; set; } = new List<JobListing>();

    }
}
