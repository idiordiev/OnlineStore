using System;

namespace OnlineStore.Models
{
    /// <summary>
    /// Represents localized product. Contains data in required language.
    /// </summary>
    public class LocalizedProduct
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public decimal Price { get; set; }
        
        public string DescriptionShort { get; set; }
        
        public string DescriptionFull { get; set; }
        
        public string ImageLink { get; set; }
        
        public DateTime DateAdded { get; set; }
        
        public int Views { get; set; }
        
        public bool IsInCart { get; set; }
        
        public bool IsInWishlist { get; set; }
    }
}