using System.Collections.Generic;
using console_adventure.Interfaces;
using console_adventure.Models;

namespace console_adventure.Services
{
  class GameService : IGameService
  {
    public List<string> Messages { get; set; }
    private IGame _game { get; set; }
    private int minutes { get; set; }

    public GameService(string playerName)
    {
      Messages = new List<string>();
      _game = new Game();
      _game.CurrentPlayer = new Player(playerName);
      Look();
    }

    public bool Go(string direction)
    {
      minutes++;
      if (minutes >= 10)
      {
        Utils.LossNoise();
        Messages.Add("You took too long to get to work! Sorry, you're fired!");
        return false;
      }
      //if the current room has that direction on the exits dictionary
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        // set current room to the exit room
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        // populate messages with room description
        Messages.Add($"You Travel {direction}, and discover: ");
        Messages.Add($"Minutes Passed: {minutes}");
        Look();
        EndRoom end = _game.CurrentRoom as EndRoom;
        if (end != null)
        {
          Utils.WinNoise();
          Messages.Add(end.Narrative);
          return false;
        }
        return true;
      }
      //no exit in that direction
      Messages.Add("No Room in that direction");
      Messages.Add($"Minutes Passed: {minutes}");
      Look();
      return true;
    }

    public void Help()
    {
      Messages.Add("Commands: go {direction}, take {item}, use {item}, look, reset");
    }

    public void Inventory()
    {
      Messages.Add("Current Inventory: ");
      foreach (var item in _game.CurrentPlayer.Inventory)
      {
        Messages.Add($"{item.Name} - {item.Description}");
      }
    }

    public void Look()
    {
      Messages.Add("Current Room: " + _game.CurrentRoom.Name);
      Messages.Add(_game.CurrentRoom.Description);
      if (_game.CurrentRoom.Items.Count > 0)
      {
        Messages.Add("There Are a few things in this area:");
        foreach (var item in _game.CurrentRoom.Items)
        {
          Messages.Add("     " + item.Name);
        }
      }
      string exits = string.Join(" and ", _game.CurrentRoom.Exits.Keys);
      if (_game.CurrentRoom.Exits.Count > 0)
      {
        Messages.Add("There are exits to the " + exits);
      }

      string lockedExits = "";
      foreach (var lockedRoom in _game.CurrentRoom.LockedExits.Values)
      {
        lockedExits += lockedRoom.Key;
      }
      if (_game.CurrentRoom.LockedExits.Count > 0)
      {
        Messages.Add("There are locked exits to the " + lockedExits);
      }

    }

    public void Reset()
    {
      string name = _game.CurrentPlayer.Name;
      _game = new Game();
      _game.CurrentPlayer = new Player(name);
      minutes = 0;
    }

    public void Take(string itemName)
    {
      IItem found = _game.CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName);
      if (found != null)
      {
        if (found.Name == "keys")
        {
          _game.CurrentRoom.Description = "You see your trusty desktop PC, a small stack of papers, and other odds and ends. The center of your bedroom is to the South.";
        }
        _game.CurrentPlayer.Inventory.Add(found);
        _game.CurrentRoom.Items.Remove(found);
        Utils.WinNoise();
        Messages.Add($"You have taken the {itemName}");
        return;
      }
      Messages.Add("Cannot find item by that name");
    }

    public void Use(string itemName)
    {
      var found = _game.CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName);
      if (found != null)
      {
        Messages.Add(_game.CurrentRoom.Use(found));
        return;
      }
      // check if item is in room
      Messages.Add("You don't have that Item");
    }



  }
}