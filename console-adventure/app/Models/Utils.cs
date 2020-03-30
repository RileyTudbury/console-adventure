using System;
using System.Threading;

namespace console_adventure.Models
{
  static class Utils
  {
    public static void LossNoise()
    {
      Console.Beep(500, 150);
      Console.Beep(400, 150);
      Console.Beep(300, 150);
      Console.Beep(200, 300);
    }
    public static void WinNoise()
    {
      Console.Beep(200, 150);
      Console.Beep(300, 150);
      Console.Beep(400, 150);
      Console.Beep(500, 300);
    }
    public static void PlayIntro()
    {
      Console.Clear();
      Console.BackgroundColor = ConsoleColor.DarkRed;
      Console.Clear();
      Console.Beep(500, 150);
      Console.BackgroundColor = ConsoleColor.Red;
      Console.Clear();
      Console.Beep(400, 150);
      Console.BackgroundColor = ConsoleColor.DarkYellow;
      Console.Clear();
      Console.Beep(300, 150);
      Console.BackgroundColor = ConsoleColor.Yellow;
      Console.Clear();
      Console.Beep(200, 300);
      Console.BackgroundColor = ConsoleColor.Black;
      Console.Clear();
    }
  }
}