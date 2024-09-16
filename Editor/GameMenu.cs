namespace Adventure.Editor
{
    using Adventure;
    using TECHCOOL.UI;

    class GameMenu : Menu
    {
        public GameMenu() : base()
        {
            var g = new Game();

            Add(new RoomListScreen(g.RoomList));
            Add(new ItemListScreen(g));
            Add(new GamePlayScreen(g));
            Add(new HelpScreen());

            AddKey(ConsoleKey.D, () => { DemoGame.TechGame(g); });
            AddKey(ConsoleKey.C, () => { g.Clear(); });
            AddKey(ConsoleKey.L, () => { g.Clear(); });
            AddKey(ConsoleKey.S, () => { g.Clear(); });

        }
        protected override void Draw()
        {
            base.Draw();
            Console.WriteLine();
            Console.WriteLine("Action: [d] to load demo, [c] to clear game, [l] to load game, [s] to save game");
        }
    }
}