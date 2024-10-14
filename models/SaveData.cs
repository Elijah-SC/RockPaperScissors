internal class SaveData
{
  public int PlayerWins { get; set; }
  public int ComputerWins { get; set; }
  public SaveData(int playerWins, int computerWins)
  {
    PlayerWins = playerWins;
    ComputerWins = computerWins;
  }

}