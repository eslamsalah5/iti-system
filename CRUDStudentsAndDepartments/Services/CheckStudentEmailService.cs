using CRUDStudentsAndDepartments.Data;
using CRUDStudentsAndDepartments.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudentsAndDepartments.Services
{
    public class CheckStudentEmailService
    {
        MvcDbContext dbContext;
        public CheckStudentEmailService(MvcDbContext dbContext) 
        {
           this.dbContext = dbContext;
        }

        public Student CheckStudentEmail(string email)
        {
          return dbContext.Students.FirstOrDefault(s => s.Email == email);
        }
    }
}
