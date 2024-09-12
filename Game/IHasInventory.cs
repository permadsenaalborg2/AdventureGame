
namespace Adventure
{
    public interface IHasInventory
    {
        public Inventory Inventory { get; set; }
        public string Name { get; init; }
    }
}
