namespace Adventure.Editor
{
    using TECHCOOL.UI;

    public class EditRoomScreen : EditorScreen
    {
        public Room RoomItem { get; set; }

        public EditRoomScreen(Room r)
        {
            RoomItem = r;
            if (RoomItem.IsDefault())
            {
                Title = "Add room";
            }
            else
            {
                Title = "Edit room";
            }
        }

        public override string Title { get; set; }
        protected override void Draw()
        {
            Form<Room> editor = new();

            editor.TextBox("Room name", "Name");
            editor.TextBox("Description", "Description");

            editor.Edit(RoomItem);

            Quit();
        }
    }
}