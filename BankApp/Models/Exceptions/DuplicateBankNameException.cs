
namespace BankApp.Models.Exceptions
{
    public class DuplicateBankNameException : Exception
    {
        public string Exception()
        {
            return "Bank name already exist...!";
        }
    }
}
