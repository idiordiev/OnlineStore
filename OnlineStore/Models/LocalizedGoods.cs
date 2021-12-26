namespace OnlineStore.Models
{
    /// <summary>
    /// Represents localized product. Contain data in required language.
    /// </summary>
    public class LocalizedGoods
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public decimal Price { get; set; }
        
        public string DescriptionShort { get; set; }
        
        public string DescriptionFull { get; set; }
        
        public string ImageLink { get; set; }
    }
}