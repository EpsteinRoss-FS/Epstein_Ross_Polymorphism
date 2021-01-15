using System;
using System.Collections.Generic;
using System.Text;

namespace Epstein_Ross_Polymorphism
{
    class PartTime : Hourly
    {

        
        public decimal _payPerHour { get;  }
        public decimal _hoursPerWeek { get;  }


        public PartTime(string name, string address, decimal payPerHour, decimal hoursPerWeek) : base(name,address,payPerHour,hoursPerWeek) 
        {
            _payPerHour = payPerHour;
            _hoursPerWeek = hoursPerWeek;
        }

    }
}
