using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_shst.Models
{
    public class ShipHead
    {
        public int Id { get; set; }
        public int ShipId { get; set; }
        [ForeignKey("ShipId")]
        [ValidateNever]
        public ShipBody ShipBody { get; set; }
        public int ELProductsId { get; set; }
        [ForeignKey(nameof(ELProductsId))]
        [ValidateNever]
        public ELProducts ELProducts { get; set; }
        public int Count { get; set; }

        public Double Price { get; set; }
    }
}
