using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; } 

        public string PassportNumber { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public int? TelNumber { get; set; }
        public string? EmailAddress { get; set; }

        public  IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "BirthDate:" + BirthDate
                + "PassportNumber:" + PassportNumber
                + "EmailAdress:" + EmailAddress
                + "FirstName:" + FirstName
                + "LastName:" + LastName
                + "TelNumber:" + TelNumber;
        }

    }
}
