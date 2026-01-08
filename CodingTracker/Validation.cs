using Spectre.Console;
using System.Globalization;

namespace CodingTracker
{
    internal class Validation
    {
        public bool ValidationDates(string timeStart, string timeEnd)
        {
            if (!DateTime.TryParseExact(timeStart, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedTimeStart))
            {
                AnsiConsole.MarkupLine("[red]Oops! Incorrect session start date format.[/]");
                return false;
            }
            if (!DateTime.TryParseExact(timeEnd, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedTimeEnd))
            {
                AnsiConsole.MarkupLine("[red]Oops! Incorrect session end date format.[/]");
                return false;
            }
            if (parsedTimeStart >= parsedTimeEnd)
            {
                AnsiConsole.MarkupLine("[red]Oops! Session start date cannot be greater than or equal to the end date.[/]");
                return false;
            }
            return true;
        }
    }
}
