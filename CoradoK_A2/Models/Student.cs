using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoradoK_A2.Models
{
    public class Student
    {
        public int? StudentId { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public string TechnicalInterest { get; set; }
        
        public string SocialNetworkInterest { get; set; }
        
        public string AcceptRegret { get; set; }

    }
}
