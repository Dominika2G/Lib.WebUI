using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Statistics.Models
{
    public class StatisticsQuantityViewModel
    {
        public int AvailableBook { get; set; }
        public int ReservedBook { get; set; }
        public int BorrowedBook { get; set; }
    }
}
