using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Book.Models
{
    public class Bookstatusrequest
    {
        public long UserId { get; set; }
        public long BookId { get; set; }
    }
}
