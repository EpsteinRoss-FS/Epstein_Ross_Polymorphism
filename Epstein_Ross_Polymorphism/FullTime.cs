/** 
 * Ross Epstein
 * January 15th, 2021
 * Week 2 - Polymorphism
 * **/
using System;
using System.Collections.Generic;
using System.Text;

namespace Epstein_Ross_Polymorphism
{
    class FullTime : Hourly
    {
        public decimal _payPerHour { get; }
        public decimal _hoursPerWeek { get; }
        public FullTime(string name, string address, decimal payPerHour, decimal hoursPerWeek = 40) : base (name, address, payPerHour, hoursPerWeek)
        {
            _payPerHour = payPerHour;
            _hoursPerWeek = hoursPerWeek;

        }

        public override double CalculatePay(decimal _payPerHour, decimal _hoursPerWeek)
        {
            return base.CalculatePay(_payPerHour, _hoursPerWeek);
        }

    }
}
