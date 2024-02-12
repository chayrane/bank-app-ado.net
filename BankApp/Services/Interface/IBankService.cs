using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services.Interface
{
    public interface IBankService
    {
        public void AddBank(string BankName, string IfscCode);
        public void AddAccount(string name, string BankId, int Pin);
        public void UpdateAccount(string BankId, string AccountId, string UpdateAccountHolderName, int UpdatePin);
        public void DeleteAccount(string BankId, string AccountId);
        public void AddNewAcceptedCurrency(string BankId, string Currency, double ExchangeRate);
        public void UpdateServiceChargeForSameBank(string BankId, decimal RtgsChargeSameBank, decimal ImpsChargeSameBank);
        public void UpdateServiceChargeForOtherBank(string BankId, decimal RtgsChargeOtherBank, decimal ImpsChargeOtherBank);
    }
}
