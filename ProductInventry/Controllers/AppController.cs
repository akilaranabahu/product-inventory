 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductInventry.ViewModels;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using ProductInventry.Data.Entities;
using ProductInventry.Data;


namespace ProductInventry.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index(Guid productID)

        {
            ViewBag.id = productID;
            // throw new InvalidOperationException("Bad things happen");
           
            return View();
        }

        [HttpGet("app/GetAddPage")]
        public IActionResult GetAddPage()
        {
            // throw new InvalidOperationException("Bad things happen");

            return View();
        }

        [HttpPost("app/GetAddPage")]
        public IActionResult GetAddPage(AddProductViewModel model)
        {
            ProductContext db = new ProductContext();

            AddProduct AP = new AddProduct();
            
            OrderProduct OPD = new OrderProduct();

            AP.Name = model.Name;
            AP.Price = model.Price;


            //this.CreateOrder(AP);
            db.AddProducts.Add(AP);
            db.SaveChanges();


            return RedirectToAction("ShowProductList", new { productID = AP.Id });


            //return  RedirectToAction("GetOrderPage", "App", new { oreder});

            


        }

       


        public IActionResult GetOrderPage(Guid OrderId)
        {
          
            //ProductContext db = new ProductContext();


            //var order = db.AddOrders.Last();
            //var orderList = new Dictionary<Guid, AddProduct>();

            //var orderProduct = db.OrderProducts.Where(op => op.AddProductId == productID).ToList();
            //foreach (var item in orderProduct)
            //{
            //    var product = db.AddProducts.FirstOrDefault(ap => ap.Id == item.AddProductId);
            //    var order = db.AddOrders.FirstOrDefault(op => op.Id == item.AddOrderId);
            //    orderList.Add(item.AddOrderId, product);
            //    ViewBag.name = product.Name;
            //    ViewBag.price = product.Price;
            //    ViewBag.id = order.Id;
            //}
            ProductContext db = new ProductContext();
            AddProduct AP = new AddProduct();
            AddOrder AO = new AddOrder();
           //var Id= this.CreateOrder();
            //ViewBag.id = Id;
            //var orderId = AP.OrderProducts.Select(op => op.AddOrderId ).Where(a=>true);
            var Ap = db.AddProducts.ToList();







            //var orderProduct = db.OrderProducts.Where(op => op.AddOrderId == order.Id).ToList();
            //foreach (var item in orderProduct)
            //{
            //    var product = db.AddProducts.FirstOrDefault(ap => ap.Id == item.AddProductId);
            //    orderList.Add(item.AddOrderId, product);
            //    ViewBag.name = product.Name;
            //    ViewBag.price = product.Price;
            //}

            //ViewBag.orderId = order.Id;CreateOrder


            //this.GetAddProductPage(model);
            return View(Ap);

        }

        public Guid CreateOrder()
        {
            ProductContext db = new ProductContext();

            AddOrder AO = new AddOrder();
            OrderProduct OPD = new OrderProduct();

            AO.Date = DateTime.Now;
           // OPD.AddOrder = AO;
            //OPD.AddProduct = addProduct;

            db.AddOrders.Add(AO);
            //db.OrderProducts.Add(OPD);
            db.SaveChanges();
            //return RedirectToAction("GetOrderPage", "App", new {result=AO.Id });
            return AO.Id;
           
           
        }

        //[HttpPost("app/GetOrderPage")]
        public IActionResult saveQuantity(SaveQuantityViewModel model, Guid productID)
        {
            ProductContext db = new ProductContext();
            OrderProduct OP = new OrderProduct();

            var orderproduct = db.OrderProducts.FirstOrDefault(op => op.AddProductId == productID);
            orderproduct.Quantity = model.Quantity.Value;
            OP.Quantity = orderproduct.Quantity;
            OP.AddProductId = productID;
            OP.AddOrderId = orderproduct.AddOrderId;

        
            
           
            db.OrderProducts.Add(OP);
            db.SaveChanges();


           

            return RedirectToAction("GetProductListPage", "App",new { productID = OP.AddProductId }); ;
        }

       
        public IActionResult GetProductListPage(Guid productID)
          
        {
            ProductContext db = new ProductContext();
            OrderProduct OP = new OrderProduct();
            var orderList = new Dictionary<Guid, AddProduct>();

            var orderProduct = db.OrderProducts.Where(op => op.AddProductId == productID).ToList();
            foreach (var item in orderProduct)
            {
                var product = db.AddProducts.FirstOrDefault(ap => ap.Id == item.AddProductId);
                var order = db.AddOrders.FirstOrDefault(op => op.Id == item.AddOrderId);
                //orderList.Add(item.AddOrderId, product);
                ViewBag.name = product.Name;
                ViewBag.price = product.Price;
                ViewBag.id = order.Id;
                ViewBag.quantity = item.Quantity;
                var Quantity = item.Quantity;
                ViewBag.fullprice = Quantity * product.Price;




            }

            

            return View();
        }

        public IActionResult ShowProductList( Guid  productID)
        {

            ProductContext db = new ProductContext();
           var Ap = db.AddProducts.ToList();
            var productshowname = db.AddProducts.Select(p => p.Name).Where(a => true).ToList();
            var productshowprice = db.AddProducts.Select(a => a.Price).Where(ap => true).ToList();
            ViewBag.namelist = productshowname;
            ViewBag.pricelist = productshowprice;
            ViewBag.AP = Ap;
          

            
          
                

            return View(Ap);
        }

        public IActionResult Navigate() {
            
                return RedirectToAction("Index");
            }

        [HttpPost("app/GetOrderPage")]
        public IActionResult SaveOrder(List<SaveQuantityViewModel> model,Guid Id)
        {
            ProductContext db = new ProductContext();
            ListOrder LO = new ListOrder();
            
            var OId = this.CreateOrder();
            AddOrder Ao = new AddOrder();
            AddProduct Ap = new AddProduct();
           var savequantity = model.Where(ap => ap.Quantity > 0).ToList();
            foreach(var item in savequantity)
            {
                var saveid = item.Id;
                var saveQun = item.Quantity;

                OrderProduct OPD = new OrderProduct();
                OPD.AddOrderId =OId ;
                OPD.AddProductId = saveid;
                OPD.Quantity = item.Quantity.HasValue ? item.Quantity.Value : 0;

                db.OrderProducts.Add(OPD);
            }
            db.SaveChanges();

            var productlist = new Dictionary<Guid, AddProduct>();
            var orderproduct = db.OrderProducts.Where(op => op.AddOrderId == OId).ToList();
            foreach(var item in orderproduct)
            {
                var addproduct = db.AddProducts.FirstOrDefault(ap => ap.Id == item.AddProductId);
                productlist.Add(item.AddProductId, addproduct);
            }
            //ViewBag.quantity =orderproduct.Select(op=>op.Quantity).ToList();
            var opq= orderproduct.Select(op => op.Quantity).ToList();
            var opqr = orderproduct;
            var opr = orderproduct.Select(op => op.Quantity).Count();
            ViewBag.id = OId;
            //ViewBag.name =productlist.Select(pl => pl.Value.Name).ToList();
            //ViewBag.price = productlist.Select(pl => pl.Value.Price).ToList();
            var SaveOrder = productlist.Select(pl => pl.Value).ToList();
            var opp= productlist.Select(pl => pl.Value.Price).ToList();
            var totalprice = 0;
            for (var i = 0; i< opr; i++)
            {
                var total = opq[i] * opp[i];
                totalprice = total + totalprice;
                ViewBag.totalprice = totalprice;
            }

            LO.OrderID = OId;
            LO.TotalPrice = totalprice;
            db.ListOrders.Add(LO);
            db.SaveChanges();

            var vModel = new SaveOrderViewModel(SaveOrder,opqr);

            return View(vModel);
        }



        public IActionResult OrderList()
        {
            ProductContext db = new ProductContext();
            var Ol = db.ListOrders.ToList();

            return View(Ol);
        }

        public IActionResult ShowOrder(Guid id)

        {
            ProductContext db = new ProductContext();
            ListOrder LO = new ListOrder();
            var OId = id;
            var productlist = new Dictionary<Guid, AddProduct>();
            var orderproduct = db.OrderProducts.Where(op => op.AddOrderId == OId).ToList();
            foreach (var item in orderproduct)
            {
                var addproduct = db.AddProducts.FirstOrDefault(ap => ap.Id == item.AddProductId);
                productlist.Add(item.AddProductId, addproduct);
            }
            //ViewBag.quantity =orderproduct.Select(op=>op.Quantity).ToList();
            var opq = orderproduct.Select(op => op.Quantity).ToList();
            var opqr = orderproduct;
            var opr = orderproduct.Select(op => op.Quantity).Count();
            ViewBag.id = OId;
            //ViewBag.name =productlist.Select(pl => pl.Value.Name).ToList();
            //ViewBag.price = productlist.Select(pl => pl.Value.Price).ToList();
            var SaveOrder = productlist.Select(pl => pl.Value).ToList();
            var opp = productlist.Select(pl => pl.Value.Price).ToList();
            var totalpricelist = db.ListOrders.Where(lo => lo.OrderID == OId).ToList();
            foreach(var item in totalpricelist)
            {
                var totalprice = item.TotalPrice;
                ViewBag.totalprice = totalprice;
            }

            var vModel = new SaveOrderViewModel(SaveOrder, opqr);
            return View(vModel);
        }


        //[HttpGet("app/GetOrderList")]
        //public IActionResult GetOrderList()
        //{
        //    return View();
        //}


        //[HttpPost("app/GetOrderList")]
        //public IActionResult GetOrderList(AddOrderViewModel model)
        //{
        //    ProductContext db = new ProductContext();
        //    AddOrder AO = new AddOrder();

        //    AO.Date = model.Date;

        //    db.AddOrders.Add(AO);

        //    db.SaveChanges();
        //    return View();
        //}

        //[HttpPost("app/GetAddPage")]
        //public IActionResult CreateOrder()
        //{
        //    ProductContext db = new ProductContext();
        //    AddOrder AO = new AddOrder();
        //    AO.Date = System.DateTime.Now;
        //    return null;

        //}

    }

   


    
}
