using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{

    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            TempData["username"] = username;
            return View();
        }
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult Index2()
        {
            return View();
        }
    }

    //[Authorize(Roles = "Admin")]
    //public class AdminController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //    public IActionResult Index2()
    //    {
    //        return View();
    //    }
    //}
}
