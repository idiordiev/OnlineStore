using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class Category
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }
    }
}