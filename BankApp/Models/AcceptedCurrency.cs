
namespace BankApp.Models
{
    public class AcceptedCurrency
    {
        public string BankId { get; set; } = "";
        public string Currency { get; set; } = string.Empty;
        public double ExchangeRate { get; set; }

    }
}
