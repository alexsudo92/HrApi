using HrApi.Models.Enums;

namespace HrApi.Models
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public double Salary { get; set; }
        public CandidateStatus Status { get; set; }
        public List<string> Skills { get; set; }
        public string Education { get; set; }
        public int Experience { get; set; }
        public EmploymentType Employment { get; set; }
        public int WorkHours { get; set; }
        public DateTime RespondDate { get; set; }


        public List<Workplace> Workplaces { get; set; }
        public List<Interaction> Interactions { get; set; }
        public List<Vacancy> Vacancies { get; set; }
    }
}
