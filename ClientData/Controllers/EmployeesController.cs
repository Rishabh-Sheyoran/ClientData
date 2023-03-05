using ClientData.Data;
using ClientData.Models;
using ClientData.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientData.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MvCDemoDbContext mvCDemoDbContext;

        public EmployeesController(MvCDemoDbContext mvCDemoDbContext)
        {
            this.mvCDemoDbContext = mvCDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var emp = await mvCDemoDbContext.Employees.ToListAsync();
            return View(emp);   
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddEmpViewModel addEmpRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmpRequest.Name,
                Salary = addEmpRequest.Salary,
                Department = addEmpRequest.Department,
                DOB = addEmpRequest.DOB,
                Email = addEmpRequest.Email
            };

            await mvCDemoDbContext.Employees.AddAsync(employee);
            await mvCDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
