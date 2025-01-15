using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task3.Models
{
    public class User
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
       
        public string Name { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Enter Email address")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
    }
}
