using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyRazor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]

        public required string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Order must in the range of 1 to 100")]
        public int DisplayOrder { get; set; }
    }
}
