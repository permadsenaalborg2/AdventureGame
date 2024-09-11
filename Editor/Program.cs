using TECHCOOL.UI;
using Adventure.Editor;
using Adventure;


List<Room> startlist;
startlist = [
    new Room("B-109", "Her er vi!"),
    new Room("C-103", "Her er vi ikke!"),
    new Room("C-104", "Her er vi heller ikke!")];

List<Item> startItemList;
startItemList = [
    new Item("RubberDuck", "Pers and"),
    new Item("Kaffekop", "Pers kaffe"),
    new Item("TDD - Beck", "God bog!")];


Menu menu = new Menu();
menu.Add(new RoomListScreen(startlist));
menu.Add(new ItemListScreen(startItemList));
menu.Add(new HelpScreen());

Screen.Display(menu);

//Screen.Display(new HelpScreen());

//Screen.Display(new RoomListScreen(startlist));

// Room r = new Room("Hej", "Nordpolen");
// RoomExit e = new("Nord", r);

// Console.WriteLine(r);
// Console.WriteLine(e);

// Screen.Clear();
// Console.WriteLine("So Long, and Thanks for All the Fish :-)");
