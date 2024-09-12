using TECHCOOL.UI;
using Adventure.Editor;
using Adventure;


var r1 = new Room("B-109", "Her er vi!");
var r2 = new Room("C-103", "Her er vi ikke!");
var r3 = new Room("C-104", "Her er vi heller ikke!");

List<Room> startRoomList;
startRoomList = [r1, r2, r3];

r1.AddTwoWayExit("frem", "tilbage", r2);
r2.AddTwoWayExit("frem", "tilbage", r3);

var i1 = new Item("RubberDuck", "Pers and");
var i2 = new Item("Kaffekop", "Pers kaffe");
var i3 = new Item("TDD - Beck", "God bog!");

List<Item> startItemList;
startItemList = [i1, i2, i3];

Menu menu = new Menu();
menu.Add(new RoomListScreen(startRoomList));
menu.Add(new ItemListScreen(startItemList));
menu.Add(new GamePlayScreen(startRoomList[0]));
menu.Add(new HelpScreen());

menu.AddKey(ConsoleKey.D, () => { Game g = new(); new GamePlayScreen(new DemoGame().StartRoom); });
Screen.Display(menu);

//Screen.Display(new HelpScreen());

//Screen.Display(new RoomListScreen(startlist));

// Room r = new Room("Hej", "Nordpolen");
// RoomExit e = new("Nord", r);

// Console.WriteLine(r);
// Console.WriteLine(e);

Screen.Clear();
Console.WriteLine("So Long, and Thanks for All the Fish :-)");
