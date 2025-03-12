namespace OpremiSe.Models
{
    public class KosaricaProdukt
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }

    public class ShoppingCart
    {
        public List<KosaricaProdukt> Items { get; set; } = new List<KosaricaProdukt>();

        public void AddItem(int productId, string productName, decimal price, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                Items.Add(new KosaricaProdukt
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public decimal TotalAmount => Items.Sum(i => i.Price * i.Quantity);

        public void RemoveItem(int productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }
    }


}
  
