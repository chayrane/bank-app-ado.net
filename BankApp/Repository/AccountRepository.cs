using BankApp.Repository.Interface;
using BankApp.Views;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BankApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string _connectionString;

        public AccountRepository(string connectionString) => _connectionString = connectionString;

        private void ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);

            int rowsAffected = command.ExecuteNonQuery();
            BankMessages.UserOutput($"Rows affected: { rowsAffected }\n");
        }

        public void Deposit(string BankId, string AccountId, decimal Deposit)
        {
            string query = "UPDATE Account SET Balance += @Deposit WHERE BankId = @BankId AND AccountId = @AccountId";
            ExecuteNonQuery(query, new SqlParameter("@BankId", BankId), new SqlParameter("@AccountId", AccountId), new SqlParameter("@Deposit", Deposit));
        }

        public void Withdraw(string BankId, string AccountId, decimal Withdraw)
        {
            string query = "UPDATE Account SET Balance -= @Withdraw WHERE BankId = @BankId AND AccountId = @AccountId";
            ExecuteNonQuery(query, new SqlParameter("@BankId", BankId), new SqlParameter("@AccountId", AccountId), new SqlParameter("@Withdraw", Withdraw));
        }

        public decimal PrintCurrentBalance(string BankId, string AccountId)
        {
            string query = "SELECT Balance FROM Account WHERE BankId = @BankId AND AccountId = @AccountId";
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BankId", BankId);
            command.Parameters.AddWithValue("@AccountId", AccountId);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                decimal balance = reader.GetDecimal(0);
                return balance;
            }
            throw new InvalidOperationException("Account not found!");
        }
    }
}
