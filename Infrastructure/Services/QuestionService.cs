using application.Abstractions;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Services
{
    public interface IQuestionService
    {
        Task AddQuestionAsync(QuestionDTO question);
        Task<List<Question>> GetQuestionByProgramIdAsync(string programId);
        Task DeleteAsync(string questionId);
    }
    public class QuestionService:IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task AddQuestionAsync(QuestionDTO question)
        {
            var newQuestion = _mapper.Map<Question>(question);

            newQuestion.QuestionSpecifics= question.QuestionSpecifics.ToJsonString();
           await _questionRepository.AddAsync(newQuestion);
        }

        public async Task DeleteAsync(string questionId)
        {
            await _questionRepository.DeleteAsync(questionId);
        }

        public async Task<Question> GetAsync(string id)
        {
           return await _questionRepository.GetAsync(id);
        }

        public async Task<List<Question>> GetQuestionByProgramIdAsync(string programId)
        {
            var questions = await _questionRepository.GetQuestionByProgramIdAsync(programId);

            return questions;
            
        }

        public Task UpdateAsync(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
