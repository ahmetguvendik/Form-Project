using System.ComponentModel.DataAnnotations;

namespace Form_Project.Models.User
{
    public class SignInUserModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
