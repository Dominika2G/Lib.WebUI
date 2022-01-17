using Lib.WebUI.Features.User.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Book.Models
{
    public class MakeReservationViewModel
    {
        public List<UserDetail> UsersCollection { get; set; }
        public long BookId { get; set; }
        //[Required(ErrorMessage = "*Aby wypożyczyć książkę należy wybrać użytkownika")]
        [Range(1, long.MaxValue, ErrorMessage =  "*Aby wypożyczyć książkę należy wybrać użytkownika")]
        public long UserId { get; set; }
    }
}
