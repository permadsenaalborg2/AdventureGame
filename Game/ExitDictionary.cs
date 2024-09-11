namespace Adventure
{
    public class ExitDictionary : Dictionary<string, Room>
    //public class ExitDictionary : Dictionary<RoomExit>
    {
        public override string ToString()
        {
            string result = "Udgange: " + Environment.NewLine;

            foreach (var roomexit in this)
            {
                result += roomexit + Environment.NewLine;
            }

            return result;
        }
    }
}