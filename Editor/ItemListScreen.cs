using TECHCOOL.UI;

namespace Adventure.Editor
{
    public class ItemListScreen : EditorScreen
    {
        private readonly ListPage<Item> listPage;

        public ItemListScreen(List<Item> startlist)
        {
            listPage = new ListPage<Item>();
            listPage.Add(startlist);
            listPage.AddKey(ConsoleKey.F1, CreateNewItem);
            listPage.AddKey(ConsoleKey.F2, DeleteItem);
            listPage.AddKey(ConsoleKey.Escape, Quit);
            listPage.AddColumn("Name", "Name");
            listPage.AddColumn("Description", "Description", 30);
        }

        public override string Title { get; set; } = "List of items";
        protected override void Draw()
        {
            Console.WriteLine("Press F1 to add a new item");
            Console.WriteLine("Press F2 to delete an item");
            Console.WriteLine("Press ENTER to edit an item");
            Console.WriteLine("Press ESC to exit");

            Item selected = listPage.Select();

            if (selected != null)
            {
                Screen.Display(new EditItemScreen(selected));
            }
        }

        void CreateNewItem(Item _)
        {
            Item new_item = new();
            Screen.Display(new EditItemScreen(new_item));
            if (!new_item.IsDefault())
                listPage.Add(new_item);
        }

        void DeleteItem(Item item_to_delete)
        {
            if (!item_to_delete.IsDefault())
            {
                ConfirmScreen conf = new($"This will delete: {item_to_delete.Name}");
                Screen.Display(conf);
                if (conf.confirmed)
                {
                    listPage.Remove(item_to_delete);
                }
            }
        }

        void ShowHelp(Item _)
        {
            Screen.Display(new HelpScreen());
        }

        void Quit(Item _)
        {
            Quit();
        }
    }
}