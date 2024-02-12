
namespace BankApp.Models
{
    public class Transaction
    {
        public string TransactionId { get; set; } = string.Empty;
        public TransactionTypes TransactionType { get; set; }
        public string? TransactionDateTime { get; set; }
        public string? FromBankId { get; set; }
        public string FromAccountId { get; set; } = string.Empty;
        public string? ToBankId { get; set; }
        public string ToAccountId { get; set; } = string.Empty;
        public decimal TransactionAmount { get; set; }
        public decimal Balance { get; set; }
    }
}
