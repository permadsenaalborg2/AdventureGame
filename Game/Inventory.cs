namespace Adventure
{
    public class Inventory : List<Item>
    {
        public override string ToString()
        {
            string result = "Genstande: " + Environment.NewLine;
            if (this.Count == 0)
            {
                result += "<tom>";
            }
            else
            {
                foreach (var i in this)
                {
                    result += $"[{i.Name}] {i.Description}" + Environment.NewLine;
                }
            }
            return result;
        }
    }
}