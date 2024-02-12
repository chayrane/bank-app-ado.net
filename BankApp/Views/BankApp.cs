using BankApp.Models.Exceptions;
using BankApp.Repository;
using BankApp.Services;
using BankApp.Services.Interface;

namespace BankApp.Views
{
    public class BankApp
    {
        private readonly IBankService _bankService;
        private readonly IValidationService _validationService;
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;

        public BankApp
        (
            IBankService bankService,
            IAccountService accountService,
            ITransactionService transactionService,
            IValidationService validationService
        )
        {
            _bankService = bankService;
            _accountService = accountService;
            _transactionService = transactionService;
            _validationService = validationService;
        }

        public void BankAppRun()
        {
            BankMessages.WelcomeMessage();

            int Count = 0;

            while (Count == 0)
            {
                try
                {
                    BankMessages.ChoiceOptions();
                    int Choice = BankMessages.GetIntInput();

                    switch (Choice)
                    {
                        case 1:
                            {
                                // 1. Setup New Bank.
                                try
                                {
                                    BankMessages.UserOutput("Enter New Bank Name : ");
                                    string BankName = BankMessages.GetStringInput();
                                    _validationService.CheckDuplicateBankName(BankName);

                                    BankMessages.UserOutput("Enter IFSC Code : ");
                                    string IfscCode = BankMessages.GetStringInput();

                                    _bankService.AddBank(BankName, IfscCode);
                                }
                                catch (DuplicateBankNameException ex)
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
                                // 2. Bank Staff Login.
                                var bankStaff = new BankStaff(_bankService, _transactionService, _validationService);
                                bankStaff.BankStaffRun();
                                break;
                            }
                        case 3:
                            {
                                // 3. Bank Account Holder Login.
                                var bankAccountHolder = new BankAccountHolder(_accountService, _validationService, _transactionService);
                                bankAccountHolder.BankAccountHolderRun();
                                break;
                            }
                        case 4:
                            {
                                // 4. Exit from Console.
                                BankMessages.ExitMessage();
                                Count = 1;
                                break;
                            }
                        default:
                            {
                                BankMessages.UserOutput("Invalid Choice...!\n");
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    BankMessages.UserOutput("Invalid Choice.\nException : " + ex.Message);
                    BankMessages.UserOutput("\n");
                }
            }
        }
    }
}
