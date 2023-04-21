using Form_Project.Interfaces;
using Form_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Form_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUser _user;
        public HomeController(IUser user)
        {
            _user = user;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateUserModel createUser) 
        {   await _user.CreateUserAsync(createUser);
            return View(); 
        }
    }
}
