using Domain;
using System;

namespace LegacyDomain
{
    public class LegacyAccountService
    {
        private readonly ILegacyAccountRepository _accountRepository;
        private readonly ILegacyAccountOwnerValidator _accountOwnerValidator;
        public LegacyAccountService(ILegacyAccountRepository accountRepository, ILegacyAccountOwnerValidator accountOwnerValidator)
        {
            _accountRepository = accountRepository;
            _accountOwnerValidator = accountOwnerValidator;
        }

        public LegacyAccount CreateAccount(Guid ownerId, decimal balance)
        {
            var account = new LegacyAccount(ownerId, balance);
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
