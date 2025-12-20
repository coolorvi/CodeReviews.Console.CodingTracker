using Spectre.Console;

namespace CodingTracker
{
    internal class UserInput
    {
        public static void Main()
        {
            var isRunning = true;
            while (isRunning) 
            {
                AnsiConsole.Clear();

                AnsiConsole.Write(new Rule("[bold violet]MAIN MENU[/]").RuleStyle("violet").LeftJustified());

                var choiceAction = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]What do you want to do?[/]")
                        .PageSize(5)
                        .AddChoices(new[] {
                            "Exit", "Create a new session", "Read all existing sessions",
                            "Update the session", "Delete the session"
                        }));

                switch (choiceAction) {
                    case "Exit":
                        isRunning = false;
                        break;
                    case "Create a new session":
                        var startDate = AnsiConsole.Prompt(new TextPrompt<string>("Enter the session start date [grey](DD:MM:YYYY)[/]"));
                        // Here validate startDate
                        var startTime = AnsiConsole.Prompt(new TextPrompt<string>("Enter the session start time [grey](HH:MM)[/]:"));
                        // Here validate startTime
                        var endDate = AnsiConsole.Prompt(new TextPrompt<string>("Enter the session end date [grey](DD:MM:YYYY)[/]"));
                        // Here validate endDate
                        var endTime = AnsiConsole.Prompt(new TextPrompt<string>("Enter the session end time [grey](HH:MM)[/]"));
                        // Here validate endTime
                        break;
                    case "Read all exsisting sessions":
                        // Call ReadAllSessions function
                        break;
                    case "Update the session":

                        break;
                    case "Delete the session":

                        break;
                    default:
                        AnsiConsole.Markup("[bold red]Invalid choice of action[/]");
                        break;
                }
            }
        }
    }
}