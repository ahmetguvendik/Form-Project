using AutoMapper;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Form_Project.Models.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Form_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public HomeController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Index(CreateUserModel createUser)
        {
            if (ModelState.IsValid)
            {
                var userMapper = _mapper.Map<AppUser>(createUser);
                var result = await _userManager.CreateAsync(userMapper, createUser.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUserModel model)
        {
           

            if (ModelState.IsValid)
            {
                var userMapper = _mapper.Map<AppUser>(model);           
                var result = await _signInManager.PasswordSignInAsync(userMapper.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                   
                        return RedirectToAction("Index", "Form");
                }
                else
                {
                    return View();
                }

            }

            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Home");
        }


    }
}
