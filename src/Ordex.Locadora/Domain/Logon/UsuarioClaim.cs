using Microsoft.AspNetCore.Identity;

namespace Ordex.Locadora.Domain.Logon
{
    public class UsuarioClaim : IdentityUserClaim<string>
    {
        public virtual Usuario Usuario { get; set; }
    }
}
