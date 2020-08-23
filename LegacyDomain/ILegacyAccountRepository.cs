using LegacyDomain;
using System;

namespace Domain
{
    public interface ILegacyAccountRepository
    {
        LegacyAccount Get(Guid Id);
        LegacyAccount Update(LegacyAccount account);
        LegacyAccount Add(LegacyAccount account);
    }
}
