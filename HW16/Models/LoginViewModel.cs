using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace HW16.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Emai { get; set; }
        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}
