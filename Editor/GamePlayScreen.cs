using TECHCOOL.UI;

namespace Adventure.Editor
{
    public class GamePlayScreen : EditorScreen
    {
        public override string Title { get; set; } = "Play Game :-)";

        private Room startRoom;
        //private Game MyGame;
        public GamePlayScreen(Room r)
        {
            startRoom = r;
            // AddKey(ConsoleKey.F12, () => Screen.Display(new HelpScreen()));
        }
        protected override void Draw()
        {
            DefaultForeground = ConsoleColor.Yellow;
            DefaultBackground = ConsoleColor.DarkGray;
            Screen.Clear();

            Player player = new(startRoom);
            var g = new Game();
            g.Play(player);
            Quit();

            DefaultForeground = ConsoleColor.Yellow;
            DefaultBackground = ConsoleColor.Blue;
            Screen.Clear();

        }
    }
}
