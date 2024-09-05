using Hangman.CloudInfrastructure;
using Hangman.ExternalAPI;
using Hangman.GameConsole;
using Hangman.GameCore;
using Hangman.Local;

var gm = new ConsoleGameManager(
    new ConsoleSetupManager(),
    new APIWordGenerator(FoundationalModel.ANTHROPIC_CLAUDE1),
    new ConsolePlayer(),
    new ConsoleHangman(),
    new LocalStore()
    );

try
{
    gm.Setup();
    gm.Run();
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}

Console.WriteLine("Press any key to continue");
Console.ReadKey();