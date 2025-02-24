using System.ComponentModel.DataAnnotations;

namespace CRUDStudentsAndDepartments.Models
{
    public class LoginModelView
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]


        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]

        public string Password { get; set; }
    }
}
