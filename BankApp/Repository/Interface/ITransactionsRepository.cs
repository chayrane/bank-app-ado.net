using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository.Interface
{
    public interface ITransactionsRepository
    {
        public void AddTransactionToDB(Transaction transaction);
        public void PrintTransactionFromDB(string bankId, string accountId);
    }
}
