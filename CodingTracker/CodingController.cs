using Spectre.Console;
using System.Globalization;

namespace CodingTracker
{
    public class CodingController
    {
        private readonly Database _db;

        public CodingController(Database db)
        {
            _db = db;
        }
        public string CalculateDuration(string timeStart, string timeEnd)
        {
            DateTime parseTimeStart = DateTime.ParseExact(timeStart, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            DateTime parseTimeEnd = DateTime.ParseExact(timeEnd, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            TimeSpan duration = parseTimeEnd - parseTimeStart;

            var durationString = $"{duration.Hours.ToString()} hours {duration.Minutes.ToString()} minutes";

            return durationString;
        }
        public void CreateSession()
        {
            var timeStart = AnsiConsole.Prompt(new TextPrompt<string>("Enter the date and time of the session start [grey](dd.MM.yyyy HH:mm)[/]:"));
            // Here validate timeStart
            var timeEnd = AnsiConsole.Prompt(new TextPrompt<string>("Enter the date and time of the session end [grey](dd.MM.yyyy HH:mm)[/]:"));
            // Here validate timeEnd
            string durationSession = CalculateDuration(timeStart, timeEnd);
            _db.CreateRecordSession(timeStart, timeEnd, durationSession);
        }
        public void ReadAllSessions()
        {
            List<CodingSession> listSessions = _db.ReadListSessions();

            var tableSessions = new Table();
            tableSessions.AddColumn("ID");
            tableSessions.AddColumn("Time of the session Start");
            tableSessions.AddColumn("Time of the session End");
            tableSessions.AddColumn("Duration of the session");

            foreach (CodingSession session in listSessions)
            {
                tableSessions.AddRow(session.ID.ToString(), session.StartTime.ToString(), session.EndTime.ToString(), session.Duration.ToString());
            }
            AnsiConsole.Write(tableSessions);
        }
        public void UpdateSession()
        {
            List<CodingSession> listSessions = _db.ReadListSessions();

            CodingSession choiceSession = AnsiConsole.Prompt(
                new SelectionPrompt<CodingSession>()
                .Title("Which session do you want to update?")
                .AddChoices(listSessions)
                );
            var choiceChange = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("What do you want to change?")
                .AddChoices(new[] {
                    "Time of session start", "Time of session end"
                }));

            var newTimeStart = choiceSession.StartTime;
            var newTimeEnd = choiceSession.EndTime;
            var newDuration = choiceSession.Duration;

            switch (choiceChange)
            {
                case "Time of session start":
                    newTimeStart = AnsiConsole.Prompt(new TextPrompt<string>("Enter a new session start date and time [grey](dd.MM.yyyy HH:mm)[/]:"));
                    // Here validate newTimeStart
                    newDuration = CalculateDuration(newTimeStart, newTimeEnd);

                    _db.UpdateRecordSession(choiceSession.ID, newTimeStart, newTimeEnd, newDuration);
                    break;
                case "Time of session end":
                    newTimeEnd = AnsiConsole.Prompt(new TextPrompt<string>("Enter a new session end date and time [grey](dd.MM.yyyy HH:mm)[/]:"));
                    // Here validate newTimeEnd
                    newDuration = CalculateDuration(newTimeStart, newTimeEnd);

                    _db.UpdateRecordSession(choiceSession.ID, newTimeStart, newTimeEnd, newDuration);
                    break;
            }
        }
        public void DeleteSession()
        {
            List<CodingSession> listSessions = _db.ReadListSessions();

            CodingSession choiceSession = AnsiConsole.Prompt(
                new SelectionPrompt<CodingSession>()
                .Title("Which session do you want to delete?")
                .AddChoices(listSessions)
                );

            _db.DeleteRecordSession(choiceSession.ID);
        }
    }
}
