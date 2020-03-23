using Dapper;
using RabbitMqTestTask.Common.Options;
using RabbitMqTestTask.MqServer.DataAccess.Entities;
using RabbitMqTestTask.MqServer.DataAccess.Parameters.Transaction;
using RabbitMqTestTask.MqServer.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace RabbitMqTestTask.MqServer.DataAccess.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private DatabaseOptions _databaseOptions { get; set; }

        public TransactionRepository(DatabaseOptions databaseOptions)
        {
            _databaseOptions = databaseOptions;
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_databaseOptions.ConnectionString);
        }

        public int Add(TransactionAddParameters transactionAddParameters)
        {
            using var sqlConnection = CreateConnection();

            return sqlConnection.QueryFirstOrDefault<int>("Transaction_Add", transactionAddParameters, commandType: CommandType.StoredProcedure);
        }

        public Transaction GetById(TransactionGetByIdParameters transactionGetByIdParameters)
        {
            using var sqlConnection = CreateConnection();

            return sqlConnection.QueryFirstOrDefault<Transaction>("Transaction_GetById", transactionGetByIdParameters, commandType: CommandType.StoredProcedure);
        }

        public List<Transaction> GetAllByClient(TransactionGetAllByClientParameters transactionGetAllByClientParameters)
        {
            using var sqlConnection = CreateConnection();

            return sqlConnection.Query<Transaction>("Transaction_GetAllByClient", transactionGetAllByClientParameters, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
