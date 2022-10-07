using System;
using System.ComponentModel.DataAnnotations;

namespace MovieWeb.Client.Models.Actors
{
    public class ActorCreateViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Verplicht!")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Verplicht!")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
