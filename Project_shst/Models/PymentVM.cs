using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project_shst.Models
{
    public class PymentVM
    {
        public Payment payment { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Pyment_methodLS { get; set; }

    }
}
