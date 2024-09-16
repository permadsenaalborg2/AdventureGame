using TECHCOOL.UI;

namespace Adventure.Editor
{
    public class GamePlayScreen : EditorScreen
    {
        public override string Title { get; set; } = "Play Game :-)";

        private Game MyGame;
        public GamePlayScreen(Game g)
        {
            MyGame = g;
        }
        protected override void Draw()
        {
            if (MyGame.StartRoom != null)
            {
                ConsoleColor SavedForeground = DefaultForeground;
                ConsoleColor SavedBackground = DefaultBackground;

                DefaultForeground = ConsoleColor.Yellow;
                DefaultBackground = ConsoleColor.DarkGray;
                Screen.Clear();

                Player player = new("Spiller", MyGame.StartRoom);
                MyGame.Play(player);
                Quit();

                DefaultForeground = SavedForeground;
                DefaultBackground = SavedBackground;
                Screen.Clear();
            }
            else
            {
                Console.WriteLine("Game not playable!");
                Console.ReadLine();
                Quit();
            }
        }
    }
}
