using TECHCOOL.UI;

namespace Adventure.Editor
{
    public class HelpScreen : EditorScreen
    {
        public override string Title { get; set; } = "Help";
        private static int count = 0;

        public HelpScreen()
        {
            ExitOnEscape();
            AddKey(ConsoleKey.F1, () => Screen.Display(new AboutScreen()));
            AddKey(ConsoleKey.F2, () => 
            {
                        var scr = new HelpScreen(); 
                        scr.Title = $"Help {HelpScreen.count++}";
                        Screen.Display(scr);
            });
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
