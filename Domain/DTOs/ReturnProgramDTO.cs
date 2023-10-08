using Domain.Enum;

namespace Domain.DTOs
{
    public class ReturnProgramDTO
    {
        public Guid id { get; set; }
        public string ProgramTitle { get; set; }
        public string ProgramSummary { get; set; }

        public string ProgramDescription { get; set; }
        public List<string> RequiredSkills { get; set; }
        public List<string> ProgramBenefits { get; set; }
        public string ApplicationCriteria { get; set; }

        public ProgramType ProgramType { get; set; }
        public DateTime ProgramStartDate { get; set; }
        public DateTime ApplicationOpenDate { get; set; }
        public DateTime ApplicationCloseDate { get; set; }
        public int Duration { get; set; }
        public string ProgramLocation { get; set; }
        public MinimumQualification MinimumQualification { get; set; }

        public int MaxNumberOfApplication { get; set; }
    }
}
