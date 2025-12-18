using HrApi.Models.Enums;

namespace HrApi.Models
{
    public class Stats
    {
        public int TotalVacancies { get; set; }
        public int TotalCandidates { get; set; }

        public Dictionary<VacancyStatus, int> VacancyStatusCounts { get; set; } = [];
        public Dictionary<CandidateStatus, int> CandidateStatusCounts { get; set; } = [];
        public Dictionary<EmploymentType, int> EmploymentTypeCounts { get; set; } = [];

        public Dictionary<EmploymentType, double> AvgVacancySalary { get; set; } = [];
        public Dictionary<EmploymentType, double> AvgCandidateSalary { get; set; } = [];
    }
}
