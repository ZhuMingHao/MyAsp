using Microsoft.AspNetCore.Mvc;
using MyAsp.Model;
using MyAsp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAsp
{
    public class EmployeeController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index(int depertmentId)
        {
            var department = await _departmentService.GetById(depertmentId);
            ViewBag.Title = $"Employee of{department.Name}";
            ViewBag.DepartmentId = depertmentId;
            var employee = await _employeeService.GetByDeparmentById(depertmentId);
            return View(employee);
        }

        public Microsoft.AspNetCore.Mvc.IActionResult Add(int departmentId)
        {
            ViewBag.Title = "Add Employee";
            return View(new Employee
            {
                DeparmentId = departmentId
            });
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Add(model);

            }
            return RedirectToAction(nameof(Index),new { dapertmentId= model.DeparmentId});
        }
        public async Task<IActionResult> Fire(int employeeId)
        {
            var employee = await _employeeService.Fire(employeeId);
            return RedirectToAction(nameof(Index), new { departmentId = employee.DeparmentId });
        }
    }
}
