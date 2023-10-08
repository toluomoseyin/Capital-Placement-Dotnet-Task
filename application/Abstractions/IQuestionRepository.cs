using Domain.Entities;

namespace application.Abstractions
{
    public interface IQuestionRepository
    {
        Task AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(string questionId);
        Task<Question> GetAsync(string id);
        Task<List<Question>> GetQuestionByProgramIdAsync(string programId);
    }
}
