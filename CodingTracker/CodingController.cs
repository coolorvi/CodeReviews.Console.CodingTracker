using Spectre.Console;
using System.Globalization;

namespace CodingTracker
{
    public class CodingController
    {
        public TimeSpan CalculateDuration(string timeStart, string timeEnd)
        {
            DateTime parseTimeStart = DateTime.ParseExact(timeStart, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            DateTime parseTimeEnd = DateTime.ParseExact(timeEnd, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            TimeSpan duration = parseTimeEnd - parseTimeStart;
            return duration;
        }
        public void CreateSession()
        {
            var timeStart = AnsiConsole.Prompt(new TextPrompt<string>("Enter the date and time of the session start [grey](dd.MM.yyyy HH:mm)[/]:"));
            // Here validate timeStart
            var timeEnd = AnsiConsole.Prompt(new TextPrompt<string>("Enter the date and time of the session end [grey](dd.MM.yyyy HH:mm)[/]:"));
            // Here validate timeEnd
            TimeSpan durationSession = CalculateDuration(timeStart, timeEnd);
            // Here call CreateRecordSession(timeStart, timeEnd, durationSession)
        }
        public void ReadAllSessions()
        {
            // Here call ReadListSessions
            /* var tableSessions = new Table();
            tableSessions.AddColumn("ID");
            tableSessions.AddColumn("Time of the session Start");
            tableSessions.AddColumn("Time of the session End");
            tableSessions.AddColumn("Duration of the session");
            foreach (CodingSession session in listSessions)
            {
                tableSessions.AddRow(session.ID.ToString(), session.StartTime, session.EndTime, session.Duration);
            }
            AnsiConsole.Write(tableSessions); */
        }
        public void UpdateSession()
        {
            // Here call ReadListSessions
            CodingSession choiceSession = AnsiConsole.Prompt(
                new SelectionPrompt<CodingSession>()
                .Title("Which session do you want to update?")
                .AddChoices(/*listSessions*/)
                );
            var choiceChange = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("What do you want to change?")
                .AddChoices(new[] {
                    "Time of session start", "Time of session end"
                }));

            var newTimeStart = choiceSession.StartTime;
            var newTimeEnd = choiceSession.EndTime;

            switch (choiceChange)
            {
                case "Time of session start":
                    newTimeStart = AnsiConsole.Prompt(new TextPrompt<string>("Enter a new session start date and time [grey](dd.MM.yyyy HH:mm)[/]:"));
                    // Here validate newTimeStart
                    CalculateDuration(newTimeStart, newTimeEnd);
                    // Here call UpdateRecordSession
                    break;
                case "Time of session end":
                    newTimeEnd = AnsiConsole.Prompt(new TextPrompt<string>("Enter a new session end date and time [grey](dd.MM.yyyy HH:mm)[/]:"));
                    // Here validate newTimeEnd
                    CalculateDuration(newTimeStart, newTimeEnd);
                    // Here call UpdateRecordSession
                    break;
            }
        }
        public void DeleteSession()
        {
            // Here call ReadListSessions
            CodingSession choiceSession = AnsiConsole.Prompt(
                new SelectionPrompt<CodingSession>()
                .Title("Which session do you want to delete?")
                .AddChoices(/*listSession*/)
                );
            // Here call DeleteRecordSession
        }
    }
}
