using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YallaGameAPISecure.Dtos
{
    public class PlaceForRegisterDtos
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "password length between 6 and 30")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Image { get; set; }


        public string Country { get; set; }

        public string City { get; set; }
        public string Description { get; set; }
        public string Days { get; set; }
        public string OpenHour { get; set; }
        public string CloseHour { get; set; }



        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone must be 11 digit")]
        public string Phone { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
