using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserInfoRepo db;
        public UserController(IUserInfoRepo db)
        {
            this.db = db;
        }
        PizzaWebApp.Models.UserInfo u;
        List<PizzaWebApp.Models.UserInfo> userlist = new List<PizzaWebApp.Models.UserInfo>();

        public IActionResult Index()
        {
            var users = db.getUsers();
            foreach (var user in users)
            {
                u = new Models.UserInfo();
                u.Name = user.GetName(user.firstname,user.lastname);
                u.Phonenumber = user.phonenumber;
                u.Username = user.username;
                u.Num = user.userId;
                userlist.Add(u);
            }
            return View(userlist);  
        }
        //=============================================================

        public IActionResult Show()
        {
            var users = db.getUsers();
            foreach (var user in users)
            {
                u = new Models.UserInfo();
                u.Name = user.GetName(user.firstname, user.lastname);
                u.Phonenumber = user.phonenumber;
                u.Username = user.username;
                u.Num = user.userId;
                userlist.Add(u);
            }
            return View(userlist);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, PizzaWebApp.Models.UserInfo user)
        {
            Domain.UserInfo dmc = new UserInfo();
            dmc.firstname = user.firstname;
            dmc.lastname = user.lastname;
            dmc.phonenumber = user.Phonenumber;
            dmc.username = user.Username;
            dmc.password = user.password;
            

            try
            {
                db.Add(dmc);
                db.save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {   
                return View();
            }
        }
        //==================================================================

       public ViewResult Login()
        {
            return View();
        }  
        [HttpPost]
        public ActionResult Login(IFormCollection collection, PizzaWebApp.Models.UserInfo user)
        {
            Domain.UserInfo dmc = new UserInfo();
            dmc.firstname = user.firstname;
            dmc.lastname = user.lastname;
            dmc.username = user.Username;
            dmc.password = user.password;
            dmc.phonenumber = user.Phonenumber;
            dmc.userId = db.getUserId(user.Username);
            try
            {
                //ought to redirect to pizzabuy

                if (db.Login(dmc.username, dmc.password) != 0 && dmc.userId!=0)
                    return RedirectToRoute(new { controller  = "Restaurant", action = "Index" , id=dmc.userId});
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }


    }
}