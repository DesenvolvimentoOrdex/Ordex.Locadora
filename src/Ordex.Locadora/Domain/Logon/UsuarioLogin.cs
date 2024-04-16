using Microsoft.AspNetCore.Identity;

namespace Ordex.Locadora.Domain.Logon
{
    public class UsuarioLogin : IdentityUserLogin<string>
    {
        public virtual Usuario Usuario { get; set; }
    }
}
