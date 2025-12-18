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
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.RespondDate,
                    x.Education,
                    x.Salary,
                    x.Status,
                    x.Skills,
                    x.Employment,
                    x.Mail,
                    x.Phone,
                    x.WorkHours,
                    x.Experience,
                    x.Workplaces,
                    x.Interactions,
                    VacancyIds = x.Vacancies.Select(x => x.Id)
                })
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(count)
                .ToListAsync();

            return Ok(candidates);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var candidate = _context.Candidates
                    .Where(x => x.Id.ToString() == id)
                    .Select(x => new
                    {
                        x.Id,
                        x.Name,
                        x.RespondDate,
                        x.Education,
                        x.Salary,
                        x.Status,
                        x.Skills,
                        x.Employment,
                        x.Mail,
                        x.Phone,
                        x.WorkHours,
                        x.Experience,
                        x.Workplaces,
                        x.Interactions,
                        VacancyIds = x.Vacancies.Select(x => x.Id)
                    })
                    .FirstOrDefault();

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(Candidate candidate)
        {
            var cand = await _context.Candidates
                .Include(x => x.Workplaces)
                .Include(x => x.Interactions)
                .FirstOrDefaultAsync(x => x.Id == candidate.Id);

            if (cand is null)
            {
                _context.Candidates.Add(candidate);
            }
            else
            {
                cand.Name = candidate.Name;
                cand.Phone = candidate.Phone;
                cand.Mail = candidate.Mail;
                cand.Salary = candidate.Salary;
                cand.Status = candidate.Status;
                cand.Skills = candidate.Skills;
                cand.Education = candidate.Education;
                cand.Experience = candidate.Experience;
                cand.Employment = candidate.Employment;
                cand.WorkHours = candidate.WorkHours;
                cand.RespondDate = candidate.RespondDate;
                //cand.Workplaces = candidate.Workplaces;
                //cand.Interactions = candidate.Interactions;
                //cand.Vacancies = candidate.Vacancies;
            }

            _context.Candidates.Update(cand);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Candidate created" });
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Candidate deleted" });
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "BranchHead, Admin")]
        public async Task<IActionResult> SetStatus(Guid id, CandidateStatus status)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == id);
            if (candidate is null)
            {
                return NotFound();
            }

            candidate.Status = status;

            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Status updated" });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddWorkplace(Guid id, Workplace workplace)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == id);
            if (candidate is null)
            {
                return NotFound();
            }

            candidate.Workplaces?.Add(workplace);

            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Workplace added" });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddInteraction(Guid id, Interaction interaction)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == id);
            if (candidate is null)
            {
                return NotFound();
            }

            candidate.Interactions?.Add(interaction);

            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Interaction added" });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AddVacancy(Guid id, Guid vacancyId)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == id);
            var vacancy = await _context.Vacancies.FirstOrDefaultAsync(x => x.Id == vacancyId);
            if (candidate is null || vacancy is null)
            {
                return NotFound();
            }

            candidate.Vacancies?.Add(vacancy);

            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Vacancy added" });
        }
    }
}
