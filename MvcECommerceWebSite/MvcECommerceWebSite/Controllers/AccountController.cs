using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MvcECommerceWebSite.Models.ViewModel;
using MvcECommerceWebSite.Models.InputModel;

namespace MvcECommerceWebSite.Controllers
{
    public class AccountController : Controller
    {
        ProductsDbContext db = new ProductsDbContext();
        
        // GET: Account

        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(RegisterView rv)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = new IdentityUser { UserName = rv.UserName, Email = rv.Email, PhoneNumber = rv.PhoneNumber };
                var result = userManager.Create(user, rv.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn", "Account");
                    
                }
                else
                {
                    ModelState.AddModelError("", "Faild to Sign Up.Please try again!!!");
                    return View(rv);
                }
               
                
            }
            return View(rv);
        }
        

        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LogInView lv)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = userManager.Find(lv.UserName, lv.Password);

                if (user != null)
                {
                    var authManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
                    authManager.SignIn(new AuthenticationProperties() { }, userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Log In Failed!!!");
                    return View(lv);
                }
            }
            return View(lv);
        }
        [Authorize]
        public ActionResult LotOut()
        {
            var authManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("LogIn", "Account");
        }

        

    

    }
}