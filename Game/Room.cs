namespace Adventure
{
    public class Room
    {
        public const string DefaultRoomName = "<name>";
        public const string DefaultRoomDesc = "<description>";
        public string Name { get; init; }
        public string Description { get; init; }
        public ExitDictionary Exits { get; set; }
        private Inventory Room_Inventory { get; init; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Exits = new ();
            Room_Inventory = new();
        }

        public Room() : this(DefaultRoomName, DefaultRoomDesc) { }

        public override string ToString()
        {
            return Name;
        }
        /*
        public List<RoomExit> ExitList()
        {
            List<RoomExit> result = new();
            foreach (var roomexit in Exits)
            {
                result.Add(roomexit);
            }

            return result;
        }*/

        public bool IsDefault()
        {
            return (Name.Equals(DefaultRoomName) && Description.Equals(DefaultRoomDesc));
        }

        public void AddItem(Item it)
        {
            Room_Inventory.Add(it);
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

        public bool ValidExit(string desc)
        {
            return Exits.ContainsKey(desc);
        }
        public Room GetNextRoom(string desc)
        {
            return Exits[desc];
        }
        public bool ValidItem(string name)
        {
            return Room_Inventory.Exists(i => i.Name == name);
        }
        public void MoveItem(string name, Player p)
        {
            Item it = Room_Inventory.Single(i => i.Name == name);
            p.Player_Inventory.Add(it);
            Room_Inventory.Remove(it);
        }
        public string AutoDescription()
        {
            string result = Name + ": " + Description + Environment.NewLine + Environment.NewLine; ;
            result += Exits.ToStringMultiLine() + Environment.NewLine;
            result += "Lokation " + Room_Inventory;
            return result;
        }
    }
}