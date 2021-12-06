namespace OnlineStore.Models
{
    /// <summary>
    /// Localized "Goods" model. Use for views.
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