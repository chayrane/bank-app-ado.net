
namespace BankApp.Models.Exceptions
{
    public class InvalidPinException : Exception
    {
        public string Exception()
        {
            return "Invalid Pin...!";
        }
    }

    //public class InvalidPinException : BaseException
    //{
    //    public InvalidPinException() : base("Invalid Pin.")
    //    {
                
    //    }
    //}

    //public class BaseException : Exception
    //{
    //    public BaseException(string message) :base(message)
    //    {
                
    //    }
    //}
}
