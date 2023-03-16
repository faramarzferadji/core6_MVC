using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using System.ComponentModel.DataAnnotations;

namespace Project_shst.Models
{
    public class ELProducts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ELProductsId { get; set; }
        [Required]
        public string Goods { get; set; }
        [Required]
        public Double Price { get; set; }
        [Required]
        public Double Price12 { get; set; }
        [ValidateNever]
        public string? Imagurl { get; set; }
        public int BrandId { get; set; }
        [ValidateNever]
        public Brand Brand { get; set; }
    }
}
