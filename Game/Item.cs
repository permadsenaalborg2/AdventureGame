namespace Adventure
{
    public class Item
    {
        public const string DefaultItemName = "<name>";
        public const string DefaultItemDesc = "<description>";

        public string Name { get; init; }
        public string Description { get; init; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Item() : this(DefaultItemName, DefaultItemDesc) { }

        public bool IsDefault()
        {
            return (Name.Equals(DefaultItemName) && Description.Equals(DefaultItemDesc));
        }

        public string Location { get; private set; }

        public void MoveItem(IHasInventory from, IHasInventory to)
        {
            to.Inventory.Add(this);
            from.Inventory.Remove(this);
            Location = to.Name;

        }
    }
}