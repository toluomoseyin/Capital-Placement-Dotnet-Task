using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class QuestionDTO
    {
        public QuestionType QuestionType { get; set; }
        public QuestionSection QuestionSection { get; set; }
        public SubSectionQuestion? SubSectionQuestion { get; set; }
        public QuestionHeading QuestionHeading { get; set; }
        public string ProgramId { get; set; }
        public string? StageId { get; set; }
        public JsonObject QuestionSpecifics { get; set; }
    }
}
