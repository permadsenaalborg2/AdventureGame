namespace Adventure
{
    public class ExitDictionary : Dictionary<string, Room>
    {
        public string ToStringMultiLine()
        {
            return ToStringImpl(multiline: true);
        }

        public override string ToString()
        {
            return ToStringImpl(multiline: false);
        }

        private string ToStringImpl(bool multiline)
        {
            string newline = (multiline ? Environment.NewLine : "");
            string result = "";

            foreach (var roomexit in this)
            {
                result += roomexit + newline;
            }

            return result;
        }

        public List<RoomExit> ExitList()
        {
            List<RoomExit> result = new();
            foreach (var (exitname, room) in this)
            {
                result.Add(new RoomExit($"{exitname}: {room.Name}"));
            }

            return result;
        }

        public Dictionary<string, object> OptionDict()
        {
            Dictionary<string, object> result = new();
            foreach (var (exitname, room) in this)
            {
                result[exitname] =  (object) room;
            }

            return result;
        }

    }
}