using CRUDStudentsAndDepartments.Data;
using CRUDStudentsAndDepartments.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudentsAndDepartments.Repos
{
    public class DepartmentService : IDepartment
    {
        MvcDbContext dbContext;

        public DepartmentService(MvcDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Department department)
        {
            department.status = true;
            dbContext.Departments.Add(department);


        }

        public void Delete(int id)
        {
            var department = dbContext.Departments.FirstOrDefault(d => d.DeptId == id);
            department.status = false;

        }

        public IEnumerable<Department> GetAllDepartments()
        {
          return dbContext.Departments.Where(s => s.status == true).ToList();

        }

        public Department GetDepartmentById(int id)
        {
            return dbContext.Departments.FirstOrDefault(d => d.DeptId == id);
        }

        public Department GetDepartmentByIdWithStudents(int id)
        {
            return dbContext.Departments.Include(d => d.Students).FirstOrDefault(d => d.DeptId == id);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Update(Department department)
        {
            department.status = true;
            dbContext.Departments.Update(department);

        }
    }
}
