using Microsoft.AspNetCore.Mvc;

namespace M295_Project_V1._0.Controllers
{
    public class UserController : Controller
    {
        [HttpGet] 
        public IActionResult Register()
        {
            return View();
        }
    }
}
