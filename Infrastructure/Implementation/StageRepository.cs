using application.Abstractions;
using Domain.Entities;
using Domain.Enum;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Implementation
{
    public class StageRepository : IStageRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly string? _databaseId;
        private readonly string? _containerId;
        private readonly Container _container;

        public StageRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _cosmosClient = cosmosClient;
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            _databaseId = "InternshipMgtDb";// _configuration.GetValue<string>("");
            _containerId = "Stage";// _configuration.GetValue<string>("");
            _container = _cosmosClient.GetDatabase(_databaseId).GetContainer(_containerId);
        }
        public async Task AddAsync(Stage stage)
        {
            await _container.CreateItemAsync(stage, new PartitionKey(stage.id.ToString()));
        }

        public async Task<Stage> GetAsync(string id)
        {
            return await _container.ReadItemAsync<Stage>(id, new PartitionKey(id));
        }

        public async Task<List<Stage>> GetByProgramIdAsync(string programId)
        {
            var sqlQuery = $"SELECT * FROM c where c.ProgramId = '{programId}'";

            QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);

            FeedIterator<Stage> queryResultSetIterator = _container.GetItemQueryIterator<Stage>(queryDefinition);
            List<Stage> stages = new List<Stage>();
            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Stage> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Stage stage in currentResultSet)
                {
                    stages.Add(stage);
                }
            }

            return stages;
        }

        public Task UpdateAsync(Stage stage)
        {
            throw new NotImplementedException();
        }

    
    }
}
