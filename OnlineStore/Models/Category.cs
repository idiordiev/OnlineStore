using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    /// <summary>
    /// Represents category of product.
    /// </summary>
    public class Category
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("NameUA")]
        public string NameUA { get; set; }
        
        [DisplayName("NameRU")]
        public string NameRU { get; set; }
        
        [DisplayName("NameEN")]
        public string NameEN { get; set; }
        
        [DisplayName("Products")]
        public List<Product> Products { get; set; }
    }
}