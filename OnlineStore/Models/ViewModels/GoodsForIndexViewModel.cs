using System.Collections.Generic;

namespace OnlineStore.Models.ViewModels
{
    /// <summary>
    /// Model for Home/Index()
    /// </summary>
    public class GoodsForIndexViewModel
    {
        /// <summary>
        /// List of related goods (first row)
        /// </summary>
        public List<Goods> RelatedGoodsList { get; set; }
        
        /// <summary>
        /// List of discounted goods (second row)
        /// </summary>
        public List<Goods> DiscountGoodsList { get; set; }
        
        /// <summary>
        /// List of new goods (third row)
        /// </summary>
        public List<Goods> NewGoodsList { get; set; }

        public GoodsForIndexViewModel()
        {
            RelatedGoodsList = new List<Goods>();
            DiscountGoodsList = new List<Goods>();
            NewGoodsList = new List<Goods>();
        }
    }
}