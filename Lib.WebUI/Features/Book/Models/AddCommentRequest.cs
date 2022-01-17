using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Book.Models
{
    public class AddCommentRequest
    {
        public string Description { get; set; }
        public int Rating { get; set; }
        public long BookId { get; set; }
    }
}
