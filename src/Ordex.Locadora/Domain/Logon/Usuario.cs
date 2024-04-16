using Microsoft.AspNetCore.Identity;

namespace Ordex.Locadora.Domain.Logon
{
    public class Usuario : IdentityUser
    {
        public virtual ICollection<UsuarioClaim> Claims { get; set; }
        public virtual ICollection<UsuarioLogin> Logins { get; set; }
        public virtual ICollection<UsuarioToken> Tokens { get; set; }
        public virtual ICollection<UsuarioRole> UsuarioRole { get; set; }
    }
}