using EasyNetQ;
using EasyNetQ.Logging;
using Microsoft.Extensions.Configuration;
using RabbitMqTestTask.Common.Options;
using RabbitMqTestTask.MqServer.BusinessLogic.Extensions;
using RabbitMqTestTask.MqServer.BusinessLogic.Services;
using RabbitMqTestTask.MqServer.DataAccess.Repositories;
using Serilog;

namespace RabbitMqTestTask.MqServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(configuration)
                .CreateLogger();

            var rabbitMqOptions = configuration
                .GetSection("RabbitMq")
                .Get<RabbitMqOptions>();

            var databaseOptions = configuration
                .GetSection("Database")
                .Get<DatabaseOptions>();

            var transactionRepository = new TransactionRepository(databaseOptions);

            var transactionService = new TransactionService(transactionRepository);

            var bus = RabbitHutch.CreateBus(rabbitMqOptions.ConnectionString); 

            bus.AddTransactionService(transactionService);
        }
    }
}
