using Microsoft.AspNetCore.Mvc;
using CRUDStudentsAndDepartments.filters;

namespace CRUDStudentsAndDepartments.Controllers
{
    public class testController : Controller
    {
        [CustomActionFilter]
        public IActionResult Display()
        {
            int x = int.Parse("abc");
            return View();
        }
    }
}
