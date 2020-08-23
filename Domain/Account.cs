using System;

namespace Domain
{
    public class Account
    {
        private IAccountOwnerValidator accountOwnerValidator;
        private int accountCode { get; set; }

        public Account(Guid OwnerId, decimal balance, IAccountOwnerValidator accountOwnerValidator)
        {
            Id = Guid.NewGuid();
            this.accountOwnerValidator = accountOwnerValidator;
            SetOwnerId(OwnerId);
            SetBalance(balance);
        }

        public void SetOwnerId(Guid ownerId)
        {
            if (!accountOwnerValidator.IsAccountOwnerValid(ownerId))
                throw new OwnerIsNotValidException();
            OwnerId = ownerId;
        }

        public void SetBalance(decimal balance)
        {
            if (balance < 0)
                throw new AccountWithBalanceException();
            Balance = balance;
        }

        public Guid Id { get; private set; }

        public decimal Balance { get; private set; }

        public Guid OwnerId { get; private set; }

        public AccountStatus Status { get; private set; }

    }
}
