using Microsoft.AspNetCore.Identity;

namespace Clinic1712Angular.data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }

        public DateTime DOB { get; set; }
    }
}
