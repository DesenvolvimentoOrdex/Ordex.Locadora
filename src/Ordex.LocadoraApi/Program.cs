using Autofac;
using Autofac.Extensions.DependencyInjection;
using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Domain.Cadastros.Clientes;
using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Infraesctuture.Data;
using Ordex.Locadora.Service.EmailService;
using Ordex.Locadora.Shared.Interfaces;
using Ordex.LocadoraApi.Configurations;
using Ordex.LocadoraApi.Infraesctruture;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LocadoraDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("OrdexLocadora")));

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MediatorModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ApplicationModule()));

//DbConfiguration.ConexaoBanco(builder.Services, builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.AddHttpClient();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<Usuario>()
                .AddEntityFrameworkStores<LocadoraDbContext>()
                .AddApiEndpoints();

builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolice", builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

var emailConfig = builder.Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStatusCodePages();
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolice");

app.Run();