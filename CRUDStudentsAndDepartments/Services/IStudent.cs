using CRUDStudentsAndDepartments.Models;

namespace CRUDStudentsAndDepartments.Services
{
    public interface IStudent
    {
        IEnumerable<Student> GetAllStudents();

        IEnumerable<Department> GetAllDepartment();
        Student GetStudentById(int id);
        void Add(Student student);

        void Update(Student student);

        void Delete(Student student);

        Student GetStudentByEmail(string email);

        void Save();
    }
}
