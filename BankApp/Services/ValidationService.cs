using BankApp.Models;
using BankApp.Models.Exceptions;
using BankApp.Repository.Interface;
using BankApp.Services.Interface;

namespace BankApp.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IValidationsRepository _validate;

        public ValidationService(IValidationsRepository validate)
        {
            this._validate = validate;
        }

        // Validate Bank if present or not using Id.
        public bool ValidateBank(string BankId)
        {
            if (_validate.DoesBankExist(BankId))
                return true;
            else
                throw new InvalidAccountException();
        }

        // Check if same Bank name is present.
        public void CheckDuplicateBankName(string BankName)
        {
            string existingBankName = _validate.GetBankName(BankName);
            
            if (existingBankName == BankName)
                throw new DuplicateBankNameException();
        }

        // Validate both Bank and Account using Id.
        public bool ValidateBankAndAccount(string BankId, string AccountId)
        {
            ValidateBank(BankId);

            if (_validate.DoesAccountExist(BankId, AccountId))
                return true;
            else
                throw new InvalidAccountException();
        }

        // Validating Pin.
        public bool ValidatePin(string BankId, string AccountId, int Pin)
        {
            string returnedPin = _validate.GetAccountPin(AccountId);

            if (returnedPin == Pin.ToString())
                return true;
            else
                throw new InvalidPinException();
        }

        // Check withdraw balance.
        public bool ValidateWithdrawBalance(string BankId, string AccountId, decimal WithdrawBalance)
        {
            decimal AccountBalance = _validate.GetAccountBalance(AccountId);
            return WithdrawBalance <= AccountBalance ? true : throw new InsufficientBalanceException();
        }
    }
}
