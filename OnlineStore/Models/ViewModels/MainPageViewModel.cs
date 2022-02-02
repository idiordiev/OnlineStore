using System.Collections.Generic;

namespace OnlineStore.Models.ViewModels
{
    /// <summary>
    /// Represents viewmodel for main page.
    /// </summary>
    public class MainPageViewModel
    {
        /// <summary>
        /// List of related products (first row)
        /// </summary>
        public ICollection<LocalizedProduct> RelatedProducts { get; set; }

        /// <summary>
        /// List of new products (third row)
        /// </summary>
        public ICollection<LocalizedProduct> NewProducts { get; set; }
    }
}