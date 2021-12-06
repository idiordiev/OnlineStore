using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    /// <summary>
    /// A class that represents a product in database.
    /// NEED TO ADD FIELDS OF DATE AND SOMETHING ELSE.
    /// </summary>
    public class Goods
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "PriceRequired")] 
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "NameRequired")]
        [DisplayName("NameUA")]
        public string NameUA { get; set; }
        
        [Required(ErrorMessage = "NameRequired")]
        [DisplayName("NameRU")]
        public string NameRU { get; set; }

        [Required(ErrorMessage = "NameRequired")]
        [DisplayName("NameEN")]
        public string NameEN { get; set; }
        
        [DisplayName("DescriptionShortUA")]
        public string DescriptionShortUA { get; set; }
        
        [DisplayName("DescriptionShortRU")]
        public string DescriptionShortRU { get; set; }

        [DisplayName("DescriptionShortEN")]
        public string DescriptionShortEN { get; set; }

        [DisplayName("DescriptionFullUA")]
        public string DescriptionFullUA { get; set; }
        
        [DisplayName("DescriptionFullRU")]
        public string DescriptionFullRU { get; set; }
        
        [DisplayName("DescriptionFullEN")]
        public string DescriptionFullEN { get; set; }
        
        [DisplayName("ImageLink")] 
        public string ImageLink { get; set; }
    }
}