using TECHCOOL.UI;

namespace Adventure.Editor
{

    public class ExitListScreen : EditorScreen
    {

        private readonly ListPage<RoomExit> listPage;
        public override string Title { get; set; } = "List of exits";

        public ExitListScreen(Room room)
        {
            listPage = new();
            listPage.Add(room.Exits.ExitList());
            //listPage.AddKey(ConsoleKey.F1, CreateNewRoom);
            //listPage.AddKey(ConsoleKey.F2, DeleteRoom);
            //listPage.AddKey(ConsoleKey.F12, ShowHelp);
            listPage.AddKey(ConsoleKey.Escape, Quit);
            listPage.AddColumn("Dir", "Dir");
            listPage.AddColumn("Name", "Name", 30);
        }

        protected override void Draw()
        {
            Console.WriteLine("Press F1 to add a new Room");
            Console.WriteLine("Press F2 to delete a Room");
            Console.WriteLine("Press F12 to show help");

            RoomExit selected = listPage.Select();

            if (selected != null)
            {
                // Screen.Display(new EditRoomScreen(selected));
            }
        }


        void Quit(RoomExit _)
        {
            Quit();
        }


    }

}