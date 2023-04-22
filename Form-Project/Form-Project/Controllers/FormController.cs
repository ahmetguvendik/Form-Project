using Form_Project.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Form_Project.Controllers
{
    public class FormController : Controller
    {
        private readonly IForm _form;
        public FormController(IForm form)
        {
            _form = form;
        }

        public async Task<IActionResult> Index()
        {
          var forms =  await _form.GetForm();
            return View(forms);
        }
    }
}
