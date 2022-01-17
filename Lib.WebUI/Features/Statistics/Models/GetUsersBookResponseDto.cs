using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Statistics.Models
{
    public class GetUsersBookResponseDto
    {
        public long BookId { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Email { get; set; }
        public long UserId { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsReserved { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int RentalPeriod { get; set; }
        public string Description { get; set; }
    }
}
