using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    /// <summary>
    /// Represents discounted product. 
    /// </summary>
    public class DiscountedGoods
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
        
        [DisplayName("GoodsId")]
        public int GoodsId { get; set; }
        
        [DisplayName("Goods")]
        [ForeignKey("GoodsId")]
        public Goods Goods { get; set; }
        
        [DisplayName("NewPrice")]
        public decimal NewPrice { get; set; }
        
        [DisplayName("DateFrom")]
        public DateTime DateFrom { get; set; }
        
        [DisplayName("DateTo")]
        public DateTime DateTo { get; set; }
    }
}