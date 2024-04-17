using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Infraesctuture.Data;
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

DbConfiguration.ConexaoBanco(builder.Services, builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.AddHttpClient();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<Usuario>()
                .AddEntityFrameworkStores<LocadoraDbContext>()
                .AddApiEndpoints();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStatusCodePages();
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();