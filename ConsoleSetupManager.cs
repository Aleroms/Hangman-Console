
public class ConsoleSetupManager : SetupManager
{
    private readonly int _lineLength = 50;
    
    public override GameDifficulty GetDifficulty()
    {
        DisplayWelcome();

        string options = "Please select from the following options:\n1. EASY, 2. MEDIUM, 3. HARD";
        Console.WriteLine("Please select from the following options:");
        ConsoleFormatting.WriteColored(
            "1: EASY, ", ConsoleColor.Green, false);
        ConsoleFormatting.WriteColored(
            "2: MEDIUM, ", ConsoleColor.Yellow, false);
        ConsoleFormatting.WriteColored(
            "3: HARD\n", ConsoleColor.Red, false);

        int uin;

        Console.Write("difficulty: ");
        string userInput = Console.ReadLine();

        while (!int.TryParse(userInput, out uin) || uin < 1 || uin > 3)
        {
            Console.WriteLine("Invalid input.");
            Console.WriteLine(options);
            userInput = Console.ReadLine();
        }

        uin--;

        GameDifficulty difficulty = (GameDifficulty)uin;
        return difficulty;
    }
    private void DisplayLine()
    {
        string line = "";
        for (int i = 0; i < _lineLength; i++)
        {
            line += "=";
        }
        Console.WriteLine(line);
    }
    private void DisplayWelcome()
    {
        ConsoleHangman.DisplayBanner();

        Console.WriteLine("Welcome to Hangman!");
    }
}