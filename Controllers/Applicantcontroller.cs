using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using bootcamp.Models;

namespace bootcamp.Controllers
{
    [Route("api/applicants")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly SampleDbContext _context;
        public ApplicantController(SampleDbContext context)
        {
            _context = context;
        }

        // GET: api/applicants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applicant>>> GetApplicants()
        {
            return await _context.Applicants.ToListAsync();
        }

        // GET: api/applicants/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Applicant>> GetApplicant(int id)
        {
            var applicant = await _context.Applicants.FindAsync(id);

            if (applicant == null)
            {
                return NotFound();
            }

            return applicant;
        }

        // POST: api/applicants
        [HttpPost]
        public async Task<ActionResult<Applicant>> PostApplicant([FromBody] Applicant applicant)
        {
            string[] propertiesToCheck = new[]
            {
                applicant.FirstName,
                applicant.LastName,
                applicant.PhoneNumber,
                applicant.Email,
                applicant.AddressLine1,
                applicant.Country,
                applicant.City,
            };

            var jobListing = await _context.JobListings.FindAsync(applicant.JobListingId);
            if (jobListing == null)
            {
                return BadRequest("Invalid JobListingId.");
            }

            foreach (var property in propertiesToCheck)
            {
                if (string.IsNullOrEmpty(property))
                {
                    return BadRequest($"{property} can't be null");
                }
            }
            var a = new Applicant
            {
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                PhoneNumber = applicant.PhoneNumber,
                Email = applicant.Email,
                AddressLine1 = applicant.AddressLine1,
                AddressLine2 = applicant.AddressLine2,
                Country = applicant.Country,
                State = applicant.State,
                City = applicant.City,
                JobListingId = applicant.JobListingId
            };

            _context.Applicants.Add(a);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetApplicant), new { id = a.Id }, a);
        }

        // PUT: api/applicants/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicant(int id, Applicant applicant)
        {
            var a = await _context.Applicants.FindAsync(id);
            if (a == null)
            {
                return NotFound();
            }
            var jobListing = await _context.JobListings.FindAsync(a.JobListingId);
            if (jobListing == null)
            {
                return BadRequest("Invalid jobListingId.");
            }

            a.FirstName = applicant.FirstName;
            a.LastName = applicant.LastName;
            a.PhoneNumber = applicant.PhoneNumber;
            a.Email = applicant.Email;
            a.AddressLine1 = applicant.AddressLine1;
            a.AddressLine2 = applicant.AddressLine2;
            a.Country = applicant.Country;
            a.State = applicant.State;
            a.City = applicant.City;
            a.JobListingId = applicant.JobListingId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/applicants/1
        [HttpDelete("/{id}")]
        public async Task<ActionResult<IEnumerable<Applicant>>> DeleteApplicant(int id)
        {
            var applicant = await _context.Applicants.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }

            _context.Applicants.Remove(applicant);
            await _context.SaveChangesAsync();

            return await _context.Applicants.ToListAsync();
        }

        private bool ApplicantExists(int id)
        {
            return _context.Applicants.Any(e => e.Id == id);
        }
    }
}