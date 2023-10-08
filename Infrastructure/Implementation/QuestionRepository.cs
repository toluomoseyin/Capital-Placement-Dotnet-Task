using application.Abstractions;
using Domain.Entities;
using Domain.Enum;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Implementation
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly string? _databaseId;
        private readonly string? _containerId;
        private readonly Container _container;

        public QuestionRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _cosmosClient = cosmosClient;
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            _databaseId = "InternshipMgtDb";// _configuration.GetValue<string>("");
            _containerId = "Question";// _configuration.GetValue<string>("");
            _container = _cosmosClient.GetDatabase(_databaseId).GetContainer(_containerId);
        }


        public async Task AddAsync(Question question)
        {
           await _container.CreateItemAsync(question, new PartitionKey(question.id.ToString()));
        }

        public async Task DeleteAsync(string questionId)
        {
            await _container.DeleteItemAsync<Question>(questionId, new PartitionKey(questionId));
        }

        public async Task<Question> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Question>> GetQuestionByProgramIdAsync(string programId)
        {
            var sqlQuery = $"SELECT * FROM c where c.ProgramId = '{programId}' and c.QuestionHeading = {(int)QuestionHeading.ApplicationQuestion}";
            QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);
            FeedIterator<Question> queryResultSetIterator = _container.GetItemQueryIterator<Question>(queryDefinition);
            List<Question> questions = new List<Question>();
            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Question> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Question question in currentResultSet)
                {
                    questions.Add(question);
                }
            }

            return questions;
        }

        public Task UpdateAsync(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
