using System;
using Microsoft.AspNetCore.Identity;

namespace Moodle.Domain
{
    public class User : IdentityUser
    {
        public string UserType { get; set; }
        public DateTime? LastSeen { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhotoPass { get; set; }
    }
}