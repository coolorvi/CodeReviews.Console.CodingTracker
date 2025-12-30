using Dapper;
using Microsoft.Extensions.Configuration;
using Spectre.Console;

namespace CodingTracker
{
    internal class Database
    {
        public void Initialize()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            if (configuration.GetConnectionString("Default") == null)
            {
                AnsiConsole.MarkupLine("[red]Oops! Connection string not found.[/]");
            }
            string connectionString = configuration.GetConnectionString("Default");
        }
    }
}
