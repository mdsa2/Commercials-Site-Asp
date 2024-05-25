using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CM.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("CategoryName")]
        public string Name { get; set; }
        [DisplayName("the Order Number")]
        [Range(1, 100,ErrorMessage ="the number should between 1-100")]
        public int MyOrder { get; set; }

       
    }
}
