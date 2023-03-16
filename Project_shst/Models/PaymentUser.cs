using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project_shst.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_shst.Models
{
    public class PaymentUser
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public string PostalCode { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CartName { get; set; }
        public int Cart_Number { get; set; }
        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId ")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
     
    }
}
