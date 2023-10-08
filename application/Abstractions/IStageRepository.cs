using Domain.Entities;

namespace application.Abstractions
{
    public interface IStageRepository
    {
        Task AddAsync(Stage stage);
       
    }
}
