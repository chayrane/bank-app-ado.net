using BankApp.Models.Exceptions;
using BankApp.Services.Interface;

namespace BankApp.Views
{
    public class BankStaff
    {
        private readonly IBankService _bankService;
        private readonly ITransactionService _transactionService;
        private readonly IValidationService _validationService;

        public BankStaff(IBankService bankService, ITransactionService transactionService, IValidationService validationService)
        {
            _bankService = bankService;
            _transactionService = transactionService;
            _validationService = validationService;
        }

        public void BankStaffRun()
        {
            int count = 0;

            while (count == 0)
            {
                try
                {
                    BankMessages.BankStaffChoiceOptions();
                    int Choice = BankMessages.GetIntInput();
                    BankMessages.DoubleLineSeparator();

                    switch (Choice)
                    {
                        case 1:
                            {
                                // 1. Create New Account in Bank.
                                try
                                {
                                    BankMessages.UserOutput("Enter the Bank Id : ");
                                    string BankId = BankMessages.GetStringInput();
                                    _validationService.ValidateBank(BankId);
                                    BankMessages.UserOutput("Enter New Account Holder Name : ");
                                    string accountHolderName = BankMessages.GetStringInput();
                                    BankMessages.UserOutput("Enter the PIN for new account : ");
                                    int Pin = BankMessages.GetIntInput();

                                    _bankService.AddAccount(accountHolderName, BankId, Pin);
                                }
                                catch (InvalidAccountException ex)
                                {
                                    BankMessages.UserOutput(ex.Exception() + "\n");
                                }
                                catch (Exception ex)
                                {
                                    BankMessages.UserOutput("Exception : " + ex.Message + "\n");
                                }

                                break;
                            }
                        case 2:
                            {
                                // 2. Update Account.
                                try
                                {
                                    BankMessages.UserOutput("Enter the Bank Id : ");
                                    string BankId = BankMessages.GetStringInput();
                                    BankMessages.UserOutput("Enter the Account Number : ");
                                    string AccountId = BankMessages.GetStringInput();
                                    _validationService.ValidateBankAndAccount(BankId, AccountId);

                                    BankMessages.UserOutput("Enter new Account Holder Name : ");
                                    string AccountHolderName = BankMessages.GetStringInput();
                                    BankMessages.UserOutput("Enter new PIN for account : ");
                                    int Pin = BankMessages.GetIntInput();

                                    _bankService.UpdateAccount(BankId, AccountId, AccountHolderName, Pin);
                                }
                                catch (InvalidAccountException ex)
                                {
                                    BankMessages.UserOutput(ex.Exception() + "\n");
                                }
                                catch (Exception ex)
                                {
                                    BankMessages.UserOutput("Exception : " + ex.Message + "\n");
                                }

                                break;
                            }
                        case 3:
                            {
                                // 3. Delete Account.
                                try
                                {
                                    BankMessages.UserOutput("Enter the Bank Id : ");
                                    string BankId = BankMessages.GetStringInput();
                                    BankMessages.UserOutput("Enter the Account Number : ");
                                    string AccountId = BankMessages.GetStringInput();
                                    _validationService.ValidateBankAndAccount(BankId, AccountId);

                                    _bankService.DeleteAccount(BankId, AccountId);
                                }
                                catch (InvalidAccountException ex)
                                {
                                    BankMessages.UserOutput(ex.Exception() + "\n");
                                }
                                catch (Exception ex)
                                {
                                    BankMessages.UserOutput("Exception : " + ex.Message + "\n");
                                }

                                break;
                            }
                        case 4:
                            {
                                // 4. Add New Accepted Currency.
                                try
                                {
                                    BankMessages.UserOutput("Enter the Bank Id : ");
                                    string BankId = BankMessages.GetStringInput();
                                    _validationService.ValidateBank(BankId);

                                    BankMessages.UserOutput("Enter the Accepted Currency : ");
                                    string Currency = BankMessages.GetStringInput();

                                    BankMessages.UserOutput("Enter the Exchange Rate : ");
                                    double ExchangeRate = BankMessages.GetDoubleInput();

                                    _bankService.AddNewAcceptedCurrency(BankId, Currency, ExchangeRate);
                                }
                                catch (InvalidAccountException ex)
                                {
                                    BankMessages.UserOutput(ex.Exception() + "\n");
                                }
                                catch (Exception ex)
                                {
                                    BankMessages.UserOutput("Exception : " + ex.Message + "\n");
                                }

                                break;
                            }
                        case 5:
                            {
                                // 5. Update Service Charge For Same Bank.
                                try
                                {
                                    BankMessages.UserOutput("Enter the Bank Id : ");
                                    string BankId = BankMessages.GetStringInput();
                                    _validationService.ValidateBank(BankId);

                                    BankMessages.UserOutput("Enter the new RTGS charge for same bank : ");
                                    decimal rtgsChargeSameBank = Convert.ToDecimal(Console.ReadLine());
                                    BankMessages.UserOutput("Enter the new IMPS charge for same bank : ");
                                    decimal impsChargeSameBank = Convert.ToDecimal(Console.ReadLine());

                                    _bankService.UpdateServiceChargeForSameBank(BankId, rtgsChargeSameBank, impsChargeSameBank);
                                }
                                catch (InvalidAccountException ex)
                                {
                                    BankMessages.UserOutput(ex.Exception() + "\n");
                                }
                                catch (Exception ex)
                                {
                                    BankMessages.UserOutput("Exception : " + ex.Message + "\n");
                                }

                                break;
                            }
                        case 6:
                            {
                                // 6. Update Service Charge for Other Bank.
                                try
                                {
                                    BankMessages.UserOutput("Enter the Bank Id : ");
                                    string BankId = BankMessages.GetStringInput();
                                    _validationService.ValidateBank(BankId);

                                    BankMessages.UserOutput("Enter the new RTGS charge for other bank : ");
                                    decimal rtgsChargeOtherBank = Convert.ToDecimal(Console.ReadLine());
                                    BankMessages.UserOutput("Enter the new IMPS charge for other bank : ");
                                    decimal impsChargeOtherBank = Convert.ToDecimal(Console.ReadLine());

                                    _bankService.UpdateServiceChargeForOtherBank(BankId, rtgsChargeOtherBank, impsChargeOtherBank);
                                }
                                catch (InvalidAccountException ex)
                                {
                                    BankMessages.UserOutput(ex.Exception() + "\n");
                                }
                                catch (Exception ex)
                                {
                                    BankMessages.UserOutput("Exception : " + ex.Message + "\n");
                                }

                                break;
                            }
                        case 7:
                            {
                                // 7. Show Transactions.
                                try
                                {
                                    BankMessages.UserOutput("Enter Bank Id : ");
                                    string BankId = BankMessages.GetStringInput();
                                    BankMessages.UserOutput("Enter your account number : ");
                                    string AccountId = BankMessages.GetStringInput();
                                    _validationService.ValidateBankAndAccount(BankId, AccountId);

                                    _transactionService.PrintTransaction(BankId, AccountId);
                                }
                                catch (InvalidPinException ex)
                                {
                                    BankMessages.UserOutput(ex.Exception() + "\n");
                                }
                                catch (InvalidAccountException ex)
                                {
                                    BankMessages.UserOutput(ex.Exception() + "\n");
                                }
                                catch (Exception ex)
                                {
                                    BankMessages.UserOutput("Exception : " + ex.Message + "\n");
                                }

                                break;
                            }
                        case 8:
                            {
                                // 8.Logout.
                                BankMessages.UserOutput("Logged out Successfully...!\n");
                                return;
                            }
                        default:
                            {
                                BankMessages.UserOutput("Invalid Choice...!");
                                break;
                            }
                    }

                }
                catch (Exception ex)
                {
                    BankMessages.UserOutput("Exception : " + ex.Message + "\n");
                }
            }
        }
    }
}
