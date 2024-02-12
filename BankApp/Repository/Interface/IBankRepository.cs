using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository.Interface
{
    public interface IBankRepository
    {
        public void AddBankToDB(Bank bank);
        public void AddAccountToDB(Account account);
        public void AddNewAcceptedCurrencyToDB(AcceptedCurrency currency);
        public void UpdateAccountInDB(string BankId, string AccountId, string UpdateAccountHolderName, int UpdatePin);
        public void DeleteAccountInDB(string BankId, string AccountId);
        public void UpdateServiceChargeForSameBank(string BankId, decimal RtgsChargeSameBank, decimal ImpsChargeSameBank);
        public void UpdateServiceChargeForOtherBank(string BankId, decimal RtgsChargeOtherBank, decimal ImpsChargeOtherBank);
    }
}
