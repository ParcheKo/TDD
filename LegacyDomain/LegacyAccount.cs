using System;

namespace LegacyDomain
{
    public class LegacyAccount
    {
        private LegacyAccountOwnerValidator accountOwnerValidator;
        private int accountCode { get; set; }

        public LegacyAccount(Guid OwnerId, decimal balance)
        {
            Id = Guid.NewGuid();
            this.accountOwnerValidator = new LegacyAccountOwnerValidator();
            SetOwnerId(OwnerId);
            SetBalance(balance);
        }

        public void SetOwnerId(Guid ownerId)
        {
            if (!accountOwnerValidator.IsAccountOwnerValid(ownerId))
                throw new LegacyOwnerIsNotValidException();
            OwnerId = ownerId;
        }

        public void SetBalance(decimal balance)
        {
            if (balance < 0)
                throw new LegacyAccountWithBalanceException();
            Balance = balance;
        }

        public Guid Id { get; private set; }

        public decimal Balance { get; private set; }

        public Guid OwnerId { get; private set; }

        public LegacyAccountStatus Status { get; private set; }

    }
}
