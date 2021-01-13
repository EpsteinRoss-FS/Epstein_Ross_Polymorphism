using System;
using System.Collections.Generic;
using System.Text;

namespace Epstein_Ross_Polymorphism
{
    class Hourly : Employee
    {
        protected decimal payPerHour { get; }
        protected decimal hoursPerWeek { get; }

        public Hourly(string name, string address, decimal payPerHour, decimal hoursPerWeek) : base(name, address) 
        { 
        
        }
    }
}
