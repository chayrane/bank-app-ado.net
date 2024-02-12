namespace BankApp.Repository.Interface
{
    public interface IAccountRepository
    {
        public void Deposit(string BankId, string AccountId, decimal Deposit);
        public void Withdraw(string BankId, string AccountId, decimal withdraw);
        //public void Transfer(string SenderBankId, string SenderAccountId, string ReceiverBankId, string ReceiverAccountId, decimal Amount);
        public decimal PrintCurrentBalance(string BankId, string AccountId);
    }
}
