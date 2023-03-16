using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project_shst.Models
{
    public class ELProductsVM
    {
        public ELProducts elproduct { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> BrandList { get; set; }
    }
}
