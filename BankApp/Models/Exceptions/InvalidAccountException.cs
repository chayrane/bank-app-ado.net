
namespace BankApp.Models.Exceptions
{
    public class InvalidAccountException : Exception
    {
        public string Exception()
        {
            return "Invalid account details...!";
        }
    }
}
