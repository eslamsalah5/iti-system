using CRUDStudentsAndDepartments.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudentsAndDepartments.Data
{
    public class MvcDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Course> Courses { get; set; }

        public MvcDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.\\SQLexpress;Database=MVCCRUDITI;Trusted_Connection=True;TrustServerCertificate=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}


    }
}
