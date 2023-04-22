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
        {
            await _user.CreateUserAsync(createUser);
            return View();
        }

        public IActionResult SignIn()
        {
            return View(new SignInUserModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUserModel model)
        {
            if (ModelState.IsValid)
            {
               var users = await _user.SignInUserAsync(model);
                if(users != null)
                {
                    return RedirectToAction("Index", "Form");
                }
                
            }
       

            return View(model);
        }

    }
}
