using Microsoft.AspNetCore.Identity;

namespace Ordex.Locadora.Domain.Logon
{
    public class UsuarioToken : IdentityUserToken<string>
    {
        public virtual Usuario Usuario { get; set; }
    }
}
