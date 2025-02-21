using CRUDStudentsAndDepartments.Models;

namespace CRUDStudentsAndDepartments.Repos
{
    public interface IDepartment
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentById(int id);

        Department GetDepartmentByIdWithStudents(int id);
        void Add(Department department);

        void Update(Department department);

        void Delete(int id);

        void Save();


    }
}
