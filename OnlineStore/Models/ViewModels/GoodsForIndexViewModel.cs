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
        public List<LocalizedGoods> RelatedGoodsList { get; set; }
        
        /// <summary>
        /// List of discounted goods (second row)
        /// </summary>
        public List<LocalizedGoods> DiscountGoodsList { get; set; }
        
        /// <summary>
        /// List of new goods (third row)
        /// </summary>
        public List<LocalizedGoods> NewGoodsList { get; set; }

        public GoodsForIndexViewModel()
        {
            RelatedGoodsList = new List<LocalizedGoods>();
            DiscountGoodsList = new List<LocalizedGoods>();
            NewGoodsList = new List<LocalizedGoods>();
        }
    }
}