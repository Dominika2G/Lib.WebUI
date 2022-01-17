using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Book.Models
{
    public class AddAuthorViewModel
    {
        [Required(ErrorMessage = "*Należy podać imię autora")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*Należy podać naziwsko autora")]
        public string LastName { get; set; }
    }
}
