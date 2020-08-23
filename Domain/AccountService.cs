using System;

namespace Domain
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountOwnerValidator _accountOwnerValidator;
        public AccountService(IAccountRepository accountRepository, IAccountOwnerValidator accountOwnerValidator)
        {
            _accountRepository = accountRepository;
            _accountOwnerValidator = accountOwnerValidator;
        }

        public Account CreateAccount(Guid ownerId, decimal balance)
        {
            var account = new Account(ownerId, balance, _accountOwnerValidator);
            _accountRepository.Add(account);
            return account;
        }

        public void DepositToccount(decimal amount, Guid accountId)
        {
            var account = _accountRepository.Get(accountId);
            //TODO
            _accountRepository.Update(account);
        }

        public void Withdraw(decimal amount, Guid accountId)
        {
            var account = _accountRepository.Get(accountId);
            //TODO
            _accountRepository.Update(account);
        }

    }
}
