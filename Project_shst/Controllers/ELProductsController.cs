using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_shst.Models;
using Project_shst.Repository.IRepository;

namespace Project_shst.Controllers
{
    public class ELProductsController : Controller
    {
        private readonly IUnitofWork _dbu;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ELProductsController(IUnitofWork dbu, IWebHostEnvironment hostEnvironment)

        {
            _dbu = dbu;
            _hostEnvironment = hostEnvironment;

        }
        [HttpGet]
        public IActionResult Indexx()

        {

            var objprolist = _dbu.ELProducts.GetAll(includeProperties: "Brand");


            return View(objprolist);
        }

        //Get
        public IActionResult Upsert11(int? id)
        {
            ELProductsVM elproductVM = new ELProductsVM()
            {
                elproduct = new(),
                BrandList = _dbu.Brand.GetAll().Select(
                x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };


            if (id == null || id == 0)
            {


                return View(elproductVM);

            }
            else
            {
                //Update Product


                elproductVM.elproduct = _dbu.ELProducts.GetFirstorDefult(x => x.Id == id);
                return View(elproductVM);
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert11(ELProductsVM obj, IFormFile? file)


        {



            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploud = Path.Combine(wwwRootPath, @"Images\Products");
                    var extention = Path.GetExtension(file.FileName);
                    if (obj.elproduct.Imagurl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.elproduct.Imagurl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);

                        }

                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploud, fileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.elproduct.Imagurl = @"\Images\Products\" + fileName + extention;

                }
                if (obj.elproduct.Id == 0)
                {
                    _dbu.ELProducts.Add(obj.elproduct);


                }
                else
                {
                    _dbu.ELProducts.Update(obj.elproduct);

                }

                _dbu.Save();
                TempData["success"] = "Product Create successfully";
                TempData["successupsert"] = "Product Enter successfully";
                return RedirectToAction("Indexx");
            }


            return View(obj);
        }
        //Get
        public IActionResult Delete(int? id)
        {

            var ProfromDbFirst = _dbu.ELProducts.GetFirstorDefult(x => x.Id == id, includeProperties: "Brand");


            return View(ProfromDbFirst);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAction(int? id)
        {
            var ProFordb = _dbu.ELProducts.GetFirstorDefult(x => x.Id == id, includeProperties: "Brand");
            _dbu.ELProducts.Remove(ProFordb);
            _dbu.ELProducts.Save();
            TempData["success"] = "deleted successfully";


            return RedirectToAction("Indexx");
        }
        public IActionResult Detaile(int? id)
        {

            var ProfromDb = _dbu.ELProducts.GetFirstorDefult(x => x.Id == id, includeProperties: "Brand");


            return View(ProfromDb);
        }
        //For Example
        //void calcul()
        //{
        //    Products pr = new();
        //    var newprice = _dbu.Product.GetFirstorDefult(x=>x.Id==pr.Id);
        //    //if(fromppro !=null)
        //    {
        //        newprice.Price = pr.Price * pr.ListPrice;
        //    }

        //}



    }
}

