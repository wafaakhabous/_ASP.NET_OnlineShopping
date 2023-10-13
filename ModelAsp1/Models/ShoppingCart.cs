namespace ModelAsp1.Models
{

    public class ShoppingCart //TOUT PANIER
    {
        public List<CartItem> Items { get; set; } //panier composé de 1..* items

        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }

        public void AddItem(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity; // si l item existe deja dans le panier on augmente que sa nouvelle quantité
            }
            else//sinon on ajoute un nouveu item dans le panier avec la quantité specifiée lors de l'ajout dans le panier
            {
                var newItem = new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Title,
                    Price = product.Price,
                    Quantity = quantity
                };
                Items.Add(newItem);
            }
        }

        public void RemoveItem(int productId)
        {
            // remove items from panier
            var itemToRemove = Items.FirstOrDefault(item => item.ProductId == productId);

            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

    }
}
