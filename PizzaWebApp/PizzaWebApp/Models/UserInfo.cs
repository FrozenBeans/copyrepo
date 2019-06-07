using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApp.Models
{
    public class UserInfo
    {
        //data annotations - UI appearance of fields
        //use to validate input data
        //with EF code first, manage types of the entities  
        [DisplayName("#")]//displayname?
        public int Num { get; set; } = 1;
        [DisplayName("Full Name")]
        public string Name { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Phonenumber cannot be blank")]

        public int? Phonenumber { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Username cannot be blank")]
        [StringLength(32,ErrorMessage ="Min Length:6, Max Length:32", MinimumLength = 6)]
        public string Username { get    ; set; }
        public int userid { get; set; }

        [DisplayName("First name")]
        [Required(ErrorMessage = "Firstname cannot be blank")]
        public string firstname { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Lastname cannot be blank")]
        public string lastname { get; set; }


        [DisplayName("Password")]
        [Required(ErrorMessage ="Password cannot be blank")]
        [StringLength(32,ErrorMessage ="Min Length: 6, Max Length:32", MinimumLength = 6)]
        public string password { get; set; }

    }
}