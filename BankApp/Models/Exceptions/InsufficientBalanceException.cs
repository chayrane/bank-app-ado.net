
namespace BankApp.Models.Exceptions
{
    public class InsufficientBalanceException : Exception
    {
        public string Exception()
        {
            return "Insufficient balance...!";
        }
    }
}
