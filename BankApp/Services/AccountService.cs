using BankApp.Models;
using BankApp.Repository;
using BankApp.Repository.Interface;
using BankApp.Services.Interface;
using BankApp.Views;

namespace BankApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionsRepository _transactionRepository;

        public AccountService(ITransactionService transactionService, IAccountRepository accountRepository, ITransactionsRepository transactionRepository)
        {
            _transactionService = transactionService;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public void Deposit(string BankId, string AccountId, decimal Deposit)
        {
            _accountRepository.Deposit(BankId, AccountId, Deposit);
            BankMessages.UserOutput("Amount Deposited Successfully...!\n");

            PrintCurrentBalance(BankId, AccountId);

            TransactionTypes txnType = TransactionTypes.Credit;
            _transactionService.AddTransaction(AccountId, AccountId, BankId, BankId, txnType, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), Deposit);
        }

        public void Withdraw(string BankId, string AccountId, decimal Withdraw)
        {
            _accountRepository.Withdraw(BankId, AccountId, Withdraw);
            BankMessages.UserOutput("Amount Withdrawn Successfully...!\n");
            PrintCurrentBalance(BankId, AccountId);

            TransactionTypes txnType = TransactionTypes.Debit;
            _transactionService.AddTransaction(AccountId, AccountId, BankId, BankId, txnType, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), Withdraw);

        }

        public void Transfer(string SenderBankId, string SenderAccountId, string ReceiverBankId, string ReceiverAccountId, decimal Amount)
        {
            _accountRepository.Withdraw(SenderBankId, SenderAccountId, Amount);
            _accountRepository.Deposit(ReceiverBankId, ReceiverAccountId, Amount);

            TransactionTypes senderTxnType = TransactionTypes.Debit;
            TransactionTypes receiverTxnType = TransactionTypes.Credit;
            _transactionService.AddTransaction(SenderAccountId, ReceiverAccountId, SenderBankId, ReceiverBankId, senderTxnType, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), Amount);
            _transactionService.AddTransaction(ReceiverAccountId, SenderAccountId, ReceiverBankId, SenderBankId, receiverTxnType, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), Amount);
            BankMessages.UserOutput("Amount Transferred Successfully...!\n");
        }

        public void PrintCurrentBalance(string BankId, string AccountId)
        {
            decimal Balance = _accountRepository.PrintCurrentBalance(BankId, AccountId);
            BankMessages.UserOutput("Your Current Balance is : " + Balance + "\n");
        }
    }
}
