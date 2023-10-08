using Domain.Enum;

namespace Domain.Entities
{
    public class Stage
    {
        public Guid id { get; set; }= Guid.NewGuid();
        public StageType StageType { get; set; }
        public string StageName { get; set; }
        public bool DoNotShowStage { get; set; }
        public string ProgramId { get; set; }
    }
}
