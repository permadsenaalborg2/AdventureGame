namespace Adventure

{
    public class Player : IHasInventory
    {
        public Room CurrentRoom { get; set; }
        public Inventory Inventory { get; set; }
        public Player(string name, Room startingRoom)
        {
            CurrentRoom = startingRoom;
            Inventory = new();
            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Inventory + Environment.NewLine;
        }

        public string Name { get; init; }

        public string? GameStatus()
        {
            // there are two ways to win the game
            if (Inventory.Count(i => i.Name.Contains("øl")) >= 5)
                return "Du har fået mere end 4 øl. Du har vundet spillet";

            if (Inventory.Exists(i => i.Name == "book_test") && (Inventory.Exists(i => i.Name == "duck")))
                return "Du har fundet Pers gummiand og bogen om Test Driven Developent. Din lykke er gjort. Du har vundet spillet.";

            // and one way to loose
            if (Inventory.Exists(i => i.Name == "book_ci"))
                return "Du har stjålet Pers bogen om Continuous Delivery og blev opdaget! Du har tabt spillet.";


            return null;
        }

        public bool ValidItem(string name)
        {
            return Inventory.Exists(i => i.Name == name);
        }

        public Item GetItem(string name)
        {
            return Inventory.Single(i => i.Name == name);
        }

    }
}