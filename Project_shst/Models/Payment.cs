using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project_shst.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_shst.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId ")]
        [ValidateNever]
        public ApplicationUser? ApplicationUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public int Pymeny_methodId { get; set; }
        [ForeignKey("Pymeny_methodId ")]
        [ValidateNever]
        public Pyment_method? Pyment_method { get; set; }
        public int Cart_Number { get; set; }


    }
}
