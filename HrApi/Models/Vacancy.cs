using HrApi.Models.Enums;

namespace HrApi.Models
{
    public class Vacancy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double StartSalary { get; set; }
        public double EndSalary { get; set; }
        public string Description { get; set; }
        public string Education { get; set; }
        public int Experience { get; set; }
        public EmploymentType Employment { get; set; }
        public int WorkHours { get; set; }
        public string Location { get; set; }
        public string Branch { get; set; }
        public List<string> Tags { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime EndDate { get; set; }
        public VacancyStatus Status { get; set; }
        public List<string> Requirements { get; set; }
        public List<string> Tasks { get; set; }
        public List<string> Features { get; set; }

        public List<Candidate> Candidates { get; set; }
    }
}
