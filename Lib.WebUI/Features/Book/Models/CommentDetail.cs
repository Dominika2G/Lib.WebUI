using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Book.Models
{
    public class CommentDetail
    {
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime AddingDate { get; set; }
        public int Rating { get; set; }
    }
}
