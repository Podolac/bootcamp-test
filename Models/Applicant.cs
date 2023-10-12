using System.ComponentModel.DataAnnotations;
namespace bootcamp.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [MaxLength(100)]
        public string? AddressLine2 { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string? State { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        public int JobListingId { get; set; }
        public JobListing? JobListing { get; set; }

    }
}