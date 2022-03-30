using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; }
        [Required(ErrorMessage = "Please Enter their last name")]
        public string BowlerLastName { get; set; }
        [Required(ErrorMessage = "Please Enter their first name")]
        public string BowlerFirstName { get; set; }
        public string BowlerMiddleInit { get; set; }
        [Required(ErrorMessage = "Please Enter their city")]
        public string BowlerCity { get; set; }
        [Required(ErrorMessage = "Please Enter their address")]
        public string BowlerAddress { get; set; }
        [Required(ErrorMessage = "Please Enter their state")]
        public string BowlerState { get; set; }
        [Required(ErrorMessage = "Please Enter their zipcode")]
        public string BowlerZip { get; set; }
        [Required(ErrorMessage = "Please Enter their phonenumber")]
        public string BowlerPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please select their team")]
        public int? TeamID { get; set; }
        public Team Team { get; set; }

    }
}
