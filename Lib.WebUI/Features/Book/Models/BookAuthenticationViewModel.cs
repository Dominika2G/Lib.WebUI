using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Book.Models
{
    public class BookAuthenticationViewModel
    {
        public List<Book> BookDetails { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
