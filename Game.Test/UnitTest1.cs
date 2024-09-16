namespace Test;

using Adventure;
public class UnitTest1
{
    [Fact]
    public void TestCreateIventory()
    {
        var inv = new Inventory();

        Assert.Empty(inv);

        var item_1 = new Item("Football", "A nice football");

        inv.Add(item_1);

        Assert.Contains(item_1, inv);
    }

    [Fact]
    public void PlaceItemInRoom()
    {
        var room_a1 = new Room("A1", "A single room");

        var item = new Item("RubberDuck", "Pers and");

        // default location is nowhere
        Assert.Empty(item.Location);

        room_a1.AddItem(item);

        // item now placed in room
        Assert.Equal(item.Location, room_a1.Name);

        var room_a2 = new Room("A2", "Another room");

        item.MoveItem(room_a1, room_a2);

        // item now placed in second room
        Assert.Equal(item.Location, room_a2.Name);
    }

    [Fact]
    public void SmallWorld()
    {
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
    }


    [Fact]
    public void TestDemoGame()
    {
        // arrange console
        var reader = new StringReader("go bus2");
        var writer = new StringWriter();
        Console.SetIn(reader);
        Console.SetOut(writer);

        // game
        var g = new Game();
        DemoGame.TechGame(g);

        // act & assert
        // step 1
        Player player = new Player("Player", g.StartRoom);
        var playing = g.Round(player);
        Assert.True(playing);
        Assert.Equal("Friis", player.CurrentRoom.Name);

        // step 2
        reader = new StringReader("go gaden");
        Console.SetIn(reader);
        playing = g.Round(player);
        Assert.True(playing);
        Assert.Equal("Jomfru Ane Gade", player.CurrentRoom.Name);


        // step 3-6
        for (int beer = 0; beer < 3; beer++)
        {
            reader = new StringReader($"take øl_{beer}");
            Console.SetIn(reader);
            playing = g.Round(player);
            Assert.True(playing);
            Assert.Equal("Jomfru Ane Gade", player.CurrentRoom.Name);
        }
        /*
        // step 7
        reader = new StringReader("take øl_5");
        Console.SetIn(reader);
        playing = g.Round(player);
        Assert.False(playing);
        Assert.Equal("Jomfru Ane Gade", player.CurrentRoom.Name);
        */

    }
}