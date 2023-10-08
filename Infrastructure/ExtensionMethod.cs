using application.Abstractions;
using Infrastructure.Implementation;
using Infrastructure.Services;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ExtensionMethod
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var cosmosDbEndpoint = configuration.GetConnectionString("CosmosDbEndpoint");
            var cosmosDbKey = configuration.GetConnectionString("CosmosDbKey");

            var cosmosClient = new CosmosClient(cosmosDbEndpoint, cosmosDbKey);
            services.AddSingleton(cosmosClient);

          
            services.AddScoped<IProgramService, ProgramService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IStageRepository, StageRepository>();
            services.AddScoped<IProgramService, ProgramService>();
            services.AddScoped<IStageRepository, StageRepository>();
            services.AddScoped<IProgramRepository, ProgramRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();

        }
    }
}
