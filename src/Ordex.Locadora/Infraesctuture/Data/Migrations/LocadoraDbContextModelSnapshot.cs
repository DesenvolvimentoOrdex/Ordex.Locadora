﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ordex.Locadora.Infraesctuture.Data;

#nullable disable

namespace Ordex.Locadora.Infraesctuture.Data.Migrations
{
    [DbContext(typeof(LocadoraDbContext))]
    partial class LocadoraDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ordex.Locadora.Domain.Alugueis.Aluguel", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("ClienteCodigo")
                        .HasColumnType("int");

                    b.Property<int>("CodigoCliente")
                        .HasColumnType("int");

                    b.Property<int>("CodigoFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("FuncionarioCodigo")
                        .HasColumnType("int");

                    b.Property<int>("PercentualDesconto")
                        .HasColumnType("int");

                    b.Property<string>("PlacaVeiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PossuiDesconto")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<double>("ValorComDesconto")
                        .HasColumnType("float");

                    b.Property<string>("VeiculoPlaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.HasIndex("ClienteCodigo");

                    b.HasIndex("FuncionarioCodigo");

                    b.HasIndex("VeiculoPlaca");

                    b.ToTable("Alugueis");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Cadastros.Clientes.Cliente", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataFiliacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnderecoCodigo")
                        .HasColumnType("int");

                    b.Property<string>("NomeRazao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoPessoa")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.HasIndex("EnderecoCodigo");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Cadastros.Enderecos.Endereco", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logadouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Cadastros.Frotas.Veiculo", b =>
                {
                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Chassi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Renavam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Placa");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Cadastros.Frotas.VeiculoImagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Descricao")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VeiculoPlaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoPlaca");

                    b.ToTable("VeiculoImagens");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Cadastros.Funcionarios.Funcionario", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFiliacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnderecoCodigo")
                        .HasColumnType("int");

                    b.Property<string>("Funcao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeRazao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoPessoa")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.HasIndex("EnderecoCodigo");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.UsuarioClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsuarioId1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.UsuarioLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsuarioId1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.UsuarioRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.UsuarioToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsuarioId1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Vistorias.Vistoria", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("AluguelCodigo")
                        .HasColumnType("int");

                    b.Property<bool>("Amassado")
                        .HasColumnType("bit");

                    b.Property<bool>("Chave")
                        .HasColumnType("bit");

                    b.Property<int>("CodigoAluguel")
                        .HasColumnType("int");

                    b.Property<int>("CodigoFuncionario")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRetirada")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Extintor")
                        .HasColumnType("bit");

                    b.Property<bool>("Farol")
                        .HasColumnType("bit");

                    b.Property<int>("FuncionarioCodigo")
                        .HasColumnType("int");

                    b.Property<bool>("LuzDeFreio")
                        .HasColumnType("bit");

                    b.Property<bool>("MacacoHidraulico")
                        .HasColumnType("bit");

                    b.Property<bool>("PneuDianteiroDireito")
                        .HasColumnType("bit");

                    b.Property<bool>("PneuDianteiroEsquedo")
                        .HasColumnType("bit");

                    b.Property<bool>("PneuStep")
                        .HasColumnType("bit");

                    b.Property<bool>("PneuTraseiroDireito")
                        .HasColumnType("bit");

                    b.Property<bool>("PneuTraseiroEsquedo")
                        .HasColumnType("bit");

                    b.Property<bool>("Quebrado")
                        .HasColumnType("bit");

                    b.Property<bool>("Riscado")
                        .HasColumnType("bit");

                    b.Property<bool>("SetaDianteiraDireita")
                        .HasColumnType("bit");

                    b.Property<bool>("SetaDianteiraEsquerda")
                        .HasColumnType("bit");

                    b.Property<bool>("SetaTraseiraDireita")
                        .HasColumnType("bit");

                    b.Property<bool>("SetaTraseiraEsquerda")
                        .HasColumnType("bit");

                    b.Property<bool>("SinistroEntrega")
                        .HasColumnType("bit");

                    b.Property<double>("TaxaSinistro")
                        .HasColumnType("float");

                    b.Property<bool>("Triangulo")
                        .HasColumnType("bit");

                    b.HasKey("Codigo");

                    b.HasIndex("AluguelCodigo");

                    b.HasIndex("FuncionarioCodigo");

                    b.ToTable("Vistorias");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Vistorias.VistoriaImagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CodigoVistoria")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VistoriaCodigo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VistoriaCodigo");

                    b.ToTable("VistoriaImagens");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Vistorias.VistoriaObservacao", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("AluguelCodigo")
                        .HasColumnType("int");

                    b.Property<int>("CodigoAluguel")
                        .HasColumnType("int");

                    b.Property<int>("CodigoVistoria")
                        .HasColumnType("int");

                    b.Property<int>("CodigoVistoriaImagem")
                        .HasColumnType("int");

                    b.Property<Guid>("ImagensId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VistoriaCodigo")
                        .HasColumnType("int");

                    b.HasKey("Codigo");

                    b.HasIndex("AluguelCodigo");

                    b.HasIndex("ImagensId");

                    b.HasIndex("VistoriaCodigo");

                    b.ToTable("VistoriaObservacoes");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Alugueis.Aluguel", b =>
                {
                    b.HasOne("Ordex.Locadora.Domain.Cadastros.Clientes.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ordex.Locadora.Domain.Cadastros.Funcionarios.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ordex.Locadora.Domain.Cadastros.Frotas.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoPlaca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Cadastros.Clientes.Cliente", b =>
                {
                    b.HasOne("Ordex.Locadora.Domain.Cadastros.Enderecos.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ordex.Locadora.Domain.Logon.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Cadastros.Frotas.VeiculoImagem", b =>
                {
                    b.HasOne("Ordex.Locadora.Domain.Cadastros.Frotas.Veiculo", "Veiculo")
                        .WithMany("Imagens")
                        .HasForeignKey("VeiculoPlaca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Cadastros.Funcionarios.Funcionario", b =>
                {
                    b.HasOne("Ordex.Locadora.Domain.Cadastros.Enderecos.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ordex.Locadora.Domain.Logon.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.RoleClaim", b =>
                {
                    b.HasOne("Ordex.Locadora.Domain.Logon.Role", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.UsuarioClaim", b =>
                {
                    b.HasOne("Ordex.Locadora.Domain.Logon.Usuario", null)
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ordex.Locadora.Domain.Logon.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.UsuarioLogin", b =>
                {
                    b.HasOne("Ordex.Locadora.Domain.Logon.Usuario", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ordex.Locadora.Domain.Logon.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.UsuarioRole", b =>
                {
                    b.HasOne("Ordex.Locadora.Domain.Logon.Role", "Role")
                        .WithMany("UsuarioRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ordex.Locadora.Domain.Logon.Usuario", "Usuario")
                        .WithMany("UsuarioRole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.UsuarioToken", b =>
                {
                    b.HasOne("Ordex.Locadora.Domain.Logon.Usuario", null)
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ordex.Locadora.Domain.Logon.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Vistorias.Vistoria", b =>
                {
                    b.HasOne("Ordex.Locadora.Domain.Alugueis.Aluguel", "Aluguel")
                        .WithMany()
                        .HasForeignKey("AluguelCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ordex.Locadora.Domain.Cadastros.Funcionarios.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluguel");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Vistorias.VistoriaImagem", b =>
                {
                    b.HasOne("Ordex.Locadora.Domain.Vistorias.Vistoria", "Vistoria")
                        .WithMany()
                        .HasForeignKey("VistoriaCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vistoria");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Vistorias.VistoriaObservacao", b =>
                {
                    b.HasOne("Ordex.Locadora.Domain.Alugueis.Aluguel", "Aluguel")
                        .WithMany()
                        .HasForeignKey("AluguelCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ordex.Locadora.Domain.Vistorias.VistoriaImagem", "Imagens")
                        .WithMany()
                        .HasForeignKey("ImagensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ordex.Locadora.Domain.Vistorias.Vistoria", "Vistoria")
                        .WithMany()
                        .HasForeignKey("VistoriaCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluguel");

                    b.Navigation("Imagens");

                    b.Navigation("Vistoria");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Cadastros.Frotas.Veiculo", b =>
                {
                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.Role", b =>
                {
                    b.Navigation("RoleClaims");

                    b.Navigation("UsuarioRole");
                });

            modelBuilder.Entity("Ordex.Locadora.Domain.Logon.Usuario", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Logins");

                    b.Navigation("Tokens");

                    b.Navigation("UsuarioRole");
                });
#pragma warning restore 612, 618
        }
    }
}
