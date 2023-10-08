using application.Abstractions;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Services
{
    public interface IProgramService
    {
        Task<string> AddProgram(ProgramDTO program);
        Task<Program> GetProgram(string id);
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

            await _programRepository.AddAsync(newProgram);

            return newProgram.id.ToString();
        }

        public async Task<Program> GetProgram(string id)
        {
            return await _programRepository.GetAsync(id);
        }
    }
}
