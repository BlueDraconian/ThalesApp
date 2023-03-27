using Microsoft.AspNetCore.Mvc;
using ThalesApp.DataAccess.Employee;

namespace ThalesApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeDataAccess _employeeDataAccess;

        public EmployeeController(IEmployeeDataAccess employeeDataAccess)
        {
            _employeeDataAccess = employeeDataAccess;
        }

        public ActionResult Index() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            return View(await _employeeDataAccess.Get(id));
        }


    }
}
