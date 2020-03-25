using System.Collections.Generic;

namespace console_adventure.Interfaces
{
  interface IPlayer
  {
    string Name { get; set; }
    List<IItem> Inventory { get; set; }
  }
}