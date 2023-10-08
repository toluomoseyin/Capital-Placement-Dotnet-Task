using Domain.Entities;

namespace application.Abstractions
{
    public interface IStageRepository
    {
        Task AddAsync(Stage stage);

        Task UpdateAsync(Stage stage);

        Task<Stage> GetAsync(string id);

        Task<List<Stage>> GetByProgramIdAsync(string programId);


    }
}
