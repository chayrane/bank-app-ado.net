using BankApp.Models.Exceptions;
using BankApp.Repository;
using BankApp.Services;
using BankApp.Services.Interface;

namespace BankApp.Views
{
    public class BankAccountHolder
    {
        private readonly IAccountService _accountService;
        private readonly IValidationService _validationService;
        private readonly ITransactionService _transactionService;

        public BankAccountHolder
        (
            IAccountService accountService,
            IValidationService validationService,
            ITransactionService transactionService
        )
        {
            _accountService = accountService;
            _validationService = validationService;
            _transactionService = transactionService;
        }

        public void BankAccountHolderRun()
        {
            int count = 0;

            while (count == 0)
            {
                try
                {
                    BankMessages.BankAccountHolderChoiceOptions();
                    int Choice = BankMessages.GetIntInput();
                    BankMessages.DoubleLineSeparator();

                    switch (Choice)
                    {
                        case 1:
                            {
                                // 1. Deposit in Bank Account.
                                try
                                {
                                    BankMessages.UserOutput("Enter your Bank Id : ");
                                    string BankId = BankMessages.GetStringInput();
                                    BankMessages.UserOutput("Enter your account number : ");
                                    string AccountId = BankMessages.GetStringInput();
                                    _validationService.ValidateBankAndAccount(BankId, AccountId);
                                    BankMessages.UserOutput("Enter your PIN : ");
                                    int Pin = BankMessages.GetIntInput();
                                    _validationService.ValidatePin(BankId, AccountId, Pin);

                                    BankMessages.UserOutput("Enter the amount you want to Deposit : ");
                                    decimal Deposit = BankMessages.GetDecimalInput();

                                    _accountService.Deposit(BankId, AccountId, Deposit);
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
                        case 2:
                            {
                                // 2. Withdraw from Bank Account.
                                try
                                {
                                    BankMessages.UserOutput("Enter your Bank Id : ");
                                    string BankId = BankMessages.GetStringInput();
                                    BankMessages.UserOutput("Enter your account number : ");
                                    string AccountId = BankMessages.GetStringInput();
                                    _validationService.ValidateBankAndAccount(BankId, AccountId);
                                    BankMessages.UserOutput("Enter your PIN : ");
                                    int Pin = BankMessages.GetIntInput();
                                    _validationService.ValidatePin(BankId, AccountId, Pin);

                                    BankMessages.UserOutput("Enter the amount you want to Withdraw : ");
                                    decimal WithdrawAmount = BankMessages.GetDecimalInput();
                                    _validationService.ValidateWithdrawBalance(BankId, AccountId, WithdrawAmount);

                                    _accountService.Withdraw(BankId, AccountId, WithdrawAmount);
                                }
                                catch (InsufficientBalanceException ex)
                                {
                                    BankMessages.UserOutput(ex.Exception() + "\n");
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
                        case 3:
                            {
                                // 3. Transfer Amount from one account to another.
                                try
                                {
                                    BankMessages.UserOutput("Enter your Bank Id : ");
                                    string senderBankId = BankMessages.GetStringInput();
                                    BankMessages.UserOutput("Enter your account number : ");
                                    string senderAccountId = BankMessages.GetStringInput();
                                    _validationService.ValidateBankAndAccount(senderBankId, senderAccountId);
                                    BankMessages.UserOutput("Enter your PIN : ");
                                    int senderPin = BankMessages.GetIntInput();
                                    _validationService.ValidatePin(senderBankId, senderAccountId, senderPin);

                                    BankMessages.UserOutput("Enter the amount you want to send : ");
                                    decimal Amount = BankMessages.GetDecimalInput();
                                    _validationService.ValidateWithdrawBalance(senderBankId, senderAccountId, Amount);

                                    BankMessages.UserOutput("Enter Receiver Bank Id : ");
                                    string ReceiverBankId = BankMessages.GetStringInput();
                                    BankMessages.UserOutput("Enter Receiver Account Number : ");
                                    string ReceiverAccountId = BankMessages.GetStringInput();
                                    _validationService.ValidateBankAndAccount(ReceiverBankId, ReceiverAccountId);

                                    _accountService.Transfer(senderBankId, senderAccountId, ReceiverBankId, ReceiverAccountId, Amount);
                                }
                                catch (InsufficientBalanceException ex)
                                {
                                    BankMessages.UserOutput(ex.Exception() + "\n");
                                }
                                catch (InvalidPinException ex)
                                {
                                    //BankMessages.UserOutput(ex.Message + "\n");
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
                        case 4:
                            {
                                // 4. Display Transactions.
                                try
                                {
                                    BankMessages.UserOutput("Enter Bank Id : ");
                                    string BankId = BankMessages.GetStringInput();
                                    BankMessages.UserOutput("Enter your account number : ");
                                    string AccountId = BankMessages.GetStringInput();
                                    _validationService.ValidateBankAndAccount(BankId, AccountId);
                                    BankMessages.UserOutput("Enter your PIN : ");
                                    int Pin = BankMessages.GetIntInput();
                                    _validationService.ValidatePin(BankId, AccountId, Pin);

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
                        case 5:
                            {
                                // 5.Logout
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
