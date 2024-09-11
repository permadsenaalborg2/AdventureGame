using TECHCOOL.UI;

namespace Adventure.Editor
{
    public abstract class EditorScreen : Screen
    {
        public EditorScreen() : base()
        {
            DefaultForeground = ConsoleColor.Yellow;
            DefaultBackground = ConsoleColor.Blue;
            FocusForeground = ConsoleColor.Green;
            FocusBackground = ConsoleColor.Cyan;
            FieldForeground = ConsoleColor.White;
            FieldBackground = ConsoleColor.DarkGray;
        }
    }
}
