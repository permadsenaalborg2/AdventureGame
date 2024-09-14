using TECHCOOL.UI;

namespace Adventure.Editor
{
    public class RoomListScreen : EditorScreen
    {
        private readonly ListPage<Room> listPage;

        public RoomListScreen(List<Room> startlist)
        {
            listPage = new ListPage<Room>();
            listPage.Add(startlist);
            listPage.AddKey(ConsoleKey.F1, CreateNewRoom);
            listPage.AddKey(ConsoleKey.F2, DeleteRoom);
            listPage.AddKey(ConsoleKey.F12, ShowHelp);
            listPage.AddKey(ConsoleKey.Escape, Quit);
            listPage.AddColumn("Rooms", "Name", 20);
            listPage.AddColumn("Description", "Description", 70);
            listPage.AddColumn("Exits", "Exits", 85);
        }

        public override string Title { get; set; } = "List of rooms";
        protected override void Draw()
        {
            Console.WriteLine("Press F1 to add a new room");
            Console.WriteLine("Press F2 to delete a room");
            Console.WriteLine("Press ENTER to edit a room");
            Console.WriteLine("Press ESC to exit");

            Room selected = listPage.Select();

            if (selected != null)
            {
                Screen.Display(new EditRoomScreen(selected));
            }
        }

        void CreateNewRoom(Room _)
        {
            Room new_room = new();
            Screen.Display(new EditRoomScreen(new_room));
            if (!new_room.IsDefault())
                listPage.Add(new_room);
        }

        void DeleteRoom(Room room_to_delete)
        {
            if (!room_to_delete.IsDefault())
            {
                ConfirmScreen conf = new($"This will delete: {room_to_delete.Name}");
                Screen.Display(conf);
                if (conf.confirmed)
                {
                    listPage.Remove(room_to_delete);
                }
            }
        }

        void ShowHelp(Room _)
        {
            Screen.Display(new HelpScreen());
        }
        void Quit(Room _)
        {
            Quit();
        }
    }
}