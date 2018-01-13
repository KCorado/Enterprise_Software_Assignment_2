using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoradoK_A2.Models
{
    public class GuestResponse
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your student id")]
        [Range(100000000, 999999999, ErrorMessage = "ID must be 9 numbers long")]
        public int? StudentId { get; set; }

        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your interest of social network")]
        public string SocialNetworkInterest { get; set; }

        [Required(ErrorMessage = "Please select an interest")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select an interest")]
        public TechnicalInterest Interest { get; set; }
        
        public bool? WillAttend { get; set; }
    }
}