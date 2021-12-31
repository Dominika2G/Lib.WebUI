using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.User.Models
{
    public class UserDetail
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
        public int IsActive { get; set; }
        public string RoleName { get; set; }
    }
}
