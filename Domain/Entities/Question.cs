using Domain.Enum;
using System.Text.Json.Nodes;

namespace Domain.Entities
{
    public class Question
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public QuestionType QuestionType { get; set; }
        public QuestionSection QuestionSection { get; set; }
        public SubSectionQuestion? SubSectionQuestion { get; set; }
        public QuestionHeading QuestionHeading { get; set; }
        public string ProgramId { get; set; }
        public string? StageId { get; set; }
        public string QuestionSpecifics { get; set; }
    }

    public class MultipleChoice
    {
        public string Question { get; set; }
        public List<string> Choice { get; set; }
        public bool EnableOtherOption { get; set; }
        public int MaxChoiceAllowed { get; set; }
    }

    public class DropDown
    {
        public string Question { get; set; }
        public List<string> Choice { get; set; }
        public bool EnableOtherOption { get; set; }
    }

    public class YesNo
    {
        public string Question { get; set; }
        public bool DisqualifyIfNo { get; set; }
    }
}
