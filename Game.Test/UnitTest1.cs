namespace Game.Test;

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
    public void TestDemoGame()
    {
        // arrange console
        var reader = new StringReader("go bus2");
        var writer = new StringWriter();
        Console.SetIn(reader);
        Console.SetOut(writer);

        // game
        var g = new Game2();
        var room = g.DemoGame();

        // act & assert
        // step 1
        Player player = new(room);
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