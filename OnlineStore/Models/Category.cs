using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    /// <summary>
    /// Represents category.
    /// </summary>
    public class Category
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }
        
        [DisplayName("GoodsList")]
        public List<Goods> Goods { get; set; }
    }
}