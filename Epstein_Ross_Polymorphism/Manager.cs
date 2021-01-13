using System;
using System.Collections.Generic;
using System.Text;

namespace Epstein_Ross_Polymorphism
{
    class Manager : Salaried
    {
        private decimal bonus { get; }

        //the yearly pay will be salary PLUS bonus

        public Manager(string name, string address, decimal salary) : base(name, address, salary)
        { 
        
        }
    }
}
