using BankApp.Models;
using BankApp.Repository.Interface;
using BankApp.Views;
using System.Data.SqlClient;

namespace BankApp.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly string _connectionString;

        public BankRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddBankToDB(Bank bank)
        {
            string query = $"INSERT INTO Bank VALUES (@BankId, @BankName, @IfscCode, @Date, @DefaultRtgsChargeSameBank, @DefaultImpsChargeSameBank, @DefaultRtgsChargeOtherBank, @DefaultImpsChargeOtherBank)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BankId", bank.BankId);
                    command.Parameters.AddWithValue("@BankName", bank.BankName);
                    command.Parameters.AddWithValue("@IfscCode", bank.IfscCode);
                    command.Parameters.AddWithValue("@Date", SqlDateFormat(bank));
                    command.Parameters.AddWithValue("@DefaultRtgsChargeSameBank", bank.DefaultRtgsChargeSameBank);
                    command.Parameters.AddWithValue("@DefaultImpsChargeSameBank", bank.DefaultImpsChargeSameBank);
                    command.Parameters.AddWithValue("@DefaultRtgsChargeOtherBank", bank.DefaultRtgsChargeOtherBank);
                    command.Parameters.AddWithValue("@DefaultImpsChargeOtherBank", bank.DefaultImpsChargeOtherBank);

                    int rowsAffected = command.ExecuteNonQuery();
                    BankMessages.UserOutput("Rows affected: " + rowsAffected + "\n");
                }
            }
        }

        public void AddAccountToDB(Account account)
        {
            string query = "INSERT INTO Account VALUES (@AccountId, @AccountHolderName, @Pin, @BankId, @Balance)";
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountId", account.AccountId);
                    command.Parameters.AddWithValue("@AccountHolderName", account.AccountHolderName);
                    command.Parameters.AddWithValue("@Pin", account.Pin);
                    command.Parameters.AddWithValue("@BankId", account.BankId);
                    command.Parameters.AddWithValue("@Balance", account.Balance);

                    int rowsAffected = command.ExecuteNonQuery();
                    BankMessages.UserOutput("Rows affected: " + rowsAffected + "\n");
                }
            }
        }

        public void AddNewAcceptedCurrencyToDB(AcceptedCurrency currency)
        {
            string query = "INSERT INTO AcceptedCurrency VALUES (@BankId, @Currency, @ExchangeRate)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BankId", currency.BankId);
                    command.Parameters.AddWithValue("@Currency", currency.Currency);
                    command.Parameters.AddWithValue("@ExchangeRate", currency.ExchangeRate);

                    int rowsAffected = command.ExecuteNonQuery();
                    BankMessages.UserOutput("Rows affected: " + rowsAffected + "\n");
                }
            }
        }

        public string SqlDateFormat(Bank bank)
        {
            DateTime currentDate = bank.CreatedOn;
            return currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        public void UpdateAccountInDB(string BankId, string AccountId, string UpdateAccountHolderName, int UpdatePin)
        {
            string query = "UPDATE Account SET AccountHolderName = @UpdateAccountHolderName, Pin = @UpdatePin WHERE BankId = @BankId And AccountId = @AccountId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UpdateAccountHolderName", UpdateAccountHolderName);
                    command.Parameters.AddWithValue("@UpdatePin", UpdatePin);
                    command.Parameters.AddWithValue("@BankId", BankId);
                    command.Parameters.AddWithValue("@AccountId", AccountId);

                    int rowsAffected = command.ExecuteNonQuery();
                    BankMessages.UserOutput("Rows affected: " + rowsAffected + "\n");
                }
            }
        }

        public void DeleteAccountInDB(string BankId, string AccountId)
        {
            string query = "DELETE FROM Account WHERE BankId = @BankId AND AccountId = @AccountId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BankId", BankId);
                    command.Parameters.AddWithValue("@AccountId", AccountId);

                    int rowsAffected = command.ExecuteNonQuery();
                    BankMessages.UserOutput("Rows affected: " + rowsAffected + "\n");
                }
            }
        }

        public void UpdateServiceChargeForSameBank(string BankId, decimal RtgsChargeSameBank, decimal ImpsChargeSameBank)
        {
            string query = "UPDATE Bank SET DefaultRtgsChargeSameBank = @RtgsChargeSameBank, DefaultImpsChargeSameBank = @ImpsChargeSameBank WHERE BankId = @BankId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RtgsChargeSameBank", RtgsChargeSameBank);
                    command.Parameters.AddWithValue("@ImpsChargeSameBank", ImpsChargeSameBank);
                    command.Parameters.AddWithValue("@BankId", BankId);

                    int rowsAffected = command.ExecuteNonQuery();
                    BankMessages.UserOutput("Rows affected: " + rowsAffected + "\n");
                }
            }
        }

        public void UpdateServiceChargeForOtherBank(string BankId, decimal RtgsChargeOtherBank, decimal ImpsChargeOtherBank)
        {
            string query = "UPDATE Bank SET DefaultRtgsChargeSameBank = @RtgsChargeOtherBank, DefaultImpsChargeSameBank = @ImpsChargeOtherBank WHERE BankId = @BankId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RtgsChargeSameBank", RtgsChargeOtherBank);
                    command.Parameters.AddWithValue("@ImpsChargeSameBank", ImpsChargeOtherBank);
                    command.Parameters.AddWithValue("@BankId", BankId);

                    int rowsAffected = command.ExecuteNonQuery();
                    BankMessages.UserOutput("Rows affected: " + rowsAffected + "\n");
                }
            }
        }
    }
}
