using Microsoft.AspNetCore.Identity;

namespace Ordex.Locadora.Domain.Logon
{
    public class RoleClaim : IdentityRoleClaim<string>
    {
        public virtual Role Role { get; set; }

    }
}
