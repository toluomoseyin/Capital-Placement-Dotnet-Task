using Domain.Enum;

namespace Domain.DTOs
{
    public class StageDTO
    {
        public StageType StageType { get; set; }
        public string StageName { get; set; }
        public bool DoNotShowStage { get; set; }
        public string ProgramId { get; set; }
    }
}
