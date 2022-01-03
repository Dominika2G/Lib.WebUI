using Lib.WebUI.Features.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Book.Models
{
    public class MakeReservationViewModel
    {
        public List<UserDetail> UsersCollection { get; set; }
        public long BookId { get; set; }
        public long UserId { get; set; }
    }
}
