using BankApp.Repository.Interface;
using BankApp.Repository;
using BankApp.Services;
using BankApp.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace BankApp.Views
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var bankApp = new BankApp(
                    serviceProvider.GetRequiredService<IBankService>(),
                    serviceProvider.GetRequiredService<IAccountService>(),
                    serviceProvider.GetRequiredService<ITransactionService>(),
                    serviceProvider.GetRequiredService<IValidationService>()
                );

                bankApp.BankAppRun();
            }
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            // Load the configuration from appsettings.json.
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string from the configuration.
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            // Register the connection string as a service.
            services.AddSingleton(connectionString);

            // Registering the Repositories.
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();   
            services.AddScoped<IValidationsRepository, ValidationsRepository>();

            // Registering the Services.
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IValidationService, ValidationService>();
        }
    }
}
