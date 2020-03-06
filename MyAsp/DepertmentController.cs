using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyAsp.Model;
using MyAsp.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAsp
{
    public class DepertmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        // GET: /<controller>/
        public async Task<IActionResult>  Index()
        {
            ViewBag.Title = "Department Index";
            var departments = _departmentService.GetAll();
            return View(departments);
        }
        public DepertmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public Microsoft.AspNetCore.Mvc.IActionResult Add()
        {
            ViewBag.Title = "Add Department";
            return  View(new Department());
        }

        [HttpPost]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Add(Department model)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Add(model);
            }
             return RedirectToAction(nameof(Index));
        }

    }
}
