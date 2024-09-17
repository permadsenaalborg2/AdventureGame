
namespace Adventure
{
    public class Game
    {
        public List<Room> RoomList { get; }
        public Inventory ItemList { get; }

        public Room? StartRoom { get; set; }

        //to do public Player player1 { get; set;}


        public Game()
        {
            RoomList = new List<Room>();
            ItemList = new();
        }

        public void Play(Player player)
        {
            // Main game loop
            bool playing = true;
            while (playing)
            {
                playing = Round(player);
            }
        }

        public void Clear()
        {
            RoomList.Clear();
            ItemList.Clear();
            StartRoom = null;
        }

        public bool Round(Player player)
        {
            bool playing = true;
            var room = player.CurrentRoom;

            Console.WriteLine(player);
            Console.WriteLine(room.AutoDescription());

            Console.WriteLine("Mulige kommandoer: go [retning], put/take [genstand], quit");
            Console.Write("> ");

            var input = Console.ReadLine();
            if (input != null)
            {
                string[] parts = input.ToLower().Split(' ');

                string cmd = parts[0];
                string arg = "";

                if (parts.Length > 2)
                {
                    WriteNWait($"For mange parametre");
                }
                else if (parts.Length == 2)
                {
                    arg = parts[1];
                }

                if (cmd == "go")
                {
                    if (parts.Length == 2 && room.ValidExit(arg))
                    {
                        player.CurrentRoom = room.GetNextRoom(arg);
                    }
                    else
                    {
                        WriteNWait($"Du kan ikke gå denne vej: {arg}");
                    }
                }
                else if (cmd == "take")
                {
                    if (parts.Length == 2 && room.ValidItem(arg))
                    {
                        room.GetItem(arg).MoveItem(room, player);
                    }
                    else
                    {
                        WriteNWait($"Der er ingen genstand: {arg}");
                    }
                }
                else if (cmd == "put")
                {
                    if (parts.Length == 2 && player.ValidItem(arg))
                    {
                        player.GetItem(arg).MoveItem(player, room);
                    }
                    else
                    {
                        WriteNWait($"Der er ingen genstand: {arg}");
                    }
                }
                else if (cmd == "quit")
                {
                    playing = false;
                }
                else
                {
                    WriteNWait($"Ukendt kommando: {cmd}");
                }

                var status = player.GameStatus();

                if (status != null)
                {
                    WriteNWait("==============" + Environment.NewLine + status);
                    playing = false;
                }
            }
            return playing;
        }

        static void WriteNWait(string str)
        {
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}