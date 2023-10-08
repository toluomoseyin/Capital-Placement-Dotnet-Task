using Domain.Enum;

namespace Domain.Entities
{
    public class Stage
    {
        public string Id { get; set; }
        public StageType StageType { get; set; }
        public bool DoNotShowStage { get; set; }
    }
}
