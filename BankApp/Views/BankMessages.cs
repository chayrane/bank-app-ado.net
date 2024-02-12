
namespace BankApp.Views
{
    public class BankMessages
    {
        public static void WelcomeMessage()
        {
            DoubleLineSeparator();
            Console.WriteLine("Welcome to Bank Simulation");
        }

        public static void ChoiceOptions()
        {
            DoubleLineSeparator();
            Console.WriteLine("+++++++++++++ Bank Operations +++++++++++++");
            DoubleLineSeparator();
            Console.WriteLine("1. Setup New Bank.\n2. Bank Staff Login.\n3. Bank Account Holder Login.\n4. Exit.");
            DoubleLineSeparator();
            Console.Write("Enter your choice : ");
        }

        public static void BankStaffChoiceOptions()
        {
            DoubleLineSeparator();
            Console.WriteLine("++++++++++ Bank Staff Operations ++++++++++");
            DoubleLineSeparator();
            Console.WriteLine("" +
                "1. Create Account.\n" +
                "2. Update Account Details.\n" +
                "3. Delete Account.\n" +
                "4. Add New Accepted Currency.\n" +
                "5. Update Service Charge For Same Bank.\n" +
                "6. Update Service Charge for Other Bank.\n" +
                "7. Show Transactions.\n" +
                "8. Logout.");
            DoubleLineSeparator();
            Console.Write("Enter your choice : ");
        }

        public static void BankAccountHolderChoiceOptions()
        {
            DoubleLineSeparator();
            Console.WriteLine("+++++++++++++ Bank Operations +++++++++++++");
            DoubleLineSeparator();
            Console.WriteLine("" +
                "1. Deposit Amount.\n" +
                "2. Withdraw Amount.\n" +
                "3. Transfer Amount.\n" +
                "4. Show Transactions.\n" +
                "5. Logout.");
            DoubleLineSeparator();
            Console.Write("Enter your choice : ");
        }

        public static string GetStringInput()
        {
            return Console.ReadLine()!;
        }

        public static int GetIntInput()
        {
            return int.Parse(Console.ReadLine()!);
        }

        public static double GetDoubleInput()
        {
            return double.Parse(Console.ReadLine()!)!;
        }

        public static decimal GetDecimalInput()
        {
            return decimal.Parse(Console.ReadLine()!);
        }

        public static void UserOutput(string s)
        {
            Console.Write(s);
        }

        public static void ExitMessage()
        {
            DoubleLineSeparator();
            Console.WriteLine("\nThank you!!! Visit again...!!");
            DoubleLineSeparator();
        }

        public static void DoubleLineSeparator()
        {
            Console.WriteLine("===========================================");
        }
    }
}
