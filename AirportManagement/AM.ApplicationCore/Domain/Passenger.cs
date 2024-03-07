using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; } 

        [Key]
        [StringLength(7, ErrorMessage = "Passport number must be 7 charters long.")]
        public string PassportNumber { get; set; }


        //[StringLength(25, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 25 characters long.")]
        //public string FirstName { get; set; }

        //public string LastName { get; set; }


        public FullName PassengerName { get; set; }


        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Phone number must be 8 digits.")]
        public int? TelNumber { get; set; }


        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? EmailAddress { get; set; }

        public  IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "BirthDate:" + BirthDate
                + "PassportNumber:" + PassportNumber
                + "EmailAdress:" + EmailAddress
                + "FirstName:" + PassengerName.FirstName
                + "LastName:" + PassengerName.LastName
                + "TelNumber:" + TelNumber;
        }

    }
}
