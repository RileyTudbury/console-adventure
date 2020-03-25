using System.Collections.Generic;
using console_adventure.Interfaces;

namespace console_adventure.Models
{
  class Player : IPlayer
  {
    private string playerName;

    public Player(string playerName)
    {
      Name = playerName;
      Inventory = new List<IItem>();
    }

    public string Name { get; set; }
    public List<IItem> Inventory { get; set; }
  }
}