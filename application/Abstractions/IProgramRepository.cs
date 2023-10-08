using Domain.Entities;

namespace application.Abstractions
{
    public interface IProgramRepository
    {
        Task AddAsync(Program program);
        Task UpdateAsync(Program program);

        Task<Program> GetAsync(string id);
    }
}
