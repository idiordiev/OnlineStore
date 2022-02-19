using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    /// <summary>
    /// Represents receipt.
    /// </summary>
    public class Receipt
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("UserId")]
        public string UserId { get; set; }
        
        [DisplayName("User")]
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        [DisplayName("Products")]
        public List<Product> Products { get; set; }

        [DisplayName("DateTime")]
        public DateTime Date { get; set; }
        
        [DisplayName("Comment")]
        public string Comment { get; set; }
        
        [DisplayName("City")] 
        public string City { get; set; }
        
        [DisplayName("Address")]
        public string Address { get; set; }
    }
}