using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.User.Models
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "*Imię jest wymagane")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*Nazwisko jest wymagane")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*Adres email jest wymagany")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "*Adres email jest niepoprawny")]
        public string Email { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "*Rola użytkownika jest wymagana")]
        public long RoleId { get; set; }

        [Required(ErrorMessage = "*Hasło jest wymagane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "*Potworedzenie hasła jest wymagane")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "*Podane hasła nie jest takie samo")]
        public string ConfirmPassword { get; set; }
        public string Class { get; set; }
    }
}
