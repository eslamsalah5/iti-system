using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDStudentsAndDepartments.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptId { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [Range(15,50)]
        public int Capacity { get; set; }

        public bool status { get; set; }

        public virtual List<Student> Students { get; set; } = new List<Student>();

        public virtual List<Course> Courses { get; set; } = new List<Course>();

    }
}
