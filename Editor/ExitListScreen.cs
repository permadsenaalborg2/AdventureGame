using TECHCOOL.UI;

namespace Adventure.Editor
{
    /*
    public class ExitListScreen : EditorScreen
    {
        private readonly ListPage<Tuple<string, Room>> listPage;

        public ExitListScreen(Room room)
        {
            listPage = new();
            listPage.Add(room.ExitList());
            //listPage.AddKey(ConsoleKey.F1, CreateNewRoom);
            //listPage.AddKey(ConsoleKey.F2, DeleteRoom);
            //listPage.AddKey(ConsoleKey.F12, ShowHelp);
            listPage.AddKey(ConsoleKey.Escape, Quit);
            listPage.AddColumn("Dir", "Dir");
            listPage.AddColumn("Name", "Name", 30);
        }

        public override string Title { get; set; } = "List of rooms";
        protected override void Draw()
        {
            Console.WriteLine("Press F1 to add a new Room");
            Console.WriteLine("Press F2 to delete a Room");
            Console.WriteLine("Press F12 to show help");

            ExitDictionary selected = listPage.Select();

            if (selected != null)
            {
                Screen.Display(new EditRoomScreen(selected));
            }
        }

   
        void Quit(Tuple<string, Room> _)
        {
            Quit();
        }
    }
    */
}