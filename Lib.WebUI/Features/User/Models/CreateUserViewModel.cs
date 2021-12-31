using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.User.Models
{
    public class CreateUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Class { get; set; }
    }
}
