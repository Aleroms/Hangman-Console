
public class ConsoleSetupManager : SetupManager
{
    private readonly int _lineLength = 50;

    public override GameDifficulty GetDifficulty()
    {
        DisplayWelcome();
        DisplayOptions();


        int uin;

        Console.Write("difficulty: ");
        string userInput = Console.ReadLine();

        while (!int.TryParse(userInput, out uin) || uin < 1 || uin > 3)
        {
            Console.WriteLine("Invalid input.");
            DisplayOptions();
            userInput = Console.ReadLine();
        }

        uin--;

        GameDifficulty difficulty = (GameDifficulty)uin;
        return difficulty;
    }

    private void DisplayWelcome()
    {
        ConsoleHangman.DisplayBanner();

        Console.WriteLine("Welcome to Hangman!");
    }
    private void DisplayOptions()
    {
        Console.WriteLine("Please select from the following options:");
        ConsoleFormatting.WriteColored(
            "1: EASY, ", ConsoleColor.Green, false);
        ConsoleFormatting.WriteColored(
            "2: MEDIUM, ", ConsoleColor.Yellow, false);
        ConsoleFormatting.WriteColored(
            "3: HARD\n", ConsoleColor.Red, false);
    }
}