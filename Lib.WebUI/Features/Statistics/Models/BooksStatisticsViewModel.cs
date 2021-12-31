using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Statistics.Models
{
    public class BooksStatisticsViewModel
    {
        public List<GetUsersBookResponseDto> BorrowBooks { get; set; }
        public List<BookDetailResponseDto> AllBooks { get; set; }
    }
}
