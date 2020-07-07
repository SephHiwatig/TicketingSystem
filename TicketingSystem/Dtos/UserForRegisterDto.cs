using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Username must be between 6 - 20 characters")]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 5, ErrorMessage = "Password must be between 5 - 8 characters")]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
