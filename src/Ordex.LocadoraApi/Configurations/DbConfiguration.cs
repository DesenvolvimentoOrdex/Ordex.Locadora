using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Infraesctuture.Data;

namespace Ordex.LocadoraApi.Configurations
{
    public static class DbConfiguration
    {
        public static void ConexaoBanco(IServiceCollection service, IConfiguration config)
        {
            string databaseName = "testeordex";
            try
            {
                using (SqlConnection connection = new SqlConnection(config.GetConnectionString("OrdexLocadora")))
                {
                    connection.Open();

                    //Verifica se o banco já existe
                        SqlCommand checkDbCommand = new SqlCommand($"SELECT db_id('{databaseName}')", connection);
                    var result = checkDbCommand.ExecuteScalar().ToString();

                    if (result == "")
                    {
                    //    Cria o banco de dados
                       SqlCommand createDbCommand = new SqlCommand($"CREATE DATABASE {databaseName}", connection);
                        createDbCommand.ExecuteNonQuery();
                        Console.WriteLine($"Banco de dados '{databaseName}' criado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine($"O banco de dados '{databaseName}' já existe.");
                    }

                    var serviceProvider = service.AddDbContext<LocadoraDbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("OrdexLocadora"))).BuildServiceProvider();

                    using (var context = serviceProvider.GetService<LocadoraDbContext>())
                    {
                        var pendingMigrations = context.Database.GetPendingMigrations();
                        if (pendingMigrations.Any())
                        {
                            Console.WriteLine("Existem migrações pendentes:");
                            foreach (var migration in pendingMigrations)
                            {
                                context.Database.Migrate();
                                Console.WriteLine("Migrações aplicadas com sucesso!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Todas as migrações já foram aplicadas.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na criação do banco de dados: {ex.Message}");
            }
        }
    }
}
