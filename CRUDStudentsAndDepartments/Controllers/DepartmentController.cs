using CRUDStudentsAndDepartments.Data;
using CRUDStudentsAndDepartments.Models;
using CRUDStudentsAndDepartments.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudentsAndDepartments.Controllers
{
    [Authorize(Roles = "Instructor")]

    public class DepartmentController : Controller
    {
         IDepartment departmentService;

      public  DepartmentController(IDepartment departmentService)
        {
            this.departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var models = departmentService.GetAllDepartments();
            return View(models);
        }

        

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentService.Add(department);
                departmentService.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(department);
            }
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var dept = departmentService.GetDepartmentById(id.Value);
            if (dept == null)
                return NotFound();
            return View(dept);
        }

        [Authorize(Roles = "Admin")]

        public IActionResult Update(int? id)
        {
            if (id == null)
                return BadRequest();
            var dept = departmentService.GetDepartmentById(id.Value);
            if (dept == null)
                return NotFound();
            return View(dept);
        }

        [HttpPost]

        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentService.Update(department);
                departmentService.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(department);
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var dept = departmentService.GetDepartmentByIdWithStudents(id.Value);
            if (dept == null)
                return NotFound();
            if(dept.Students.Count > 0)
            {
                return View("DeleteError", dept);
            }
            return View(dept);
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            departmentService.Delete(department.DeptId);
            departmentService.Save();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteError(Department department)
        {
            return View(department);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}
