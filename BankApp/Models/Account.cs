
namespace BankApp.Models
{
    public class Account
    {
        public string AccountId { get; set; } = string.Empty;
        public string AccountHolderName { get; set; } = string.Empty;
        public int Pin { get; set; }
        public string BankId { get; set; } = string.Empty;
        public double Balance { get; set; }
        public List<Transaction>? TransactionList { get; set; }
    }
}
