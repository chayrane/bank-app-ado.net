using BankApp.Models;
using BankApp.Repository.Interface;
using BankApp.Services.Interface;

namespace BankApp.Services
{
    internal class TransactionService : ITransactionService
    {
        private IAccountRepository _accountRepository;
        private ITransactionsRepository _transactionRepository;

        public TransactionService(IAccountRepository accountRepository, ITransactionsRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public void AddTransaction(string fromAccountId, string toAccountId, string fromBankId, string toBankId, TransactionTypes transactionType, string dateTime, decimal Amount)
        {
            Transaction transaction = new Transaction
            {
                TransactionId = GenerateIdService.GenerateTransactionId(fromAccountId, fromBankId),
                TransactionDateTime = dateTime,
                Balance = _accountRepository.PrintCurrentBalance(fromBankId, fromAccountId),
                FromBankId = fromBankId,
                FromAccountId = fromAccountId,
                ToBankId = toBankId,
                ToAccountId = toAccountId,
                TransactionType = transactionType,
                TransactionAmount = Amount,
            };

            // Swap the accounts for the credit transaction (used only for Transfer).
            if (transactionType == TransactionTypes.Credit)
            {
                string tempAccountId = transaction.FromAccountId;
                transaction.FromAccountId = transaction.ToAccountId;
                transaction.ToAccountId = tempAccountId;
            }

            _transactionRepository.AddTransactionToDB(transaction);
        }

        public void PrintTransaction(string bankId, string accountId)
        {
            _transactionRepository.PrintTransactionFromDB(bankId, accountId);
        }
    }
}
