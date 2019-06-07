using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaWebApp.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ILocationRepository db;
        private readonly IPizzaLogicRepo db2;
        public RestaurantController(ILocationRepository db, IPizzaLogicRepo db2)
        {
            this.db = db;
            this.db2 = db2;
        }
        PizzaWebApp.Models.ResLocation loc;
        List<PizzaWebApp.Models.ResLocation> locationlist = new List<PizzaWebApp.Models.ResLocation>();


        public IActionResult Index(int id)
        {
            TempData["userid"] = id;
            TempData.Keep("userid");
            var locations = db.GetRestaurants();
            foreach (var location in locations)
            {
                
                loc = new Models.ResLocation();
                loc.City = location.City;
                loc.LocationId = location.locationID;
                loc.ResName = location.ResName;
                loc.State = location.State;
                loc.Zipcode = location.Zipcode;
                locationlist.Add(loc);
                
            } 

            return View(locationlist);
        }
        List<Models.Indiv_pizza> pizzalist = new List<Models.Indiv_pizza>();
        List<Models.Orderpizza> orderlist = new List<Models.Orderpizza>();

        //[ValidateAntiForgeryToken]
        //POST:Restaurant/ShowUsersOrders
        public IActionResult ShowUsersOrders()
        {
            
            //List<Models.Ingredients> ingredientlist = new List<Models.Ingredients>();

            var pizzas = db2.getPizzas();
            var orders = db2.getOrders();
            foreach(var order in orders)
            {
                Models.Orderpizza y = new Models.Orderpizza();
                y.locationfid_op = order.locationfid_op;
                y.orderid = order.orderid;
                y.userFID = order.userFID;
                y.Timecheck = order.Timecheck;
                y.Timecheckdefault = order.Timecheckdefault;
                if (y.locationfid_op == Int32.Parse(TempData["id"].ToString()))
                {
                    TempData.Keep("id");
                    orderlist.Add(y);
                }
            }
            foreach (var pizza in pizzas)
            {
                //foreach (var order in orderlist) {
                    //show pizza ruined from mismatch of indiv pizza in domain/webapp
                    //alternative show.
                    Models.Indiv_pizza x = new Models.Indiv_pizza();
                    x.pizzaId = pizza.pizzaId;
                    x.crustFID = pizza.crustFID.ToString();
                    x.sizeFID = pizza.sizeFID.ToString();
                    x.crustId = pizza.crustFID.GetValueOrDefault(); 
                    x.crust1 = db2.getCrustById(pizza.crustFID).crust1;
                    x.totalcost_crust = pizza.totalcost;
                    x.sizeId = pizza.sizeFID.GetValueOrDefault();
                    x.size1 = db2.getSizeById(pizza.sizeFID).size1;
                    x.totalcost_size = pizza.totalcost;
                    x.Ingredient0FID = pizza.Ingredient0FID.ToString();
                    x.Ingredient1FID = pizza.Ingredient1FID.ToString();
                    x.Ingredient2FID = pizza.Ingredient2FID.ToString();
                    x.Ingredient3FID = pizza.Ingredient3FID.ToString();
                    x.Ingredient4FID = pizza.Ingredient4FID.ToString();
                    x.count = pizza.count;
                    x.orderFID = pizza.orderFID;
                    x.totalcost = pizza.totalcost;

                    if (db2.getNextOrderId() == x.orderFID.GetValueOrDefault())
                            pizzalist.Add(x);
                //}
            }
            
            return View(pizzalist);



        }
        [HttpGet]
        public ActionResult OrderPizza()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrderPizza(IFormCollection collection, PizzaWebApp.Models.Orderpizza op)
        {
            Domain.Orderpizza dmc = new Domain.Orderpizza();

            dmc.orderid = op.orderid;
            dmc.locationfid_op = Int32.Parse(TempData["id"].ToString());
            dmc.userFID = Int32.Parse(TempData["userid"].ToString());
            dmc.Timecheck = op.Timecheckdefault;
            //dmc.Timecheckdefault = op.Timecheckdefault;
            TempData.Keep("userId");
            TempData.Keep("id");
            try
            {
                if (TempData["userid"] != null)
                {
                   // if (((DateTime)op.Timecheckdefault - (DateTime)op.Timecheck).Hours < 24)
                    //{
                        db2.AddOrder(dmc);
                        db2.Save();
                        TempData.Keep("userId");
                        return RedirectToAction("Index");

                    //}
                   // else
                   // {
                        //TempData.Keep();
                        //return View();

                   // }
                }
                else
                {
                    TempData.Keep();
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Pizzabuilder()
        {
            var ip = new PizzaWebApp.Models.Indiv_pizza();
            ip.Ingredient0FID = "none";
            ip.Ingredient1FID = "none";
            ip.Ingredient2FID = "none";
            ip.Ingredient3FID = "none";
            ip.Ingredient4FID = "none";
            
            return View(ip);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pizzabuilder(Models.Indiv_pizza ip, int? id)
        {            
           
            Domain.Indiv_pizza dmc = new Domain.Indiv_pizza();

            dmc.count = ip.count;
            dmc.crustFID = db2.CrustStringToID(ip.crustFID);
            dmc.Ingredient0FID = db2.IngredientStringToId(ip.Ingredient0FID);
            dmc.Ingredient1FID = db2.IngredientStringToId(ip.Ingredient1FID);
            dmc.Ingredient2FID = db2.IngredientStringToId(ip.Ingredient2FID);
            dmc.Ingredient3FID = db2.IngredientStringToId(ip.Ingredient3FID);
            dmc.Ingredient4FID = db2.IngredientStringToId(ip.Ingredient4FID);
            //need to set orderid to +1 of largest order id... not the proper way since it has a 
            dmc.orderFID = db2.getNextOrderId();
            if(id!=null)
                TempData["id"] = id;    
            dmc.pizzaId = ip.pizzaId;
            dmc.sizeFID = db2.SizeStringToID(ip.sizeFID);
            //get price from stringid -> id -> db -> price
            dmc.totalcost = (db2.getIngredientsById(db2.IngredientStringToId(ip.Ingredient0FID)).cost_ing +
                db2.getIngredientsById(db2.IngredientStringToId(ip.Ingredient1FID)).cost_ing +
                db2.getIngredientsById(db2.IngredientStringToId(ip.Ingredient2FID)).cost_ing +
                db2.getIngredientsById(db2.IngredientStringToId(ip.Ingredient3FID)).cost_ing +
                db2.getIngredientsById(db2.IngredientStringToId(ip.Ingredient4FID)).cost_ing +
                db2.getCrustById(db2.CrustStringToID(ip.crustFID)).totalcost_crust +
                db2.getSizeById(db2.SizeStringToID(ip.sizeFID)).totalcost_size)*ip.count;
            TempData.Keep("id");
            if (dmc.totalcost > 5000 || ip.count > 100)
            {
                //ought to have message saying cost is over 5000.
                return View();
            }
            IEnumerable<Inventory>  inv = db2.getInventory();
            foreach(var i in inv)
            {
                if (i.resfId == Int32.Parse(TempData["id"].ToString()) && ((i.FkIngredient == dmc.Ingredient0FID && dmc.Ingredient0FID!= 14) || (i.FkIngredient == dmc.Ingredient1FID && dmc.Ingredient1FID!=14) || (i.FkIngredient == dmc.Ingredient2FID&& dmc.Ingredient2FID !=14) || (i.FkIngredient == dmc.Ingredient3FID && dmc.Ingredient3FID !=14) || (i.FkIngredient == dmc.Ingredient4FID &&dmc.Ingredient4FID !=14)))
                {
                    i.stock = i.stock - ip.count;
                    db2.UpdateStock(i);
                    TempData.Keep("id");
                }
            }   
            //TempData.Keep();




            //still need to update stock ... this will be done on db.save()
            //still need to update order ... this will have its own view
            try
            {
                db2.AddPizza(dmc);
                db2.Save();
                return RedirectToAction("OrderPizza");
            }
            catch
            {
                return View();
            }
        }

        Models.Inventory x;
        List<Models.Inventory> invlist = new List<Models.Inventory>();

        public IActionResult Inventory(int id)
        {
            var invs = db2.getInventory();
            foreach (var inv in invs)
            {
                x = new Models.Inventory();
                x.cost_inv = inv.cost_inv;
                x.FkIngredient = inv.FkIngredient;
                x.invId = inv.invId;
                x.resfId = inv.resfId;
                x.stock = inv.stock;
                if(id == x.resfId)
                    invlist.Add(x);
            }
            return View(invlist);

        }

    }
}