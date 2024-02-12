using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services.Interface
{
    public interface ITransactionService
    {
        public void AddTransaction(string fromAccountId, string toAccountId, string fromBankId, string toBankId, TransactionTypes transactionType, string dateTime, decimal Amount);
        public void PrintTransaction(string bankId, string accountId);
    }
}
