using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyDomain
{

    public interface ILegacyAccountOwnerValidator
    {
        bool IsAccountOwnerValid(Guid ownerId);
    }
}
