using CRUDStudentsAndDepartments.Data;
using CRUDStudentsAndDepartments.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudentsAndDepartments.Services
{
    public class StudentService : IStudent
    {
        MvcDbContext dbContext;

        public StudentService(MvcDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Student student)
        {
            dbContext.Students.Add(student);

        }

        public void Delete(Student student)
        {
            dbContext.Students.Remove(student);
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            return dbContext.Departments.Where(d => d.status == true).ToList();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return dbContext.Students.Include(s => s.Department).ToList();
        }

        public Student GetStudentByEmail(string email)
        {
             return dbContext.Students.FirstOrDefault(s => s.Email == email);
        }

        public Student GetStudentById(int id)
        {
          return  dbContext.Students.Include(s => s.Department).FirstOrDefault(s => s.StdId == id);
        }

        public void Save()
        {
            dbContext.SaveChanges();

        }

        public void Update(Student student)
        {
            dbContext.Students.Update(student);
        }
    }
}
