using System.ComponentModel.DataAnnotations;

namespace Pillowmart.Models.ViewModels;

public class LoginViewModel
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email address is required")]
    public string Email { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}