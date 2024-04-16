using Microsoft.AspNetCore.Identity;

namespace Ordex.Locadora.Domain.Logon
{
    public class UsuarioRole : IdentityUserRole<string>
    {
        public virtual Usuario Usuario { get; set; }
        public virtual Role Role { get; set; }
    }
}
