using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Features.Book.Models
{
    public class AddAuthorViewModel
    {
        [Required(ErrorMessage = "Nie podano imienia artysty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nie podano nazwiska artysty")]
        public string LastName { get; set; }
    }
}
