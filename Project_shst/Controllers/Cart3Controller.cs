using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_shst.Models;
using Project_shst.Repository.IRepository;
using System.Security.Claims;

namespace Project_shst.Controllers
{
    [Authorize]
    public class Cart3Controller : Controller

    {
        private readonly IUnitofWork _unitofWork;
        private object payPalService;
        private object serviceTransportPC;

        public Facture3 Facture3 { get; set; }
        public pricequotesPricequotePricedetails SendPrice { get; private set; }

        public Cart3Controller(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var clime = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            Facture3 = new Facture3()
            {
                LstCart = _unitofWork.ELShoppingCart2.GetAll(
                    x => x.ApplicationUserId == clime.Value, includeProperties: "ELProducts")
                 

            };


            foreach (var item in Facture3.LstCart)
            {
                item.Price = GetPrice(item.ELProducts.Price, item.ELProducts.Price12, item.Count);
                Facture3.GroundTotal += (item.Count * item.Price);
                Facture3.GroundCount += item.Count;
            }


            return View(Facture3);

        }
        public IActionResult Shiping()
        {
            /* bool success = false;*/ // result of your validation logic
                                       //try
                                       //{
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var clime = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            Facture3 = new Facture3()
            {
                LstCart = _unitofWork.ELShoppingCart2.GetAll(x => x.ApplicationUserId == clime.Value,
                includeProperties: "ELProducts"),
                ShipBody = new()

            };
           
            Facture3.ShipBody.ApplicationUser =
            _unitofWork.applicationUser.GetFirstorDefult(x => x.Id == clime.Value);
            Facture3.ShipBody.FirstName = Facture3.ShipBody.ApplicationUser.FirstName;
            Facture3.ShipBody.LastName = Facture3.ShipBody.ApplicationUser.LastName;
            Facture3.ShipBody.Email = Facture3.ShipBody.ApplicationUser.Email;
            Facture3.ShipBody.PhoneNumber = Facture3.ShipBody.ApplicationUser.PhoneNumber;


            foreach (var item in Facture3.LstCart)
            {
                item.Price = GetPrice(item.ELProducts.Price, item.ELProducts.Price12, item.Count);
                Facture3.GroundTotal += (item.Count * item.Price);
                Facture3.GroundCount += item.Count;
            }
            TempData["success"] = "Add new item to Shipping is Successfully";
        


            return View(Facture3);
        }
        public ActionResult Pay()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var clime = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            Facture3 = new Facture3()
            {
                LstCart = _unitofWork.ELShoppingCart2.GetAll(x => x.ApplicationUserId == clime.Value,
                includeProperties: "ELProducts"),
                paymentUser = new()

            };

            Facture3.paymentUser.ApplicationUser =
          _unitofWork.applicationUser.GetFirstorDefult(x => x.Id == clime.Value);
            Facture3.paymentUser.FirstName = Facture3.paymentUser.ApplicationUser.FirstName;
            Facture3.paymentUser.LastName = Facture3.paymentUser.ApplicationUser.LastName;
            Facture3.paymentUser.Email = Facture3.paymentUser.ApplicationUser.Email;
            Facture3.paymentUser.PhoneNumber = Facture3.paymentUser.ApplicationUser.PhoneNumber;
           
            foreach (var item in Facture3.LstCart)
            {
                item.Price = GetPrice(item.ELProducts.Price, item.ELProducts.Price12, item.Count);
                Facture3.GroundTotal += (item.Count * item.Price);
                Facture3.GroundCount += item.Count;
            }
            //Payment payment = new();
            PaymentUser paymentUser = new();
            string sOriginePostalCode = "J4Y3A9"; //CODE POSTAL DE LA COMPAGNIE
            //string sDestinationPostalCode = Facture3.Payment.ApplicationUser.PostalCode; // CODE POSTAL DU CLIENT
            string sDestinationPostalCode = "J3G0V5"/*Facture3.payment.ApplicationUser.Email*/;
            CanadaPostServic2 canadaPostServic = new CanadaPostServic2();
            //var p = canadaPostServic.GetPosteCanadaRate(sOriginePostalCode, sDestinationPostalCode, 1.00m);
            pricequotes p = canadaPostServic.GetPosteCanadaRate(sOriginePostalCode, sDestinationPostalCode, 1.00m);
            DateTime dtExpectedDeliveryDate;
            //ViewBag.DeliveryDate = dtExpectedDeliveryDate;
            if (serviceTransportPC != null)
            {
                //Facture3.totalPrice += Convert.ToDecimal(serviceTransportPC.pricedetails.due);
                //dtExpectedDeliveryDate = serviceTransportPC.servicestandard.expecteddeliverydate;
                //ViewBag.DeliveryDate =(Convert.ToDateTime(dtExpectedDeliveryDate));
            }

            foreach (pricequotesPricequote s in p.pricequote)
            {
                //Console.WriteLine("Price" + s.pricedetails);
                Facture3.totalPrice = Convert.ToDecimal(s.pricedetails.due);
                //Facture3.weight = Convert.ToDouble(s.weightdetails);
            }
            //decimal SendPrice = 0.0m;
            //foreach (pricequotesPricequote s in p.pricequote)
            //{
            //    //decimal price = 0.0m;
            //    //if (decimal.TryParse(s.pricedetails, out price))
            //    //{
            //    //    SendPrice += price;
            //    //}
            //    //else
            //    //{
            //    //    // Handle the case where the value could not be parsed as a decimal
            //    //}
            //    //Facture3.payment.Amount = s.pricedetails;
            //    Console.WriteLine("Price" + s.pricedetails);
            //    //Facture3.totalPrice = Convert.ToDecimal(s.pricedetails);
            //    //Facture3.weight = Convert.ToDouble(s.weightdetails);
            //    //SendPrice += Convert.ToDecimal(s.pricedetails);
            //    //SendPrice += s.pricedetails;
            //}



            TempData["success"] = "Add new item to Shipping is Successfully";
            return View(Facture3);

        }
        [HttpPost("PayPalOrder")]
        public async Task<IActionResult> PayPalOrder(decimal amount)
        {
            //var result = await payPalService.CreateOrderAsync(amount);

            return Ok(/*result*/);
        }
        public IActionResult Plus(int cartId)
        {
            var cart = _unitofWork.ELShoppingCart2.GetFirstorDefult(x => x.Id == cartId);
            _unitofWork.ELShoppingCart2.IncrementCount(cart, 1);
            _unitofWork.Save();
            TempData["success"] = "Adding Successfully";
            return RedirectToAction("Index");


        }
        public IActionResult Minus(int cartId)
        {

            var cart = _unitofWork.ELShoppingCart2.GetFirstorDefult(x => x.Id == cartId);
            if (cart.Count <= 1)
            {
                _unitofWork.ELShoppingCart2.Remove(cart);

            }
            else
            {
                _unitofWork.ELShoppingCart2.DecrementCount(cart, 1);
            }

            _unitofWork.Save();
            TempData["success"] = "Minus Successfully";
            return RedirectToAction("Index");


        }
        public IActionResult Remove(int cartId)
        {
            var cart = _unitofWork.ELShoppingCart2.GetFirstorDefult(x => x.Id == cartId);
            _unitofWork.ELShoppingCart2.Remove(cart);
            _unitofWork.Save();
            TempData["success"] = "Remove Successfully";
            return RedirectToAction("Index");


        }

        private double GetPrice(double price, double price12, int count)
        {
            if (count < 12)
            {
                return price;
            }
            else
            {
                return price12;
            }




        }


    }
}
