using BankApp.Models;
using BankApp.Repository.Interface;
using BankApp.Views;
using System.Data.SqlClient;

namespace BankApp.Repository
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly string _connectionString;

        public TransactionsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddTransactionToDB(Transaction transaction)
        {
            string query = "INSERT INTO Transactions VALUES (@TransactionId, @TransactionType, @dateTime, @FromBankId, @FromAccountId, @ToBankId, @ToAccountId, @TransactionAmount, @Balance)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransactionId", transaction.TransactionId);
                    command.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);
                    command.Parameters.AddWithValue("@dateTime", transaction.TransactionDateTime);
                    command.Parameters.AddWithValue("@FromBankId", transaction.FromBankId);
                    command.Parameters.AddWithValue("@FromAccountId", transaction.FromAccountId);
                    command.Parameters.AddWithValue("@ToBankId", transaction.ToBankId);
                    command.Parameters.AddWithValue("@ToAccountId", transaction.ToAccountId);
                    command.Parameters.AddWithValue("@TransactionAmount", transaction.TransactionAmount);
                    command.Parameters.AddWithValue("@Balance", transaction.Balance);

                    int rowsAffected = command.ExecuteNonQuery();
                    BankMessages.UserOutput("Rows affected: " + rowsAffected + "\n");
                }
            }
        }

        public void PrintTransactionFromDB(string bankId, string accountId)
        {
            string query = "SELECT TransactionId, TransactionDateTime, FromAccountId, ToAccountId, TransactionType, TransactionAmount " +
                           "FROM Transactions " +
                           "WHERE FromBankId = @BankId AND FromAccountId = @AccountId OR ToBankId = @BankId AND ToAccountId = @AccountId " +
                           "ORDER BY TransactionDateTime DESC";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BankId", bankId);
                command.Parameters.AddWithValue("@AccountId", accountId);

                try
                {
                    connection.Open();

                    BankMessages.UserOutput("---------------------------------------------------------------------------------------------------------------------------------------\n");
                    BankMessages.UserOutput("         TransactionId              |         Date               Time       |     From      |      To       | Description |  TXN Amount\n");
                    BankMessages.UserOutput("---------------------------------------------------------------------------------------------------------------------------------------\n");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string transactionId = reader["TransactionId"].ToString()!;
                            DateTime transactionDateTime = (DateTime)reader["TransactionDateTime"];
                            string fromAccountId = reader["FromAccountId"].ToString()!;
                            string toAccountId = reader["ToAccountId"].ToString()!;
                            string transactionType = reader["TransactionType"].ToString()!;
                            decimal txnAmt = (decimal)reader["TransactionAmount"];
                            
                            BankMessages.UserOutput($"{transactionId}\t{transactionDateTime}\t{fromAccountId}\t{toAccountId}   \t{transactionType}   \t{txnAmt}\n");
                        }
                    }

                    BankMessages.UserOutput("---------------------------------------------------------------------------------------------------------------------------------------\n");
                    BankMessages.UserOutput("Thank you...!\n");
                }
                catch (Exception ex)
                {
                    // Handle exceptions, log errors, etc.
                    BankMessages.UserOutput("An error occurred while fetching transaction data: " + ex.Message);
                }
            }
        }
    }
}
