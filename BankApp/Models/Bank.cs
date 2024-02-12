
namespace BankApp.Models
{
    public class Bank
    {
        public string BankId { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string IfscCode { get; set; } = string.Empty;
        public List<Account>? AccountsList { get; set; }
        public List<AcceptedCurrency>? AcceptedCurrencies { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal DefaultRtgsChargeSameBank { get; set; }
        public decimal DefaultImpsChargeSameBank { get; set; }
        public decimal DefaultRtgsChargeOtherBank { get; set; }
        public decimal DefaultImpsChargeOtherBank { get; set; }

    }
}
