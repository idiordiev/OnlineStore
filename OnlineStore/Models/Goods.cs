using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class Goods
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public decimal Price { get; set; }
        
        [Required]
        [DisplayName("Назва продукту")]
        public string NameUA { get; set; }
        
        [Required]
        [DisplayName("Название продукта")]
        public string NameRU { get; set; }

        [Required]
        [DisplayName("Name of product")]
        public string NameEN { get; set; }
        
        [DisplayName("Короткий опис товару")]
        public string DescriptionShortUA { get; set; }
        
        [DisplayName("Короткое описание товара")]
        public string DescriptionShortRU { get; set; }

        [DisplayName("Short description of product")]
        public string DescriptionShortEN { get; set; }

        [DisplayName("Опис товару")]
        public string DescriptionFullUA { get; set; }
        
        [DisplayName("Описание товара")]
        public string DescriptionFullRU { get; set; }
        
        [DisplayName("Description of product")]
        public string DescriptionFullEN { get; set; }
        
        [DisplayName("Link to image")] 
        public string ImageLink { get; set; }
    }
}