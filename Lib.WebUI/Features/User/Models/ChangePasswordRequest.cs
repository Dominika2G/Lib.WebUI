using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.User.Models
{
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage = "*Proszę podać starę hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "*Proszę podać nowe hasło")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
