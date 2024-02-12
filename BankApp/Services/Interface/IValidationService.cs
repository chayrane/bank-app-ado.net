using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services.Interface
{
    public interface IValidationService
    {
        public bool ValidateBank(string BankId);
        public void CheckDuplicateBankName(string BankName);
        public bool ValidateBankAndAccount(string BankId, string AccountId);
        public bool ValidatePin(string BankId, string AccountId, int Pin);
        public bool ValidateWithdrawBalance(string BankId, string AccountId, decimal WithdrawBalance);

    }
}
