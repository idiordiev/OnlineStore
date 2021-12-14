using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineStore.Models.ViewModels
{
    public class GoodsAddViewModel
    {
        [Required(ErrorMessage = "PriceRequired")] 
        [DisplayName("Price")]
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
        
        [DisplayName("CategoryId")]
        public int CategoryId { get; set; }

        [DisplayName("DateAdded")]
        public DateTime DateAdded { get; set; }
        
        [DisplayName("Image")]
        public IFormFile Image { get; set; }
    }
}