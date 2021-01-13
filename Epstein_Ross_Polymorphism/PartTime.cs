using System;
using System.Collections.Generic;
using System.Text;

namespace Epstein_Ross_Polymorphism
{
    class PartTime : Hourly
    {

        public PartTime(string name, string address, decimal payPerHour, decimal hoursPerWeek) : base(name,address,payPerHour,hoursPerWeek) 
        { 
        
        }
    }
}
