using Microsoft.AspNetCore.Mvc;

namespace Form_Project.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
