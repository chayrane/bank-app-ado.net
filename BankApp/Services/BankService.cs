using BankApp.Models;
using BankApp.Repository.Interface;
using BankApp.Services.Interface;
using BankApp.Views;

namespace BankApp.Services
{
    public class BankService : IBankService
    {
        private IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public void AddBank(string BankName, string IfscCode)
        {
            string bankId = GenerateIdService.GenerateBankId(BankName);

            Bank bank = new Bank
            {
                BankId = bankId,
                BankName = BankName,
                IfscCode = IfscCode,
                CreatedOn = DateTime.Now,
                DefaultRtgsChargeSameBank = 0,
                DefaultImpsChargeSameBank = 5,
                DefaultRtgsChargeOtherBank = 2,
                DefaultImpsChargeOtherBank = 6,
            };

            _bankRepository.AddBankToDB(bank);
            AddNewAcceptedCurrency(bank.BankId, "INR", 0.012);
            BankMessages.UserOutput($"Bank with bankId { bank.BankId } is created..!\n");
        }

        public void AddAccount(string name, string BankId, int Pin)
        {
            Account account = new Account
            {
                AccountHolderName = name,
                AccountId = GenerateIdService.GenerateAccountId(name),
                Pin = Pin,
                BankId = BankId,
                Balance = 0,
            };

            _bankRepository.AddAccountToDB(account);
            BankMessages.UserOutput($"New account for { account.AccountHolderName } with Account Id { account.AccountId } is created successfully..!\n");
        }

        public void UpdateAccount(string BankId, string AccountId, string UpdateAccountHolderName, int UpdatePin)
        {
            _bankRepository.UpdateAccountInDB(BankId, AccountId, UpdateAccountHolderName, UpdatePin);
        }

        public void DeleteAccount(string BankId, string AccountId)
        {
            _bankRepository.DeleteAccountInDB(BankId, AccountId);
        }

        public void AddNewAcceptedCurrency(string BankId, string Currency, double ExchangeRate)
        {
            AcceptedCurrency acceptedCurrency = new AcceptedCurrency()
            {
                BankId = BankId,
                Currency = Currency,
                ExchangeRate = ExchangeRate,
            };

            _bankRepository.AddNewAcceptedCurrencyToDB(acceptedCurrency);
        }

        public void UpdateServiceChargeForSameBank(string BankId, decimal RtgsChargeSameBank, decimal ImpsChargeSameBank)
        {
            _bankRepository.UpdateServiceChargeForSameBank(BankId, RtgsChargeSameBank, ImpsChargeSameBank);
            BankMessages.UserOutput("Service charges updated successfully...!\n");
        }
        public void UpdateServiceChargeForOtherBank(string BankId, decimal RtgsChargeOtherBank, decimal ImpsChargeOtherBank)
        {
            _bankRepository.UpdateServiceChargeForOtherBank(BankId, RtgsChargeOtherBank, ImpsChargeOtherBank);
            BankMessages.UserOutput("Service charges updated successfully...!\n");
        }
    }
}
