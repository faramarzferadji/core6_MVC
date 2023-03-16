using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project_shst.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_shst.Models
{
    public class ELShoppingCart2
    {
        public int Id { get; set; }
        public int ELProductsId { get; set; }
        [ForeignKey(nameof(ELProductsId))]
        [ValidateNever]
        public ELProducts? ELProducts { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; }
        [NotMapped]
        public double Price { get; set; }

        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId ")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
