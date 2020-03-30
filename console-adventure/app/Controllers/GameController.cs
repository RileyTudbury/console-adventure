using System;
using console_adventure.Interfaces;
using console_adventure.Models;
using console_adventure.Services;

namespace console_adventure.Controllers
{
  class GameController : IGameController
  {
    private IGameService _gs { get; set; }
    private bool _running { get; set; } = true;
    public void Run()
    {
      Console.WriteLine("Hello there what is your name?");
      _gs = new GameService(Console.ReadLine());
      Utils.WinNoise();
      string greeting = "You've woken up 10 minutes before you need to leave for work! You need to find your pants and car keys to make it on time!";
      Console.WriteLine(greeting);
      Print();
      while (_running)
      {
        GetUserInput();
        Print();
      }
    }
    public void GetUserInput()
    {
      // go north
      // take brass key
      // command option
      // look
      // command
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " "; //go north ;take toilet paper ;look 
      string command = input.Substring(0, input.IndexOf(" ")); //go; take; look
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();//north; toilet paper;''

      Console.Clear();
      switch (command)
      {
        case "quit":
          _running = false;
          break;
        case "reset":
          _gs.Reset();
          break;
        case "look":
          _gs.Look();
          break;
        case "inventory":
          _gs.Inventory();
          break;
        case "go":
          _running = _gs.Go(option);
          break;
        case "take":
        case "grab":
          _gs.Take(option);
          break;
        case "use":
          _gs.Use(option);
          break;
        case "help":
          _gs.Help();
          break;
        default:
          _gs.Messages.Add("Not a recognized command");
          _gs.Help();
          _gs.Look();
          break;
      }
    }

    public void Print()
    {
      foreach (string message in _gs.Messages)
      {
        Console.WriteLine(message);
      }
      _gs.Messages.Clear();
    }

  }
}