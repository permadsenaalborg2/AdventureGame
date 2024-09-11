namespace Adventure
{
    public class Player
    {
        public Room CurrentRoom { get; set; }
        public Inventory Player_Inventory { get; init; }
        public Player(Room startingRoom)
        {
            CurrentRoom = startingRoom;
            Player_Inventory = new();
        }

        public override string ToString()
        {
            return "Spiller " + Player_Inventory + Environment.NewLine;
        }

        public string? GameStatus()
        {
            // there are two ways to win the game
            if (Player_Inventory.Count(i => i.Name.Contains("øl")) >= 5)
                return "Du har fået mere end 4 øl. Du har vundet spillet";

            if (Player_Inventory.Exists(i => i.Name == "book_test") && (Player_Inventory.Exists(i => i.Name == "duck")))
                return "Du har fundet Pers gummiand og bogen om Test Driven Developent. Din lykke er gjort. Du har vundet spillet.";

            // and one way to loose
            if (Player_Inventory.Exists(i => i.Name == "book_ci"))
                return "Du har stjålet Pers bogen om Continuous Delivery og blev opdaget! Du har tabt spillet.";


            return null;
        }
    }
}