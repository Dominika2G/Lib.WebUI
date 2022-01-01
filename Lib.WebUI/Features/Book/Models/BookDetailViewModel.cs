using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Book.Models
{
    public class BookDetailViewModel
    {
        public PartialBookInformation BookDetails { get; set; }
        public List<CommentDetail> CommentList { get; set; }

    }
}
