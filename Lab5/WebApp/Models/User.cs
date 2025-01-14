using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class User
    {
        [Required, MaxLength(50), MinLength(3), RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Only letters and numbers allowed.")]
        public string Username { get; set; }

        [Required, MaxLength(500)]
        public string FullName { get; set; }

        [Required, MinLength(8), MaxLength(16), RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&]).+$", ErrorMessage = "Password must meet complexity requirements.")]
        public string Password { get; set; }

        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}