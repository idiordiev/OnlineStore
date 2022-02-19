using System.Collections.Generic;

namespace OnlineStore.Models.ViewModels
{
    public class OrderViewModel
    {
        public string City { get; set; }
        
        public string Address { get; set; }
        
        public List<LocalizedProduct> Products { get; set; }
        
        public string Comment { get; set; }
    }
}