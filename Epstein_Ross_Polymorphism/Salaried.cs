using System;
using System.Collections.Generic;
using System.Text;

namespace Epstein_Ross_Polymorphism
{
    class Salaried : Employee
    {
        private decimal salary { get; }

        public Salaried(string name, string address, decimal salary) : base(name, address)
        { 
        
        }

        public override double CalculatePay()
        {
            return base.CalculatePay();
        }


    }
}
