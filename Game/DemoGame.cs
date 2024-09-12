namespace Adventure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class DemoGame
    {

        public List<Room> RoomList { get; set; }
        public List<Item> ItemList { get; set; }

        public Room StartRoom { get; set; }

        public DemoGame()
        {

            RoomList = new List<Room>();
            ItemList = new List<Item>();

            // Initialize sites
            Room struervej = new("Struervej", "Du står på parkeringspladsen foran Struervej");
            Room uttrupvej = new("Øster Uttrup Vej", "Du står på parkeringspladsen foran Øster Uttrup Vej");
            Room friis = new("Friis", "Du står ved indgangen til Friis");

            RoomList.AddRange([struervej, uttrupvej, friis]);

            var skod = new Item("skod", "Cigarat skod");
            struervej.AddItem(skod);

            ItemList.Add(skod);

            Room jomfru = new("Jomfru Ane Gade", "Du er endt i gaden. Der er ingen vej tilbage, men der er gratis øl!");
            RoomList.Add(jomfru);

            for (int tmp = 0; tmp < 12; tmp++)
            {
                var temp_item = new Item($"øl_{tmp}", "God øl");
                jomfru.AddItem(temp_item);
                ItemList.Add(temp_item);
            }

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

            RoomList.AddRange([adm, teacher_office, teacher_prep, canteen]);
            StartRoom = struervej;
        }

    }
}
