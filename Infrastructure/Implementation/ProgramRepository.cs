using application.Abstractions;
using Domain.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Implementation
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly string? _databaseId;
        private readonly string? _containerId;
        private readonly Container _container;

        public ProgramRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            _databaseId = "InternshipMgtDb";// _configuration.GetValue<string>("");
            _containerId = "Program";// _configuration.GetValue<string>("");
            _container = _cosmosClient.GetDatabase(_databaseId).GetContainer(_containerId); ;
        }

        public async Task AddAsync(Program program)
        {
           await _container.CreateItemAsync(program, new PartitionKey(program.id.ToString()));
        }

        public async Task<Program> GetAsync(string id)
        {
           return await _container.ReadItemAsync<Program>(id, new PartitionKey(id));
        }

        public Task UpdateAsync(Program program)
        {
            throw new NotImplementedException();
        }
    }
}
