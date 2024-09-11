using Adventure;

public class Game
{
    public Room DemoGame()
    {
        // Initialize sites
        Room struervej = new("Struervej", "Du står på parkeringspladsen foran Struervej");
        Room uttrupvej = new("Øster Uttrup Vej", "Du står på parkeringspladsen foran Øster Uttrup Vej");
        Room friis = new("Friis", "Du står ved indgangen til Friis");

        struervej.AddItem(new Item("skod", "Cigarat skod"));

        Room jomfru = new("Jomfru Ane Gade", "Du er endt i gaden. Der er ingen vej tilbage, men der er gratis øl!");
        for (int tmp = 0; tmp < 12; tmp++)
            jomfru.AddItem(new Item($"øl_{tmp}", "God øl"));

        // Add bus routes
        struervej.AddTwoWayExit("bus1", "bus1", uttrupvej);
        struervej.AddTwoWayExit("bus2", "bus2", friis);
        uttrupvej.AddTwoWayExit("bus3", "bus3", friis);

        // dead-end
        friis.AddExit("gaden", jomfru);

        // Add rooms at Struervej
        Room adm = new("Administration", "Du står i gangen i administrationsbygningen");

        adm.AddItem(new Item("duck", "Pers Rubber Duck"));

        Room teacher_prep = new("Forberedelse", "Du står i lærenes forberedelseskontor");
        Room teacher_office = new("Lærerværelset", "Du står på lærerværelset");

        teacher_office.AddItem(new Item("book_test", "Test Driven Development: By Example: Beck, Kent"));
        teacher_office.AddItem(new Item("book_ci", "Continuous Delivery: David Farley"));

        Room canteen = new("Kantinen", "Du står i kantinen på Struervej");

        canteen.AddItem(new Item("cup", "Pers kaffekop"));

        struervej.AddTwoWayExit("nord", "syd", adm);
        struervej.AddTwoWayExit("øst", "vest", canteen);

        adm.AddTwoWayExit("venstre", "højre", teacher_prep);
        adm.AddTwoWayExit("frem", "tilbage", teacher_office);

        return struervej;
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

    public bool Round(Player player)
    {
        bool playing = true;
        var room = player.CurrentRoom;

        Console.Clear();
        Console.WriteLine(player);
        Console.WriteLine(room.AutoDescription());

        Console.WriteLine("Mulige kommandoer: go [retning], take [genstand], quit");
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
                    room.MoveItem(arg, player);
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