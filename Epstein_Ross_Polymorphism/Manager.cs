using System;
using System.Collections.Generic;
using System.Text;

namespace Epstein_Ross_Polymorphism
{
    class Manager : Salaried
    {
        public decimal _bonus { get; }
        public string _name { get; set; }


        //the yearly pay will be salary PLUS bonus

        public Manager(string name, string address, decimal salary, decimal bonus) : base(name, address, salary)
        {
            
            _name = Employee._name;
            _bonus = bonus;
        
        }

        public override double CalculatePay()
        {
            return base.CalculatePay();
        }
    }
}
