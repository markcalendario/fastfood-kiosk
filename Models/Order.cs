using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JollibeeOrderingSystem.Models
{
    public class OrderItem : Item
    {
        public int Quantity { get; set; }

        public OrderItem(string id, string name, float price, string image, int quantity) : base(id, name, price, image)
        {
            this.Quantity = quantity;
            this.Price = price * quantity;
            this.Image = image;
            this.Id = id;
            this.Name = name;
        }
    }

    public class Order
    {
        public string? Type { get; set; }
        public List<OrderItem> Items { get; set; }
        public int Id { get; set; }
        public Order(int Id)
        {
            this.Id = Id;
            Items = [];
        }

        public void PlaceOrder(OrderItem item)
        {
            Items.Add(item);
        }

        public float GetTotalPrice()
        {
            float total = 0.0F;

            foreach(OrderItem item in Items)
            {
                total += item.Price;    
            }

            return total;
        }
    }
}
