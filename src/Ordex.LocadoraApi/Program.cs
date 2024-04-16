using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Infraesctuture.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LocadoraDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("OrdexLocadora")));

/*var serviceProvider = new ServiceCollection()
                .AddDbContext<DataContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Identity")))
                .BuildServiceProvider();

using (var scope = serviceProvider.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.EnsureCreated();
    Console.WriteLine("Banco de dados criado ou já existe.");
}*/
builder.Services.AddAuthorization();

//builder.Services.AddIdentity<Usuario, Role>(options => options.SignIn.RequireConfirmedAccount = true)
//        .AddEntityFrameworkStores<LocadoraDbContext>();

builder.Services.AddIdentityApiEndpoints<Usuario>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LocadoraDbContext>();


//builder.Services.AddTransient<IEmailService, EmailService>();
//builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<Usuario>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();