﻿/** 
 * Ross Epstein
 * January 15th, 2021
 * Week 2 - Polymorphism
 * **/
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
            _bonus = bonus;
        }

        public override double CalculatePay(decimal salary, decimal bonus)
        {
            
            decimal calcPayDec = salary + bonus;
            double calculatedPay = decimal.ToDouble(calcPayDec);

            return calculatedPay;
        }
    }
}
