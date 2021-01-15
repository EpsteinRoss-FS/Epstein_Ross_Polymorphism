using System;
using System.Collections.Generic;
using System.Text;

namespace Epstein_Ross_Polymorphism
{
    class FullTime : Hourly
    {
        public FullTime(string name, string address, decimal payPerHour, decimal hoursPerWeek = 40) : base (name, address, payPerHour, hoursPerWeek)
        { 
        
        }

        public override double CalculatePay()
        {
            return base.CalculatePay();
        }

    }
}
