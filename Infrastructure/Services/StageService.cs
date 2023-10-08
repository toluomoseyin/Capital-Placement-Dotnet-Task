using application.Abstractions;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Implementation;

namespace Infrastructure.Services
{
    public interface IStageService
    {
        Task<string> AddAsync(StageDTO stage);

        Task UpdateAsync(StageDTO stage);

        Task<Stage> GetAsync(string id);

        Task<List<Stage>> GetByProgramIdAsync(string programId);

    }
    public class StageService : IStageService
    {
        private readonly IStageRepository _stageRepository;
        private readonly IMapper _mapper;

        public StageService(IStageRepository stageRepository, IMapper mapper)
        {
            _stageRepository = stageRepository;
            _mapper = mapper;
        }


        public async Task<string> AddAsync(StageDTO stage)
        {
            var newStage = _mapper.Map<Stage>(stage);

            await _stageRepository.AddAsync(newStage);

            return newStage.id.ToString();
        }

        public Task<Stage> GetAsync(string id)
        {
            return _stageRepository.GetAsync(id);
        }

        public Task<List<Stage>> GetByProgramIdAsync(string programId)
        {
            return _stageRepository.GetByProgramIdAsync(programId);
        }

        public Task UpdateAsync(StageDTO stage)
        {
            throw new NotImplementedException();
        }
    }
}
