namespace Adventure
{
    public class RoomExit : Tuple<string, Room>
    {
        public RoomExit(string item1, Room item2) : base(item1, item2)
        {
        }

        public override string ToString()
        {
            return $"[{Item1}] til {Item2}";
        }
    }
}