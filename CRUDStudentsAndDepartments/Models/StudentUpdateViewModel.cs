using System.ComponentModel.DataAnnotations;

namespace CRUDStudentsAndDepartments.Models
{
    public class StudentUpdateViewModel
    {
        public int StdId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(12, 35)]
        public int Age { get; set; }

        [Required]
        public int deptId { get; set; }
    }

}
