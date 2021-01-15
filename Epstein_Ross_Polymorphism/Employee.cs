using System;
using System.Collections.Generic;
using System.Text;

namespace Epstein_Ross_Polymorphism
{
    class Employee
    {
        protected string _name;
        protected string _address;
        public string Name 
        {
            get { return _name; }
//            set { _name = value; }
        }

        public string Address
        {
            get { return _address; }
        }

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
