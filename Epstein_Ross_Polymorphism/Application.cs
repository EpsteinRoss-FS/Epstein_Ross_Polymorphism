/** 
 * Ross Epstein
 * January 15th, 2021
 * Week 2 - Polymorphism
 * **/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Epstein_Ross_Polymorphism
{
    class Application
    {
        public static string ExecutablePath { get; }
        private static readonly string filePath = "../../../bin/output/employees.txt";
        private static string[] employeeArray;
        private static object[] employeeSorted;
        private static List<Employee> employeeList = new List<Employee>();
        private static List<string> menu = new List<string> { "Add Employee", "Remove Employee", "Display Payroll", "Exit" };
        public static bool hasExited = false;
        public static decimal hoursWorkedDec;
        public static decimal payPerHourDec;
        public static decimal salaryDecimal;
        public static decimal yearlyBonusDecimal;
        public static string payPerHour;
        public static string hoursWorked;
        public static bool isHourlyPayValid;

        //private static ArrayList employeeList = new 


        public Application()
        {
            ApplicationLoop();
        }

        public static void ApplicationLoop()
        {
            GetEmployee();
            DisplayMenu();
        }

        public static void GetEmployee()
        {
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "employees.txt");

            string curFile = filePath;
            //Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
            //List<Employee> employeeList = new List<Employee>();


            using StreamReader streamread = new StreamReader(filePath);
            var allEmployees = streamread.ReadToEnd();

            //split each item on new line
            string[] lines = allEmployees.Split("\n");

            foreach (var employee in lines)
            {
                if (!String.IsNullOrWhiteSpace(employee))
                {


                    string[] createEmployee = employee.Split("|");


                    string employeeName = createEmployee[0];

                    string employeeAddress = createEmployee[1];

                    string payPerHour = createEmployee[2];
                    decimal payPerHourDec = Convert.ToDecimal(payPerHour);

                    string hoursPerWeek = createEmployee[3];
                    decimal hoursPerWeekDec = Convert.ToDecimal(hoursPerWeek);

                    string employeeSalary = createEmployee[4];
                    decimal employeeSalaryDec = Convert.ToDecimal(employeeSalary);

                    string employeeBonus = createEmployee[5];
                    decimal employeeBonusDec = Convert.ToDecimal(employeeBonus);

                    //var employeeToAdd = new object[] { employeeName, employeeAddress, payPerHourDec, hoursPerWeekDec, employeeSalaryDec, employeeBonusDec };

                    if (employeeSalaryDec == 00 && hoursPerWeekDec < 39)
                    {
                        PartTime partTime = new PartTime(employeeName, employeeAddress, payPerHourDec, hoursPerWeekDec);
                        employeeList.Add(partTime);
                    }

                    if (employeeSalaryDec == 00 && hoursPerWeekDec >= 40)
                    {
                        FullTime fullTime = new FullTime(employeeName, employeeAddress, payPerHourDec, hoursPerWeekDec);
                        employeeList.Add(fullTime);
                    }

                    if (employeeSalaryDec != 00 && payPerHourDec == 00)
                    {
                        Manager manager = new Manager(employeeName, employeeAddress, employeeSalaryDec, employeeBonusDec);
                        employeeList.Add(manager);

                    }

                }

            }




            //return employeeList;
        }
        public static void DisplayMenu()
        {
            while (!hasExited)
            {
                int menuLength = menu.Count - 1;
                int i = 1;
                DisplayHeader("EMPLOYEE TRACKER");
                foreach (var item in menu)
                {
                    Console.WriteLine($"[{i}]:  {item}");
                    i++;
                }

                Console.Write("Please make a selection >  ");
                string _userChoice = Console.ReadLine();

                //validate the choice is an integer
                bool isInt = Validation.CheckInt(_userChoice);
                int _userChoiceInt = isInt ? Int32.Parse(_userChoice) : 000;

                //validate the choice is in range of the menu
                bool isInRange = Validation.CheckRange(_userChoiceInt, menuLength + 1);

                //ask again if the validation returns false
                while (!isInt || !isInRange)
                {
                    i = 1;
                    DisplayHeader("EMPLOYEE TRACKER");

                    foreach (var item in menu)
                    {
                        Console.WriteLine($"[{i}]:  {item}");
                        i++;
                    }

                    //error if menu selection out of range    
                    Console.Write($"Invalid entry!  Please enter a number between 1 and {menuLength} > ");
                    _userChoice = Console.ReadLine();
                    isInt = Validation.CheckInt(_userChoice);
                    _userChoiceInt = isInt ? Int32.Parse(_userChoice) : 000; ;
                    isInRange = Validation.CheckRange(_userChoiceInt, (menuLength + 1));
                }

                //get the text value from the menu index based on user choice
                string chosenItem = menu[_userChoiceInt - 1];

                switch (chosenItem.ToLower())
                {

                    //added checks to make sure new course isn't null

                    //"Add Employee", "Remove Employee", "Display Payroll", "Exit"
                    case "add employee":
                        AddEmployee();
                        break;
                    case "remove employee":
                        RemoveEmployee();
                        break;
                    case "display payroll":
                        DisplayPayroll();
                        break;
                    case "exit":
                        Console.WriteLine("Thank you for using the employee payroll tracker!");
                        hasExited = true;
                        break;


                }
            }
        }
        public static void DisplayPayroll()
        {
            DisplayHeader("Display Payroll");

            foreach (var employee in employeeList)
            {
                if (employee is Manager)
                {
                    decimal managerSalary = ((Manager)employee).Salary;
                    decimal managerBonus = ((Manager)employee)._bonus;
                    double totalSalary = ((Manager)employee).CalculatePay(managerSalary, managerBonus);

                    Console.WriteLine($"Name: {((Manager)employee).Name}");
                    Console.WriteLine($"Address: {((Manager)employee).Address}");
                    Console.WriteLine($"Salary: {managerSalary.ToString("C")}");
                    Console.WriteLine($"Bonus: {managerBonus.ToString("C")}");
                    Console.WriteLine($"Salary w/ Bonus: {totalSalary.ToString("C")}");
                    Console.WriteLine("\n");
                }

                if (employee is FullTime)
                {
                    decimal hourlyPay = ((FullTime)employee)._payPerHour;
                    decimal hoursPerWeek = ((FullTime)employee)._hoursPerWeek;
                    double totalPerWeek = ((FullTime)employee).CalculatePay(hourlyPay, hoursPerWeek);

                    Console.WriteLine($"Name: {((FullTime)employee).Name}");
                    Console.WriteLine($"Address: {((FullTime)employee).Address}");
                    Console.WriteLine($"Hourly Rate: {hourlyPay.ToString("C")}");
                    Console.WriteLine($"Hours: {hoursPerWeek}");
                    Console.WriteLine($"Total Pay: {totalPerWeek.ToString("C")}");
                    Console.WriteLine("\n");
                }

                if (employee is PartTime)
                {
                    Console.WriteLine("TEST");
                    decimal hourlyPay = ((PartTime)employee)._payPerHour;
                    decimal hoursPerWeek = ((PartTime)employee)._hoursPerWeek;
                    double totalPerWeek = ((PartTime)employee).CalculatePay(hourlyPay, hoursPerWeek);

                    Console.WriteLine($"Name: {((PartTime)employee).Name}");
                    Console.WriteLine($"Address: {((PartTime)employee).Address}");
                    Console.WriteLine($"Hourly Rate: {hourlyPay.ToString("C")}");
                    Console.WriteLine($"Hours: {hoursPerWeek}");
                    Console.WriteLine($"Total Pay: {totalPerWeek.ToString("C")}");
                    Console.WriteLine("\n");
                }




            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }



        public static void AddEmployee()
        {
            DisplayHeader("add employee");
            Console.Write("\nWhat is the name of the employee? > ");
            string employeeName = Console.ReadLine();

            bool empNameValid = Validation.ValidateString(employeeName);
            while (!empNameValid)
            {
                DisplayHeader("add employee");
                Console.WriteLine("\nInvalid entry!");
                Console.Write("What is the name of the employee? > ");
                employeeName = Console.ReadLine();
                empNameValid = Validation.ValidateString(employeeName);
            }

            DisplayHeader("add employee");
            Console.Write("\nWhat is the address of the employee? > ");
            string employeeAddress = Console.ReadLine();

            bool empAddrValid = Validation.ValidateString(employeeAddress);
            while (!empAddrValid)
            {
                DisplayHeader("add employee");
                Console.WriteLine("\nInvalid entry!");
                Console.Write("What is the address of the employee? > ");
                employeeAddress = Console.ReadLine();
                empAddrValid = Validation.ValidateString(employeeAddress);
            }

            DisplayHeader("add employee");
            Console.Write("\nIs the employee hourly? Yes/No > ");
            string isHourly = Console.ReadLine();
            bool isHourlyValid = Validation.ValidateString(isHourly);
            while (!isHourlyValid || (isHourly.ToLower() != "yes" && isHourly.ToLower() != "no"))
            {
                DisplayHeader("add employee");
                Console.WriteLine("\nInvalid entry!");
                Console.Write("Is the employee hourly? > ");
                isHourly = Console.ReadLine();
                isHourlyValid = Validation.ValidateString(isHourly);
            }




            if (isHourly.ToLower() == "yes")
            {
                DisplayHeader("add employee");
                Console.Write("\nHow much does the employee make per hour? > ");
                payPerHour = Console.ReadLine();
                isHourlyPayValid = Validation.CheckDecimal(payPerHour);
                while (!isHourlyPayValid)
                {
                    DisplayHeader("add employee");
                    Console.WriteLine("\nInvalid entry!");
                    Console.Write("\nHow much does the employee make per hour? > ");
                    payPerHour = Console.ReadLine();
                    isHourlyPayValid = Validation.CheckDecimal(payPerHour);
                }

                payPerHourDec = Convert.ToDecimal(payPerHour);


                DisplayHeader("add employee");
                Console.Write("\nHow many hours does the employee work per work? > ");
                hoursWorked = Console.ReadLine();
                bool hoursWorkedValid = Validation.CheckDecimal(hoursWorked);
                while (!hoursWorkedValid)
                {
                    DisplayHeader("add employee");
                    Console.WriteLine("\nInvalid entry!");
                    Console.Write("\nHow many hours does the employee work per work? > ");
                    hoursWorked = Console.ReadLine();
                    hoursWorkedValid = Validation.CheckDecimal(hoursWorked);
                }

                hoursWorkedDec = Convert.ToDecimal(payPerHour);

            }


            if (isHourly.ToLower() == "no")
            {
                hoursWorkedDec = 40;
                payPerHourDec = 00;

                DisplayHeader("add employee");
                Console.Write("\nWhat is the employees salary? > ");
                string salary = Console.ReadLine();
                bool salaryValid = Validation.CheckDecimal(salary);
                while (!salaryValid)
                {
                    DisplayHeader("add employee");
                    Console.WriteLine("\nInvalid entry!");
                    Console.Write("\nHow many hours does the employee work per work? > ");
                    salary = Console.ReadLine();
                    salaryValid = Validation.CheckDecimal(salary);
                }
                salaryDecimal = Convert.ToDecimal(salary);


                DisplayHeader("add employee");
                Console.Write("\nWhat is the employees yearly bonus? > ");
                string yearlyBonus = Console.ReadLine();
                bool bonusValid = Validation.CheckDecimal(yearlyBonus);
                while (!bonusValid)
                {
                    DisplayHeader("add employee");
                    Console.WriteLine("\nInvalid entry!");
                    Console.Write("\nWhat is the employees yearly bonus? > ");
                    yearlyBonus = Console.ReadLine();
                    bonusValid = Validation.CheckDecimal(yearlyBonus);
                }
                yearlyBonusDecimal = Convert.ToDecimal(yearlyBonus);

            }

            if (salaryDecimal == 00 && hoursWorkedDec < 39)
            {
                PartTime partTime = new PartTime(employeeName, employeeAddress, payPerHourDec, hoursWorkedDec);
                employeeList.Add(partTime);
            }

            if (salaryDecimal == 00 && hoursWorkedDec >= 40)
            {
                FullTime fullTime = new FullTime(employeeName, employeeAddress, payPerHourDec, hoursWorkedDec);
                employeeList.Add(fullTime);
            }

            if (salaryDecimal != 00 && payPerHourDec == 00)
            {
                Manager manager = new Manager(employeeName, employeeAddress, salaryDecimal, yearlyBonusDecimal);
                employeeList.Add(manager);

            }

            DisplayHeader("add employee");
            Console.WriteLine($"Employee entry for {employeeName} added!");
            Console.WriteLine($"Press any key to return to the menu....");
            Console.ReadKey();


        }

        public static void DisplayHeader(string headerName)
        {
            Console.Clear();
            Console.WriteLine(headerName.ToUpper());
            Console.WriteLine("===================================================");
        }

        public static void RemoveEmployee()
        {


            int i = 1;
            List<string> empListForRemove = new List<string>();
            DisplayHeader("REMOVE EMPLOYEE");
            foreach (var item in employeeList)
            {
                empListForRemove.Add(((Employee)item).Name);
                i++;
            }

            empListForRemove.Add("Exit");
            i = 1;
            foreach (var item in empListForRemove)
            {
                Console.WriteLine($"[{i}]:  {item}");
                i++;
            }



            int employeeMenuLength = empListForRemove.Count - 1;


            Console.Write("Which employee would you like to delete?  > ");

            string _userChoice = Console.ReadLine();

            //validate the choice is an integer
            bool isInt = Validation.CheckInt(_userChoice);
            int _userChoiceInt = isInt ? Int32.Parse(_userChoice) : 000;

            //validate the choice is in range of the menu
            bool isInRange = Validation.CheckRange(_userChoiceInt, employeeMenuLength + 1);

            //ask again if the validation returns false
            while (!isInt || !isInRange)
            {
                i = 1;
                DisplayHeader("REMOVE EMPLOYEE");
                i = 1;
                foreach (var item in empListForRemove)
                {
                    Console.WriteLine($"[{i}]:  {item}");
                    i++;
                }


                //error if menu selection out of range    
                Console.Write($"Invalid entry!  Please enter a number between 1 and {employeeMenuLength} > ");
                _userChoice = Console.ReadLine();
                isInt = Validation.CheckInt(_userChoice);
                _userChoiceInt = isInt ? Int32.Parse(_userChoice) : 000; ;
                isInRange = Validation.CheckRange(_userChoiceInt, (employeeMenuLength + 1));
            }


            string chosenItem = empListForRemove[_userChoiceInt - 1];



            if (chosenItem.ToLower() == "exit")
            {
                return;
            }
            else
            {
                List<Employee> newList = new List<Employee>();
                foreach(var item in employeeList) {
                    if (((Employee)item).Name.ToLower() != chosenItem.ToLower()) 
                    {
                        newList.Add(item);
                    }
                }
                employeeList = newList;

                
                DisplayHeader("REMOVE EMPLOYEE");
                Console.WriteLine($"Employee {chosenItem} successfully removed");
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();


                
            }
        }


    } 
}
    
    



