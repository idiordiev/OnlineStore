using System.Collections.Generic;

namespace OnlineStore.Models.ViewModels
{
    /// <summary>
    /// Model for Home/Index()
    /// </summary>
    public class MainPageViewModel
    {
        /// <summary>
        /// List of related products (first row)
        /// </summary>
        public List<LocalizedProduct> RelatedProducts { get; set; } = new List<LocalizedProduct>();

        /// <summary>
        /// List of new products (third row)
        /// </summary>
        public List<LocalizedProduct> NewProducts { get; set; } = new List<LocalizedProduct>();
    }
}