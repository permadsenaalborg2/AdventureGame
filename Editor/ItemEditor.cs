namespace Adventure.Editor
{
    using TECHCOOL.UI;

    public class EditItemScreen : EditorScreen
    {
        public Item CurrentItem { get; set; }

        public EditItemScreen(Item i)
        {
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

            editor.Edit(CurrentItem);

            Quit();
        }
    }
}