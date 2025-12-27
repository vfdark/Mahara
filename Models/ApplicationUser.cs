using Microsoft.AspNetCore.Identity;

namespace Mahara.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Track { get; set; } // مسار الطالب
        public string City { get; set; }
    }
}
