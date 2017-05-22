using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{

    interface Person
    {
        string Description { get; }
        int Performance { get; }
        int Value { get; }
        void printData();
    }

    class Mitarbeiter : Person
    {
        public string EmployeeName { get; }
        public int EmployeePerformance { get; }
        public int EmployeeID { get; }
        public string EmployeeIBAN { get; }
        public int EmployeeSalary { get; private set; }
        public static int Counter { get; private set; }


        public Mitarbeiter(string employeeName, int employeePerformance, string employeeIBAN, int employeeID, int employeeSalary)
        {
            if (employeeName.Length < 7 || employeeID < 999) throw new ArgumentException("Please enter a valid argument.\n");
            EmployeeSalary = employeeSalary;
            EmployeeIBAN = employeeIBAN;
            EmployeePerformance = employeePerformance;
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            Counter++;
        }
        [JsonConstructor]
        public Mitarbeiter(string employeeName, int employeePerformance)
        {
            EmployeePerformance = employeePerformance;
            EmployeeName = employeeName;
        }
        public Mitarbeiter(string employeeName)
        {
            EmployeeName = employeeName;
        }

        public static int UpdateSalary(int salary, string name)
        {
            salary = salary + 300;
            Console.WriteLine($"{name} hat seine Jahresziele (>= 94%) erreicht und bekommt deshalb einen monatlichen Zuschlag von 300EUR brutto.");
            Console.WriteLine($"Das neue Einkommen von {name} beträgt nun {salary}EUR.");
            //Counter = 0; //Reset global
            return salary;
        }

        #region Person implementation

        public string Description => EmployeeName;
        public int Performance => EmployeePerformance;

        public void printData()
        {
            Console.WriteLine($"\n[Loading Employee...]\nName: {EmployeeName}\nGehalt: {EmployeeSalary}EUR\nPerformance: {EmployeePerformance}%\nID: {EmployeeID}\nIBAN: {EmployeeIBAN}\n-------------------------");
            if (EmployeePerformance >= 94)
            {
                EmployeeSalary = UpdateSalary(EmployeeSalary, EmployeeName);
            }
            else Console.WriteLine($"{EmployeeName} wird dieses Jahr leider keine Zuschlag erhalten.\n");
        }
        public int Value => Counter;

        #endregion
    }
    class Manager : Mitarbeiter
    {
        public string Title { get; }
        public string Name { get; }
        public int MPerformance { get; }
        public Manager(string title, string name, int mperformance)
            :base(name,mperformance)
        {
            Title = title;
            Name = name;
            MPerformance = mperformance;
        }      
    }

    class Customer : Mitarbeiter
    {
        public string Name { get; }
        public Customer(string name)
            : base(name)
        {
            Name = name;
        }
    }

    class Abteilung : Person
    {
        public string DepartmentName { get; }
        public int DepartmentPerformance { get; }
        public int CountMembers { get; private set; }

        public Abteilung(string departmentName, int departmentPerformance, int countMembers)
        {
            if (departmentName.Length < 2) throw new ArgumentException("Please enter a valid description.\n");
            DepartmentName = departmentName;
            DepartmentPerformance = departmentPerformance;
            CountMembers = countMembers;
            Console.WriteLine($"Anzahl der Mitarbeiter in der Abteilung '{ DepartmentName}': {CountMembers}");
        }

        #region Person implementation

        public string Description => DepartmentName;
        public int Performance => DepartmentPerformance;
        public int Value => 0;

        public void printData()
        {
            Console.WriteLine($"Abteilung: {DepartmentName}\nZu erreichende Jahresziele in Prozent: {DepartmentPerformance}%");
        }

        #endregion

        public static void Main(string[] args)
        {
            int anzMembers = 0;
            var members = new Person[]
            {
                new Abteilung("IT", 84, anzMembers),
                new Mitarbeiter ("Martin Lawrence", 94, "AT50 1200 2470 2481", 2448, 1900),
                new Mitarbeiter ("John Smith", 62, "AT50 1200 3007 4028", 1028, 2700),
            };
            foreach (var i in members)
            {
                anzMembers = i.Value;
                i.printData();
            }
            Abteilung abt = new Abteilung("IT", 92, anzMembers);
            Console.WriteLine($"Die Anzahl der Mitarbeiter in der Abteilung '{abt.Description}' wurde erhöht!\n");

            var MitarbeiterObjects = new []
            {
                new Manager("Director of IT","Roberto Sanches", 92),
                new Mitarbeiter ("Martin Lawrence", 94, "AT50 1200 2470 2481", 2448, 1900),
                new Customer ("Patrick Star"),
            };

            string ausgabe = JsonConvert.SerializeObject(MitarbeiterObjects, Formatting.Indented);
            Console.WriteLine(ausgabe);

            string datei = @"C:\Users\alekpav1\Desktop\oom\tasks\Task4\Task4\CreatedObjects.json";

            File.Exists(datei);
            File.WriteAllText(datei, ausgabe, Encoding.UTF8);

            /* read file */
            string jsonstring = File.ReadAllText(datei);
            var CreatedObject = JsonConvert.DeserializeObject<Mitarbeiter[]>(jsonstring);   
        }
    }
}
