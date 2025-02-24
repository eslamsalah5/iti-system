using CRUDStudentsAndDepartments.Data;
using CRUDStudentsAndDepartments.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudentsAndDepartments.Services
{
    public class CheckEmailService
    {
        MvcDbContext dbContext;
        public CheckEmailService(MvcDbContext dbContext) 
        {
           this.dbContext = dbContext;
        }

        public Student CheckStudentEmail(string email)
        {
          return dbContext.Students.FirstOrDefault(s => s.Email == email);
        }

        public User CheckUserEmail(string email)
        {
            return dbContext.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
