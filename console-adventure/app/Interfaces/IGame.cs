namespace console_adventure.Interfaces
{
  interface IGame
  {
    IPlayer CurrentPlayer { get; set; }
    IRoom CurrentRoom { get; set; }
  }
}