using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Book.Models
{
    public class Book
    {
        public long BookId { get; set; }    
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsReserved { get; set; }
        public string Cover { get; set; }
    }
}
