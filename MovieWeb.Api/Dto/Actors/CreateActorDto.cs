using System;
using System.ComponentModel.DataAnnotations;

namespace MovieWeb.Api.Dto.Actors
{
    public class CreateActorDto
    {
        public string FirstName { get; set; }
        [MaxLength(10)]
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
    }
}
