using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Project_shst.Models;
using Project_shst.Repository.IRepository;
using System.Diagnostics;
using System.Security.Claims;

namespace Project_shst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitofWork _dbu;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IUnitofWork dbu, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _dbu = dbu;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexShop()
        {
            IEnumerable<ELProducts> Elplist = _dbu.ELProducts.GetAll(includeProperties: "Brand");



            return View(Elplist);
        }


       
        public IActionResult Details4(int ELProductsId)
        {

            ELShoppingCart2 cart = new()
            {
                Count = 1,
                ELProductsId = ELProductsId,
                ELProducts = _dbu.ELProducts.GetFirstorDefult(x => x.Id == ELProductsId, includeProperties: "Brand")
            };



            return View(cart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public JsonResult Details4(ELShoppingCart2 shopcart)
        {
            bool success = false; // result of your validation logic

            try
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var clime = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                shopcart.ApplicationUserId = clime.Value;

                ELShoppingCart2 cartDb = _dbu.ELShoppingCart2.GetFirstorDefult(
                    x => x.ApplicationUserId == clime.Value && x.ELProductsId == shopcart.ELProductsId);
                if (cartDb == null)
                    _dbu.ELShoppingCart2.Add(shopcart);
                else
                    _dbu.ELShoppingCart2.IncrementCount(cartDb, shopcart.Count);

                _dbu.Save();
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
            }



            if (success)
                return Json(new { success = true });
            else
                return Json(new { success = false });
            //return RedirectToAction("IndexShop");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}