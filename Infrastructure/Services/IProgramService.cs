using application.Abstractions;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Services
{
    public interface IProgramService
    {
        Task<string> AddProgram(ProgramDTO program);
        Task<ReturnProgramDTO> GetProgram(string id);
    }

    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;

        public ProgramService(IProgramRepository programRepository, IMapper mapper)
        {
            _programRepository = programRepository;
            _mapper = mapper;
        }


        public async Task<string> AddProgram(ProgramDTO program)
        {
            var newProgram = _mapper.Map<Program>(program);

            newProgram.RequiredSkills = string.Join(',',program.RequiredSkills);

            newProgram.ProgramBenefits = string.Join(',', program.ProgramBenefits);

            await _programRepository.AddAsync(newProgram);

            return newProgram.id.ToString();
        }

        public async Task<ReturnProgramDTO> GetProgram(string id)
        {
            var program = await _programRepository.GetAsync(id);

            var returnProgram = _mapper.Map<ReturnProgramDTO>(program);

            returnProgram.RequiredSkills = program.RequiredSkills.Split(",").ToList();

            returnProgram.ProgramBenefits = program.ProgramBenefits.Split(",").ToList();

            return returnProgram;
        }
    }
}
