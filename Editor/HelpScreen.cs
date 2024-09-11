using TECHCOOL.UI;

namespace Adventure.Editor
{
    public class HelpScreen : EditorScreen
    {
        public override string Title { get; set; } = "Help";

        public HelpScreen()
        {
            ExitOnEscape();
            AddKey(ConsoleKey.F1, () => Screen.Display(new AboutScreen()));
            AddKey(ConsoleKey.F2, () => Screen.Display(new HelpScreen()));
        }
        protected override void Draw()
        {
            Console.WriteLine("Don't Panic.");
            Console.WriteLine(" ― Douglas Adams, The Hitchhiker’s Guide to the Galaxy");
            Console.WriteLine();
            Console.WriteLine("Press <esc> to continue");
            Console.WriteLine("Press <F1> for About page");
        }
    }
}
