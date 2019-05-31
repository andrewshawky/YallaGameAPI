using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YallaGameAPISecure.Dtos
{
    /// <summary>
    /// attributes we recives in register message only
    /// </summary>
    public class UserForRegisterDtos
    {
         [Required]
        public string username { get; set; }
        [Required]
        [StringLength(8,MinimumLength =4,ErrorMessage ="password length between 4 and 8")]
        public string password { get; set; }
    }
}
