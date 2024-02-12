using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository.Interface
{
    public interface IValidationsRepository
    {
        public string GetBankName(string bankName);
        public bool DoesBankExist(string bankId);
        public bool DoesAccountExist(string BankId, string AccountId);
        public string GetAccountPin(string AccountId);
        public decimal GetAccountBalance(string AccountId);
    }
}
