using NKSLK.Models.DAO;
using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NKSLK.Controllers
{
    public class LoginController : Controller
    {
        public object MessageBox { get; private set; }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String Email, string Password)
        {
            LoginDAO lo = new LoginDAO();
           
            if (lo.Login(Email, Password))
            {
                Session["username"] = Email;
                FormsAuthentication.SetAuthCookie(Email, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Email or Password is incorrect!");
            return View();
        }
        public ActionResult Register()
        {
            LoginDAO dao = new LoginDAO();
            return View();
        }
        [HttpPost]
        public ActionResult Register(ACCOUNT_DTO ac)
        {
            //khai báo 2 cái oblect nayfnlamf gì ??
            // 
            ACCOUNT acco = new ACCOUNT();
            ACCOUNT_DTO acc = new ACCOUNT_DTO();
            if (acc !=null && acco !=null)
            {
                acc.Email = ac.Email;
                acco.Email = ac.Email;
                acc.Password = ac.Password;
                acco.Password = ac.Password;
                acc.ConfirmPassword = ac.ConfirmPassword;
                if (acc.Password== acc.ConfirmPassword)
                {
                    LoginDAO dao = new LoginDAO();
                    dao.Create(acco);
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "Email or Confirm Password is incorrect!");
            return View();
        }
        
    }

}
