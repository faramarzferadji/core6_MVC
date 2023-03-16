using System.ComponentModel.DataAnnotations;

namespace Project_shst.Models
{
    public class Pyment_method

    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Pymeny_methodId")]
        public int? Pymeny_methodId { get; set; }
        [Display(Name = "Pymeny_method")]
        public String? Name { get; set; }
    }
}
