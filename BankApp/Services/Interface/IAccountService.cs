using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services.Interface
{
    public interface IAccountService
    {
        public void Deposit(string BankId, string AccountId, decimal Deposit);
        public void Withdraw(string BankId, string AccountId, decimal Withdraw);
        public void Transfer(string SenderBankId, string SenderAccountId, string ReceiverBankId, string ReceiverAccountId, decimal Amount);
        public void PrintCurrentBalance(string BankId, string AccountId);
    }
}
