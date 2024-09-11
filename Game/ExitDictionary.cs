namespace Adventure
{
    public class ExitDictionary : Dictionary<string, Room>
    //public class ExitDictionary : Dictionary<RoomExit>
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
            string result = "Udgange: " + newline;

            foreach (var roomexit in this)
            {
                result += roomexit + newline;
            }

            return result;
        }
    }
}