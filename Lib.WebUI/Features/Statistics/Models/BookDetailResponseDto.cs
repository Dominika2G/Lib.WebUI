using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Statistics.Models
{
    public class BookDetailResponseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsReserved { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
