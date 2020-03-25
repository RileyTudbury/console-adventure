using System;
using console_adventure.Controllers;
using console_adventure.Interfaces;

namespace console_adventure
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      IGameController gc = new GameController();
      gc.Run();
    }
  }
}
