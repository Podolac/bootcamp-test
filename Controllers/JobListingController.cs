using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using bootcamp.Models;

namespace bootcamp.Controllers
{
    [Route("api/joblistings")]
    [ApiController]
    public class JobListingController : ControllerBase
    {
        private readonly SampleDbContext _context;
        public JobListingController(SampleDbContext context)
        {
            _context = context;
        }

        // GET: api/joblistings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobListing>>> GetJobListings()
        {
            return await _context.JobListings.ToListAsync();
        }

        // GET: api/joblistings/1
        [HttpGet("{id}")]
        public async Task<ActionResult<JobListing>> GetJobListing(int id)
        {
            var jobListing = await _context.JobListings.FindAsync(id);

            if (jobListing == null)
            {
                return NotFound();
            }

            return jobListing;
        }

        // POST: api/joblistings
        [HttpPost]
        public async Task<ActionResult<JobListing>> PostJobListing([FromBody] JobListing jobListing)
        {
            var employer = await _context.Employers.FindAsync(jobListing.EmployerId);
            if (employer == null)
            {
                return BadRequest("Invalid EmployerId.");
            }
            var jL = new JobListing
            {
                Name = jobListing.Name,
                Description = jobListing.Description,
                EmployerId = jobListing.EmployerId
            };
            _context.JobListings.Add(jL);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJobListing), new { id = jL.Id }, jL);
        }

        // PUT: api/joblistings/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobListing(int id, [FromBody]JobListing jobListing)
        {
            var jL = await _context.JobListings.FindAsync(id);
            if (jL == null)
            {
                return NotFound();
            }
            var employer = await _context.Employers.FindAsync(jL.EmployerId);
            if (employer == null)
            {
                return BadRequest("Invalid EmployerId.");
            }

            jL.Name = jobListing.Name;
            jL.Description = jobListing.Description;
            jL.EmployerId = jobListing.EmployerId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/joblistings/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<JobListing>>> DeleteJobListing(int id)
        {
            var jobListing = await _context.JobListings.FindAsync(id);
            if (jobListing == null)
            {
                return NotFound();
            }

            _context.JobListings.Remove(jobListing);
            await _context.SaveChangesAsync();

            return await _context.JobListings.ToListAsync();
        }
    }
}