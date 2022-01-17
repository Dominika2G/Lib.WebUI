using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Auth.Models
{
    public class LoginFormViewModel
    {
        [Required(ErrorMessage ="Nie podano adresu Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Nie podano hasła")]
        public string Password { get; set; }
    }
}
