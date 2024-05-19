using System.ComponentModel.DataAnnotations;

namespace Clinic1712Angular.Models
{
    public class RoleDTO
    {
        [Required(ErrorMessage ="Please fill out the role name")]
        public string Name { get; set; }
    }
}
