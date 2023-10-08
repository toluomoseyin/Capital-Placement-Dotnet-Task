using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace application.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProgramDTO, Program>();
            CreateMap<QuestionDTO, Question>().ForMember(x=>x.QuestionSpecifics,x=>x.Ignore());
        }
    }
}
