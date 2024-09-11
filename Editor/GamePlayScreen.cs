using TECHCOOL.UI;

namespace Adventure.Editor
{
    public class GamePlayScreen : EditorScreen
    {
        public override string Title { get; set; } = "Play Game :-)";

        private Room startRoom;
        public GamePlayScreen(Room r)
        {
            startRoom = r;
            ExitOnEscape();
            AddKey(ConsoleKey.F12, () => Screen.Display(new HelpScreen()));
        }
        protected override void Draw()
        {
            var g = new Game();
            Player player = new(startRoom);
            g.Play(player);
            Quit();
        }
    }
}
