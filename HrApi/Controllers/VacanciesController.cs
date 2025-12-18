using HrApi.Models;
using HrApi.Models.Enums;
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
                .Where(x => x.Id.ToString() == id)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.StartSalary,
                    x.EndSalary,
                    x.Description,
                    x.Education,
                    x.Experience,
                    x.Employment,
                    x.WorkHours,
                    x.Location,
                    x.Branch,
                    x.Tags,
                    x.PostDate,
                    x.EndDate,
                    x.Status,
                    x.Requirements,
                    x.Tasks,
                    x.Features,

                    CandidateIds = includeCandidateIds ? x.Candidates.Select(x => x.Id).ToList() : null
                })
                .FirstOrDefault();

            if (vacancy == null)
            {
                return NotFound();
            }

            return Ok(vacancy);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(Vacancy vacancy)
        {
            var vac = await _context.Vacancies.FirstOrDefaultAsync(x => x.Id == vacancy.Id);
            if (vac is not null)
            {
                _context.Vacancies.Remove(vac);
            }

            _context.Vacancies.Add(vacancy);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Vacancy created" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var vacancy = await _context.Vacancies.FirstOrDefaultAsync(x => x.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            _context.Vacancies.Remove(vacancy);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Vacancy deleted" });
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "BranchHead, Admin")]
        public async Task<IActionResult> SetStatus(Guid id, VacancyStatus status)
        {
            var vacancy = await _context.Vacancies.FirstOrDefaultAsync(x => x.Id == id);
            if (vacancy is null)
            {
                return NotFound();
            }

            vacancy.Status = status;

            _context.Vacancies.Update(vacancy);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Status updated" });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AddCandidate(Guid vacancyId, Guid candidateId)
        {
            var vacancy = await _context.Vacancies.FirstOrDefaultAsync(x => x.Id == vacancyId);
            var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == candidateId);
            if (candidate is null || vacancy is null)
            {
                return NotFound();
            }

            vacancy.Candidates?.Add(candidate);

            _context.Vacancies.Update(vacancy);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Candidate added" });
        }
    }
}
