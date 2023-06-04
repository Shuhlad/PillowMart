using System.ComponentModel.DataAnnotations;

namespace Pillowmart.Models.ViewModels;

    public class RegisterViewModel 
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
}