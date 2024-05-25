using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CM.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
     
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]  
        public string Author { get; set; }
        
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public Double ListPrice { get; set; }
        [Required]
        [Display(Name = "price for 1-50")]
        [Range(1,1000)]
            public Double Price { get; set; }
        [Required]
        [Display(Name = "price for 50+")]
        [Range(1 , 1000)]
        public int Price50 { get; set; }
        
        [Display(Name = "Product Image")]
        public string? ImagePath { get; set; }
        [Required]
        [Display(Name = "Created At")]
        public  DateTime CreatedAt { get; set; }

    }
}
