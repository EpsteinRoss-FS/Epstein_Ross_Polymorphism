using System;
using System.Collections.Generic;
using System.Text;

namespace Epstein_Ross_Polymorphism
{
    class Employee
    {
        protected static string _name;
        protected static string _address;

        public Employee(string name, string address)
        {
            _name = name;
            _address = address;
        }

        public virtual double CalculatePay() 
        {
            return 00.0;
        } 

    }
}
