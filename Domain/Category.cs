using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Category
    {
        [DisplayName("Category Id")]
        [Key]
        public int CategoryId { get; set; }
        [DisplayName("Category Description")]
        public string Description { get; set; }
    }
}
