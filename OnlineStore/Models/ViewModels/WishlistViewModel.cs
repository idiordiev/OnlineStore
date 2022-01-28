using System.Collections.Generic;

namespace OnlineStore.Models.ViewModels
{
    /// <summary>
    /// Represents viewmodel for viewing wishlist items.
    /// </summary>
    public class WishlistViewModel
    {
        public List<LocalizedProduct> Products { get; set; }
    }
}