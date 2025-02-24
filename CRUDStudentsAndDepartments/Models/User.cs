using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CRUDStudentsAndDepartments.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Remote("CheckEmailExistance", "User")]

        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        public virtual List<Role> Roles { get; set; } = new List<Role>();


    }
}
