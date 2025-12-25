using Spectre.Console;

namespace CodingTracker
{
    internal class UserInput
    {
        public static void Main()
        {
            var cc = new CodingController();
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
                        AnsiConsole.Clear();
                        break;
                    case "Create a new session":
                        cc.CreateSession();
                        break;
                    case "Read all exsisting sessions":
                        cc.ReadAllSessions();
                        break;
                    case "Update the session":
                        cc.UpdateSession();
                        break;
                    case "Delete the session":
                        cc.DeleteSession();
                        break;
                }
            }
        }
    }
}