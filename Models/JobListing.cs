using System.ComponentModel.DataAnnotations;
namespace bootcamp.Models
{
    public class JobListing
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public ICollection<Applicant> Applicants { get; set; } = new List<Applicant>();

        // Foreign key property representing the associated employer
        public int EmployerId { get; set; }
        public Employer? Employer { get; set; }

    }
}