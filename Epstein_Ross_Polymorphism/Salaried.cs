using System;
using System.Collections.Generic;
using System.Text;

namespace Epstein_Ross_Polymorphism
{
    class Salaried : Employee
    {
        protected decimal _salary { get; }
        public decimal Salary 
        {
            get { return _salary; }
        }

        public Salaried(string name, string address, decimal salary) : base(name, address)
        {
            _salary = salary;
        
        }
    }
}
