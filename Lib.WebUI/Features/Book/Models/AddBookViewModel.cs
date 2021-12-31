using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Book.Models
{
    public class AddBookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public long AuthorId { get; set; }
        public string BarCode { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsReserved { get; set; }
        public List<Author> Authors { get; set; }
    }
}
