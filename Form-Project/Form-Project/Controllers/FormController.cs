using AutoMapper;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using Form_Project.Models.Form;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Form_Project.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        FormManager formManager = new FormManager(new EfFormDal());
        private readonly IMapper _mapper;
        public FormController(IMapper mapper)
        {

            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var forms = formManager.GetAll();
           
            return View(forms);
        }

        public IActionResult CreateForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateForm(CreateFormModel model)
        {
            var formMapper = _mapper.Map<Form>(model);
            formMapper.CreatedAt = DateTime.Now.ToString();
            formManager.Insert(formMapper);
            return RedirectToAction("Index", "Form");
        }


    }
}
