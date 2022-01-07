using System.Collections.Generic;

namespace OnlineStore.Models.ViewModels
{
    /// <summary>
    /// Represents viewmodel for shopping cart items.
    /// </summary>
    public class ShoppingCartViewModel
    {
        public List<LocalizedProduct> Products { get; set; }
    }
}