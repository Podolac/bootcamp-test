using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using bootcamp.Models;

namespace bootcamp.Controllers
{
    [Route("api/employers")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly SampleDbContext _context;
        public EmployerController(SampleDbContext context)
        {
            _context = context;
        }

        // GET: api/employers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employer>>> GetEmployers()
        {
            return await _context.Employers.ToListAsync();
        }

        // GET: api/employers/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Employer>> GetEmployer(int id)
        {
            var employer = await _context.Employers.FindAsync(id);

            if (employer == null)
            {
                return NotFound();
            }

            return employer;
        }

        // GET: api/employers/1/applicants
        [HttpGet("{id}/applicants")]
        public async Task<ActionResult<IEnumerable<Applicant>>> GetApplicantsForEmployer(int id)
        {
            var employer = await _context.Employers.FindAsync(id);
            if (employer == null)
            {
                return NotFound("Employer not found.");
            }

            var jobListingIds = await _context.JobListings
                .Where(j => j.EmployerId == id)
                .Select(j => j.Id)
                .ToListAsync();
            if (!jobListingIds.Any())
            {
                return NotFound("No job listings found for the specified employer.");
            }
            var applicants = await _context.Applicants
                .Where(a => jobListingIds.Contains(a.JobListingId))
                .ToListAsync();
            return applicants;
        }

        // POST: api/employers
        [HttpPost]
        public async Task<ActionResult<Employer>> PostEmployer(Employer employer)
        {
            _context.Employers.Add(employer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployer), new { id = employer.Id }, employer);
        }

        // PUT: api/employers/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployer(int id, Employer employer)
        {
            if (id != employer.Id)
            {
                return BadRequest();
            }

            _context.Entry(employer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/employers/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Employer>>> DeleteEmployer(int id)
        {
            var employer = await _context.Employers.FindAsync(id);
            if (employer == null)
            {
                return NotFound();
            }

            _context.Employers.Remove(employer);
            await _context.SaveChangesAsync();

            return await _context.Employers.ToListAsync();
        }

        private bool EmployerExists(int id)
        {
            return _context.Employers.Any(e => e.Id == id);
        }
    }
}