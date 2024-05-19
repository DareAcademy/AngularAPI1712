using System.ComponentModel.DataAnnotations;

namespace Clinic1712Angular.Models
{
    public class SignInDTO
    {
        [Required(ErrorMessage ="Please fill username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please fill password")]
        public string Password { get; set; }
    }
}
