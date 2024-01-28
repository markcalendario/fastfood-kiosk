namespace JollibeeOrderingSystem.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }

        public Item(string id, string name, float price, string image)
        {
            Id = id;
            Name = name;
            Price = price;
            Image = image;
        }
    }
    

}
