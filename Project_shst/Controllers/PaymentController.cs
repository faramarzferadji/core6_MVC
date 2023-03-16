using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_shst.Models;
using Project_shst.Repository.IRepository;
using System.Security.Claims;

namespace Project_shst.Controllers
{
    public class paymentController : Controller
    {
        private readonly IUnitofWork _dbu;
      

        public paymentController(IUnitofWork dbu)

        {
            _dbu = dbu;
           

        }
        [HttpGet]
        public IActionResult Indexx()

        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var clime = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var objprolist = _dbu.payment.GetAll(includeProperties: "Pyment_method");


            return View(objprolist);
        }

        //Get
        public IActionResult Upsert11(int? id)
        {
            //ELProductsVM elproductVM = new ELProductsVM()
            PymentVM pymentVM = new PymentVM()
            {
              
                Pyment_methodLS = _dbu.py_method.GetAll().Select(
                    x => new SelectListItem
                    {
                        Text= x.Name,
                        Value = x.Id.ToString()
                    } )                  
            };


            if (id == null || id == 0)
            {


                return View(pymentVM);

            }
            else
            {
                //Update Product


                pymentVM.payment = _dbu.payment.GetFirstorDefult(x => x.Id == id);

                return View(pymentVM);
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert11(PymentVM obj)


        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var clime = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
           



            //if (ModelState.IsValid)
            //{

            if (obj.payment.Id == 0)
                {
                    _dbu.payment.Add(obj.payment);


                }
                else
                {
                    _dbu.payment.Update(obj.payment);

                }

                _dbu.Save();
                TempData["success"] = "Product Create successfully";
                TempData["successupsert"] = "Product Enter successfully";
                return RedirectToAction("Indexx");
            //}


            return View(obj);
        }
        //Get
        public IActionResult Delete(int? id)
        {

            var ProfromDbFirst = _dbu.payment.GetFirstorDefult(x => x.Id == id, includeProperties: "Pyment_method");


            return View(ProfromDbFirst);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAction(int? id)
        {
            var ProFordb = _dbu.payment.GetFirstorDefult(x => x.Id == id, includeProperties: "Pyment_method");
            _dbu.payment.Remove(ProFordb);
            _dbu.payment.Save();
            TempData["success"] = "deleted successfully";


            return RedirectToAction("Indexx");
        }
        public IActionResult Detaile(int? id)
        {

            var ProfromDb = _dbu.payment.GetFirstorDefult(x => x.Id == id, includeProperties: "Pyment_method");


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

