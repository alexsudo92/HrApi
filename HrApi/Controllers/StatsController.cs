using HrApi.Models;
using HrApi.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class StatsController : ControllerBase
    {
        private readonly HrContext _context;
        public StatsController(HrContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            var vacancyStats = _context.Vacancies
                .GroupBy(v => v.Status)
                .ToDictionary(g => g.Key, g => g.Count());

            var candidateStats = _context.Candidates
                .GroupBy(c => c.Status)
                .ToDictionary(g => g.Key, g => g.Count());

            var types = await _context.Vacancies
                .Select(v => v.Employment)
                .Concat(_context.Candidates.Select(c => c.Employment))
                .ToListAsync();

            var employmentTypes = types.Where(et => Enum.IsDefined(et))
                                       .GroupBy(et => et)
                                       .ToDictionary(g => g.Key, g => g.Count());

            var avgVacancySalary = Enum.GetValues<EmploymentType>()
                .ToDictionary(
                    et => et,
                    et =>
                    {
                        var avg = _context.Vacancies.Where(v => v.Employment == et)
                                                    .Average(v => (v.StartSalary + v.EndSalary) / 2);

                        return Math.Round(avg, 1);
                    }
                );

            var avgCandidateSalary = Enum.GetValues<EmploymentType>()
                .ToDictionary(
                    et => et,
                    et =>
                    {
                        var avg = _context.Candidates.Where(c => c.Employment == et)
                                                     .Average(c => c.Salary);

                        return Math.Round(avg, 1);
                    }
                );

            return Ok(new Stats
            {
                TotalVacancies = _context.Vacancies.Count(),
                TotalCandidates = _context.Candidates.Count(),
                VacancyStatusCounts = vacancyStats,
                CandidateStatusCounts = candidateStats,
                EmploymentTypeCounts = employmentTypes,
                AvgVacancySalary = avgVacancySalary,
                AvgCandidateSalary = avgCandidateSalary,
            });
        }
    }
}
