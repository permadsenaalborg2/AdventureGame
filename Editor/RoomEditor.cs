namespace Adventure.Editor
{
    using Google.Protobuf.WellKnownTypes;
    using TECHCOOL.UI;


    public class ExitsSelectBox : SelectBox
    {
        object value;
        public override object Value { get { return value; } set { this.value = value; } }
        public Dictionary<string, object> Options = new();
        int left = 0;
        int top = 0;
        int index = 0;
        public override void Enter()
        {
            bool stop = false;
            object currentValue = value;
            Func<int, object> valueByIndex = (idx) =>
            {
                int ii = 0;
                foreach (KeyValuePair<string, object> kv in Options)
                {
                    if (ii++ == idx) return kv.Value;
                }
                return null;
            };
            do
            {
                int i = 0;

                foreach (KeyValuePair<string, object> kv in Options)
                {
                    Console.SetCursorPosition(left + LabelWidth, top + 1 + i);
                    if (i == index)
                        Screen.ColorFocus();
                    else
                        Screen.ColorDefault();

                    Console.Write("{0," + FieldWidth + "}", kv.Key + ":" + kv.Value);
                    i++;
                }


                ConsoleKey key = Console.ReadKey(true).Key;
                index = Math.Clamp(index, 0, Options.Count - 1);
                switch (key)
                {
                    case ConsoleKey.Enter:
                        value = valueByIndex(index);
                        //Need to clear and redraw this screen
                        Console.ReadLine();
                        Screen.Clear();
                        stop = true;
                        break;
                    case ConsoleKey.UpArrow:
                        index--;
                        break;
                    case ConsoleKey.DownArrow:
                        index++;
                        break;
                    case ConsoleKey.Escape:
                        stop = true;
                        break;
                }
            } while (!stop);

            Console.CursorVisible = false;
            Screen.ColorDefault();
        }

        public override void Draw(int left, int top)
        {
            this.left = left;
            this.top = top;
            Console.SetCursorPosition(left, top);
            Console.Write("{0,-" + LabelWidth + "}", Title);
            if (Focus)
                Screen.ColorFocus();
            else
                Screen.ColorField();


            Console.Write($"{{0,-{FieldWidth}}}", Value);
            Screen.ColorDefault();
        }
    }

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
            //   AddKey(ConsoleKey.F1, () => { EditExits(); });


        }

        public override string Title { get; set; }
        protected override void Draw()
        {
            Console.WriteLine("Press F1 to edit exits");
            Form<Room> editor = new();

            editor.TextBox("Room name", "Name");
            editor.TextBox("Description", "Description");
            //editor.TextBox("Exits", "Exits");
            // editor.SelectBox("Exits", "Exits", RoomItem.Exits.OptionDict());

            editor.AddField("Exits", new ExitsSelectBox { Title = "Exits", Property = "Exits", Options = RoomItem.Exits.OptionDict() });

            editor.Edit(RoomItem);

            Quit();
        }

        public void EditExits()
        {
            Screen.Display(new ExitListScreen(RoomItem));
        }

    }
}