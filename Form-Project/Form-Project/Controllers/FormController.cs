using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Form_Project.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        FormManager formManager = new FormManager(new EfFormDal());

        public async Task<IActionResult> Index()
        {
         var forms = formManager.GetAll();
            return View(forms);
        }
    
        public IActionResult CreateForm()
        {
            return View();
        }

    }
}
