using Dapper;
using Microsoft.Extensions.Configuration;
using Spectre.Console;
using System.Data;
using Microsoft.Data.Sqlite;

namespace CodingTracker
{
    public class Database
    {
        private string _connectionString = null!;
        public void Initialize()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("Default");

            if (connectionString == null)
            {
                AnsiConsole.MarkupLine("[red]Oops! Connection string not found.[/]");
                return;
            }

            _connectionString = connectionString;

            using IDbConnection connection = new SqliteConnection(_connectionString);

            var request = "CREATE TABLE IF NOT EXISTS CodingSessions (ID INTEGER PRIMARY KEY AUTOINCREMENT, StartTime TEXT NOT NULL, EndTime TEXT NOT NULL, Duration TEXT NOT NULL);";

            connection.Execute(request);
        }

        public List<CodingSession> ReadListSessions()
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);

            var request = "SELECT * FROM CodingSessions";

            var sessions = connection.Query<CodingSession>(request);

            return sessions.ToList();
        }

        public void CreateRecordSession(string timeStart, string timeEnd, string durationSession)
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);

            var request = "INSERT INTO CodingSessions (StartTime, EndTime, Duration) VALUES (@TimeStart, @TimeEnd, @DurationSession)";

            connection.Execute(request, new { TimeStart = timeStart, TimeEnd = timeEnd, DurationSession = durationSession });
        }

        public void UpdateRecordSession(int id, string timeStart, string timeEnd, string durationSession)
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);

            var request = "UPDATE CodingSessions SET StartTime = @TimeStart, EndTime = @TimeEnd, Duration = @DurationSession WHERE ID = @ID";

            connection.Execute(request, new { TimeStart = timeStart, TimeEnd = timeEnd, DurationSession = durationSession, ID = id });
        }

        public void DeleteRecordSession(int id)
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);

            var request = "DELETE FROM CodingSessions WHERE ID = @id";

            connection.Execute(request, new { id });
        }
    }
}
