namespace Adventure
{
    public class RoomExit 
    {
        public String A { get; set; }
        public RoomExit(string a)
        {
            A = a;
        }

        public RoomExit()
        {
            A = "<someway>:<somewhere>";
        }
    }
}

