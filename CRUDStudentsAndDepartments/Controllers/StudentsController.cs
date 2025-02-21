using CRUDStudentsAndDepartments.Data;
using CRUDStudentsAndDepartments.Models;
using CRUDStudentsAndDepartments.Repos;
using CRUDStudentsAndDepartments.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudentsAndDepartments.Controllers
{
    public class StudentsController : Controller
    {
        IStudent studentService;
        CheckStudentEmailService checkStudentEmailService;
        public StudentsController(IStudent studentService, CheckStudentEmailService checkStudentEmailService)
        {
            this.studentService = studentService;
            this.checkStudentEmailService = checkStudentEmailService;
        }
        public IActionResult Index()
        {
            var models = studentService.GetAllStudents();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.depts = studentService.GetAllDepartment();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student? student)
        {
           if (ModelState.IsValid)
            {
                studentService.Add(student);
                studentService.Save();
                return RedirectToAction("Index");
            }
            ViewBag.depts = studentService.GetAllDepartment();
            return View(student);
        }

      public IActionResult  CheckEmailExistance(string email)
        {
            var std = checkStudentEmailService.CheckStudentEmail(email);
            if (std != null)
                return Json(false);
            return Json(true);
        }

        public IActionResult Details(int? id) 
        {
          if(id == null)
             return BadRequest();
          var std = studentService.GetStudentById(id.Value);
            if (std == null)
                return NotFound();
            return View(std);
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
                return BadRequest();
            var std = studentService.GetStudentById(id.Value);
            if (std == null)
                return NotFound();
            var model = new StudentUpdateViewModel
            {
                StdId = std.StdId,
                Name = std.Name,
                Age = std.Age,
                deptId = std.deptId
            };
            ViewBag.depts = studentService.GetAllDepartment();
            return View(model);
        }

        [HttpPost]

        public IActionResult Update(StudentUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = studentService.GetStudentById(model.StdId);

                if (student == null)
                    return NotFound();

                student.Name = model.Name;
                student.Age = model.Age;
                student.deptId = model.deptId;

                studentService.Update(student);
                studentService.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.depts = studentService.GetAllDepartment();
                return View(model);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            Student std = studentService.GetStudentById(id.Value);
            if (std == null)
                return NotFound();
            return View(std);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            studentService.Delete(student);
            studentService.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        //public IActionResult test(int id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }
        //    else if (id == 1)
        //    {
        //        return File("~/TextFile.txt","text/plain","myInfo.txt");
        //    } else if(id == 2)
        //    {
        //        var std = dbContext.Students.SingleOrDefault(s => s.StdId == id);
        //        return Json(std);
        //    } else
        //    {
        //        return Redirect("http://www.google.com");
        //    } 
        //}

    }
}
