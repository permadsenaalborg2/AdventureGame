namespace Adventure.Editor
{
    using TECHCOOL.UI;

    public class EditItemScreen : EditorScreen
    {
        public Item CurrentItem { get; set; }
        private readonly List<Room> roomlist;

        public EditItemScreen(Item i, List<Room> myroomlist)
        {
            roomlist = myroomlist;
            CurrentItem = i;
            if (i.IsDefault())
            {
                Title = "Add Item";
            }
            else
            {
                Title = "Edit Item";
            }
        }

        public override string Title { get; set; }
        protected override void Draw()
        {
            Form<Item> editor = new();

            editor.TextBox("Item name", "Name");
            editor.TextBox("Description", "Description");

            var room_dict = new Dictionary<string, object>();
            foreach (var room in roomlist)
            {
                room_dict[room.Name] = (object)
                    room.Name;
            }
            editor.SelectBox("Location", "Location", room_dict);

            if (editor.Edit(CurrentItem))
            {
                CurrentItem.MoveToLocation(roomlist);
            }

            Quit();
        }
    }
}