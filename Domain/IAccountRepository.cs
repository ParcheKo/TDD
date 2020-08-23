using System;

namespace Domain
{
    public interface IAccountRepository
    {
        Account Get(Guid Id);
        Account Update(Account account);
        Account Add(Account account);
    }
}
