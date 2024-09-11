using TECHCOOL.UI;

namespace Adventure.Editor
{
    public class AboutScreen : EditorScreen
    {
        public override string Title { get; set; } = "About";

        public AboutScreen()
        {
            ExitOnEscape();
        }

        protected override void Draw()
        {
            Console.WriteLine("Adventure Editor.");
            Console.WriteLine(" ― TECHCOLLE since 1745");
            Console.WriteLine(" ― Per Madsen & Simon Bønding");
            Console.WriteLine();
            Console.WriteLine("Press any <esc> to continue");
        }
    }
}
