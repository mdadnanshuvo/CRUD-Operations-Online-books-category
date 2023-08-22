using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [Range(1,100)]
        [Required]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
