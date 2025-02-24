using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDStudentsAndDepartments.Models
{
    public class Course
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [StringLength(30,MinimumLength =2)]


        public string Name { get; set; }

        [Required]

        public int duration { get; set; }

        [ForeignKey("Department")]

        public int DeptId { get; set; }

        public Department? Department { get; set; }

    }
}
