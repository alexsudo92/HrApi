using HrApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class VacanciesController : ControllerBase
    {
        private readonly HrContext _context;

        public VacanciesController(HrContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get(int count, int offset)
        {
            var vacancies = await _context.Vacancies
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(count)
                .ToListAsync();

            return Ok(vacancies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id, bool includeCandidateIds)
        {
            var vacancy = _context.Vacancies
                .Where(v => v.Id.ToString() == id)
                .Select(v => new
                {
                    v.Id,
                    v.Name,
                    v.StartSalary,
                    v.EndSalary,
                    v.Description,
                    v.Education,
                    v.Experience,
                    v.Employment,
                    v.WorkHours,
                    v.Location,
                    v.Branch,
                    v.Tags,
                    v.PostDate,
                    v.EndDate,
                    v.Status,
                    v.Requirements,
                    v.Tasks,
                    v.Features,

                    CandidateIds = includeCandidateIds ? v.Candidates.Select(c => c.Id).ToList() : null
                })
                .FirstOrDefault();

            if (vacancy == null)
            {
                return NotFound();
            }

            return Ok(vacancy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacancy(Guid id, Vacancy vacancy)
        {
            if (id != vacancy.Id)
            {
                return BadRequest();
            }

            _context.Entry(vacancy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacancyExists(id))
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
        public async Task<ActionResult<Vacancy>> PostVacancy(Vacancy vacancy)
        {
            _context.Vacancies.Add(vacancy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacancy", new { id = vacancy.Id }, vacancy);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacancy(Guid id)
        {
            var vacancy = await _context.Vacancies.FindAsync(id);
            if (vacancy == null)
            {
                return NotFound();
            }

            _context.Vacancies.Remove(vacancy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacancyExists(Guid id)
        {
            return _context.Vacancies.Any(e => e.Id == id);
        }
    }
}
