using BankApp.Repository.Interface;
using System.Data.SqlClient;

namespace BankApp.Repository
{
    public class ValidationsRepository : IValidationsRepository
    {
        private readonly string _connectionString;

        public ValidationsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool DoesBankExist(string bankId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 1 FROM Bank WHERE BankId = @BankId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BankId", bankId);

                    object result = command.ExecuteScalar();

                    // If the bank exists, return true; otherwise, return false.
                    return result != null;
                }
            }
        }

        public string GetBankName(string bankName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT BankName FROM Bank WHERE BankName = @BankName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BankName", bankName);

                    object result = command.ExecuteScalar();

                    // If the bank exists, return its BankId; otherwise, return null.
                    return result != null ? result.ToString() : null;
                }
            }
        }


        public bool DoesAccountExist(string BankId, string AccountId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 1 FROM Account WHERE BankId = @BankId AND AccountId = @AccountId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BankId", BankId);
                    command.Parameters.AddWithValue("@AccountId", AccountId);

                    object result = command.ExecuteScalar();

                    // If the bank exists, return true; otherwise, return false.
                    return result != null;
                }
            }
        }

        public string GetAccountPin(string AccountId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT Pin FROM Account WHERE AccountId = @AccountId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountId", AccountId);

                    object result = command.ExecuteScalar();

                    // If the bank exists, return its BankId; otherwise, return null.
                    return result != null ? result.ToString() : null;
                }
            }
        }

        public decimal GetAccountBalance(string AccountId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT Balance FROM Account WHERE AccountId = @AccountId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountId", AccountId);

                    object result = command.ExecuteScalar();

                    // If the bank exists, return its BankId; otherwise, return null.
                    return result != null && decimal.TryParse(result.ToString(), out decimal balance) ? balance : 0.0m;
                }
            }
        }
    }
}