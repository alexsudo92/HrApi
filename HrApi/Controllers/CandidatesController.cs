using HrApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CandidatesController : ControllerBase
    {
        private readonly HrContext _context;

        public CandidatesController(HrContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get(int count, int offset)
        {
            var candidates = await _context.Candidates
                .Include(c => c.Workplaces)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(count)
                .ToListAsync();

            return Ok(candidates);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id, bool includeInteractionIds = false, bool includeVacancyIds = false)
        {
            var candidate = _context.Candidates
                    .Where(c => c.Id.ToString() == id)
                    .Include(c => c.Workplaces)
                    .Select(c => new
                    {
                        c.Id,
                        c.Name,
                        c.Mail,
                        c.Education,
                        c.Employment,
                        c.RespondDate,
                        c.Status,
                        c.Salary,
                        c.Phone,
                        c.WorkHours,
                        c.Skills,
                        c.Experience,
                        InteractionIds = includeInteractionIds ? c.Interactions.Select(i => i.Id).ToList() : null,
                        VacancyIds = includeVacancyIds ? c.Vacancies.Select(v => v.Id).ToList() : null
                    })
                    .FirstOrDefault();

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(Guid id, Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Candidate>> PostCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidate", new { id = candidate.Id }, candidate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(Guid id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidateExists(Guid id)
        {
            return _context.Candidates.Any(e => e.Id == id);
        }
    }
}
