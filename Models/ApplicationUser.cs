using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace roksh.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Package> Packages { get; set; }
    }
}
