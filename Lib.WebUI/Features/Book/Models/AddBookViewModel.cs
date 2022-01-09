using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Book.Models
{
    public class AddBookViewModel
    {
        [Required(ErrorMessage ="*Tytuł książki jest wymagany")]
        public string Title { get; set; }

        [Required(ErrorMessage = "*Opis ksiażki jest wymagany")]
        public string Description { get; set; }
        public string Cover { get; set; }

        [Required(ErrorMessage = "*Autor książki jest wymagany")]
        public long AuthorId { get; set; }

        [Required(ErrorMessage = "*Kod książki jest wymagany")]
        public string BarCode { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsReserved { get; set; }
        public List<Author> Authors { get; set; }
        public byte[] Image { get; set; }
    }
}
