using console_adventure.Interfaces;

namespace console_adventure.Models
{
  class Game : IGame
  {
    public IPlayer CurrentPlayer { get; set; }
    public IRoom CurrentRoom { get; set; }

    ///<summary>Initalizes data and establishes relationships</summary>
    public Game()
    {
      // NOTE ALL THESE VARIABLES ARE REMOVED AT THE END OF THIS METHOD
      // We retain access to the objects due to the linked list

      // NOTE Create all rooms
      Room bed = new Room("Your Bed", @"You've awoken in your comfy bed! To the East is the center of your room.");
      Room bedroomCenter = new Room("Bedroom Center", "You are in the center of your bedroom. To the North is your desk. To the South is your dresser. To the East is your garage.");
      Room yourDesk = new Room("Your Desk", "You see your trusty desktop PC, a small stack of papers, a set of car keys, and other odds and ends. The center of your bedroom is to the South.");
      Room garage = new Room("Your Garage", "Your garage, in it to the East is your reliable car! Your room is back to the West.");
      Room yourDresser = new Room("Your Dresser", "You are standing in front of your dresser. It is full of clean pants! To the North is the center of your room.");
      EndRoom car = new EndRoom("Your Trusty Car!", "You put in your keys and start the car!", true, "Against all odds you drive your car to work on time!");

      // NOTE Create all Items
      Item pants = new Item("pants", "Your best work pants.");
      Item carKeys = new Item("keys", "The keys to your trusty car!");

      // NOTE Make Room Relationships
      bed.Exits.Add("east", bedroomCenter);
      bedroomCenter.Exits.Add("west", bed);
      bedroomCenter.Exits.Add("north", yourDesk);
      yourDesk.Exits.Add("south", bedroomCenter);
      bedroomCenter.AddLockedRoom(pants, "east", garage);
      garage.Exits.Add("west", garage);
      bedroomCenter.Exits.Add("south", yourDresser);
      yourDresser.Exits.Add("north", bedroomCenter);
      garage.AddLockedRoom(carKeys, "east", car);

      // NOTE put Items in Rooms
      yourDresser.Items.Add(pants);
      yourDesk.Items.Add(carKeys);

      CurrentRoom = bed;
    }
  }
}