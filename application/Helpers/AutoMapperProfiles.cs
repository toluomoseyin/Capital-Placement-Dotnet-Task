using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace application.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProgramDTO, Program>().ForMember(x => x.RequiredSkills, x => x.Ignore())
                .ForMember(x => x.ProgramBenefits, x => x.Ignore());
            CreateMap<Program, ReturnProgramDTO>().ForMember(x => x.RequiredSkills, x => x.Ignore())
                .ForMember(x => x.ProgramBenefits, x => x.Ignore());
            CreateMap<QuestionDTO, Question>().ForMember(x=>x.QuestionSpecifics,x=>x.Ignore());
            CreateMap<StageDTO, Stage>();
        }
    }
}
