// Id Format -> eg. BankName = QWERTY & Date = 12/07/2023 then Id is QWE20230712.

namespace BankApp.Services
{
    public class GenerateIdService
    {
        public static string GenerateBankId(string BankName)
        {
            return BankName.Substring(0, 3).ToUpper() + DateTime.UtcNow.ToString("yyyyMMdd");
        }

        public static string GenerateAccountId(string AccountHolderName)
        {
            return AccountHolderName.Substring(0, 3).ToUpper() + DateTime.UtcNow.ToString("yyyyMMdd");
        }

        public static string GenerateTransactionId(string BankId, string AccountId)
        {
            return "TXN" + BankId + AccountId + DateTime.UtcNow.ToString("yyyyMMddfff");
        }
    }
}
