using Microsoft.AspNetCore.Identity;

namespace Ordex.Locadora.Domain.Logon
{
    public class Role:IdentityRole
    {
        public string Descricao { get; set; }
        public virtual ICollection<UsuarioRole> UsuarioRole { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
