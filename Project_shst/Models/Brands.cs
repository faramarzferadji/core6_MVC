using System.ComponentModel.DataAnnotations;

namespace Project_shst.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "BrandId")]
        public int? BrandId { get; set; }
        [Display(Name = "Brand")]
        public String? Name { get; set; }
    }
}
