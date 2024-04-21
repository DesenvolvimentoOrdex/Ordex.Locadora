using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Domain.Alugueis;
using Ordex.Locadora.Domain.Cadastros.Clientes;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;
using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Domain.Vistorias;

namespace Ordex.Locadora.Infraesctuture.Data;

public sealed class LocadoraDbContext(DbContextOptions<LocadoraDbContext> options) : IdentityDbContext<
    Usuario, Role, string,
    UsuarioClaim, UsuarioRole, UsuarioLogin,
    RoleClaim, UsuarioToken>(options)
{
    public DbSet<Aluguel> Alugueis { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Vistoria> Vistorias { get; set; }
    public DbSet<VistoriaImagem> VistoriaImagens { get; set; }
    public DbSet<VistoriaObservacao> VistoriaObservacoes { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<VeiculoImagem> VeiculoImagens { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(b =>
        {
            b.HasKey(k=> k.Id);
            // Each User can have many UserClaims
            b.HasMany(e => e.Claims)
                 .WithOne()
                 .HasForeignKey(uc => uc.UserId)
                 .IsRequired();

            // Each User can have many UserLogins
            b.HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            b.HasMany(e => e.Tokens)
                .WithOne()
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();


            // Each User can have many entries in the UserRole join table
            b.HasMany(e => e.UsuarioRole)
                .WithOne(e => e.Usuario)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });

        modelBuilder.Entity<Role>(b =>
        {
            // Each Role can have many entries in the UserRole join table
            b.HasMany(e => e.UsuarioRole)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            b.HasMany(e => e.RoleClaims)
                .WithOne(e => e.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();
        });

    }
}