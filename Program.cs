
using System.Data;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.Json;

internal class Program
{
  static Dictionary<string, string> WinCondition = new Dictionary<string, string>()
{
{"Rock", "Scissors"}, {"Paper", "Rock"}, {"Scissors", "Paper"}
};
  static int playerWins = 0;
  static int computerWins = 0;
  private static void Main()
  {
    LoadGame();
    Console.ResetColor();
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Ready Set.... Rock Paper Scissors!!!");
    Console.WriteLine($"Score | Player Wins {playerWins} | Computer Wins {computerWins}");
    Console.ResetColor();
    string UserHand = ChooseHand();
    string ComputerHand = GetComputerHand();
    FindWinner(UserHand, ComputerHand);
  }
  static void FindWinner(string UserHand, string ComputerHand)
  {
    Console.WriteLine($" You chose {UserHand}, and computer chose {ComputerHand}");
    if (UserHand == ComputerHand)
    {
      Console.WriteLine("Its a tie Nobody wins");
      Console.ForegroundColor = ConsoleColor.DarkCyan;
      PlayAgain();
    }
    if (WinCondition[UserHand] == ComputerHand)
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Congrats!!!! You Win");
      playerWins++;
      Console.ResetColor();
      SaveGame();
      PlayAgain();
    }
    if (WinCondition[ComputerHand] == UserHand)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("OH NO YOU LOST THERE IS NO HOPE FOR HUMANITY NOW");
      computerWins++;
      Console.ResetColor();
      SaveGame();
      PlayAgain();
    }
  }
  static string ChooseHand()
  {

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("Choose Hand");
    Console.ResetColor();
    Console.WriteLine("1. 🪨");
    Console.WriteLine("2. 📃");
    Console.WriteLine("3. ✂️");

    var userInput = Console.ReadKey().KeyChar;
    string ChosenHand = "";

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    if (userInput == '1')
    {
      // Console.Write(" You Chose 🪨 ");
      Console.ResetColor();
      ChosenHand = "Rock";
    }
    else if (userInput == '2')
    {
      // Console.WriteLine(" You Chose 📃 ");
      Console.ResetColor();
      ChosenHand = "Paper";
    }
    else if (userInput == '3')
    {
      // Console.WriteLine(" You Chose ✂️ ");
      Console.ResetColor();
      ChosenHand = "Scissors";
    }
    else
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Incorrect Key choose either 1, 2 or 3 ");
      Console.ResetColor();
      Thread.Sleep(1000);
      return ChooseHand();
    }
    return ChosenHand;
  }

  static string GetComputerHand()
  {
    int randomNumber = new Random().Next(1, 4);
    string ComputerHand = "";
    if (randomNumber == 1) ComputerHand = "Rock";
    if (randomNumber == 2) ComputerHand = "Paper";
    if (randomNumber == 3) ComputerHand = "Scissors";
    // Console.WriteLine($"Computer chose {ComputerHand}");

    return ComputerHand;
  }
  static void PlayAgain()
  {
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("Do you want to play again y/n");
    Console.ResetColor();
    var userInput = Console.ReadKey().KeyChar;
    if (userInput == 'y')
    {
      Main();
    }
  }
  static void SaveGame()
  {
    SaveData save = new(playerWins, computerWins);
    string saveData = JsonSerializer.Serialize(save);
    File.WriteAllText("saveGame.json", saveData);
  }
  static void LoadGame()
  {
    string jsonString = File.ReadAllText("saveGame.json");
    SaveData data = JsonSerializer.Deserialize<SaveData>(jsonString);
    if (data != null)
    {
      playerWins = data.PlayerWins;
      computerWins = data.ComputerWins;
    }
  }
}