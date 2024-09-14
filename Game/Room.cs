namespace Adventure
{
    public class Room : IHasInventory
    {
        public const string DefaultRoomName = "<name>";
        public const string DefaultRoomDesc = "<description>";
        public string Name { get; init; }
        public string Description { get; init; }
        public ExitDictionary Exits { get; set; }
        public Inventory Inventory { get; set; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Exits = new ();
            Inventory = new();
        }

        public Room() : this(DefaultRoomName, DefaultRoomDesc) { }

        public override string ToString()
        {
            return Name;
        }
       
        public bool IsDefault()
        {
            return (Name.Equals(DefaultRoomName) && Description.Equals(DefaultRoomDesc));
        }

        public void AddItem(Item it)
        {
            Inventory.Add(it);
        }

        public void AddExit(string desc, Room room)
        {
            Exits.Add(desc, room);
        }
        
        public void AddTwoWayExit(string desc, string back, Room room)
        {
            Exits.Add(desc, room);
            room.AddExit(back, this);
        }

        public Room GetNextRoom(string desc)
        {
            return Exits[desc];
        }
        public bool ValidItem(string name)
        {
            return Inventory.Exists(i => i.Name == name);
        }
        public bool ValidExit(string name)
        {
            return Exits.ContainsKey(name);
        }
        public Item GetItem(string name)
        {
            return Inventory.Single(i => i.Name == name);
        }

        public string AutoDescription()
        {
            string result = Name + ": " + Description + Environment.NewLine + Environment.NewLine; ;
            result += Exits.ToStringMultiLine() + Environment.NewLine;
            result += "Lokation " + Inventory;
            return result;
        }
    }
}