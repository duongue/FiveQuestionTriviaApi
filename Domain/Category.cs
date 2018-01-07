using System.ComponentModel;

namespace Domain
{
    public class Category
    {
        [DisplayName("Category Id")]
        public int CategoryId { get; set; }
        [DisplayName("Category Description")]
        public string Description { get; set; }
    }
}
