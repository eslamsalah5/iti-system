using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace CRUDStudentsAndDepartments.Models
{
    public class Student
    {
        [Key]
        public int StdId { get; set; }


        [Required]
        [StringLength(50,MinimumLength =3)]
        public string Name { get; set; }
        [Required]
        [Range(12, 35)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        [Remote("CheckEmailExistance","Students")]


        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6),MaxLength(30)]

        public string? Password { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6), MaxLength(30)]
        [Compare("Password")]

        public string? ConfirmPassword { get; set; }


        [ForeignKey("Department")]
        public int deptId { get; set; }

        public  Department? Department { get; set; }

    }
}
