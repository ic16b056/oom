using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    interface Person
    {
        string Name { get; }
        int Alter { get; }
        int MitarbeiterID { get; }
        string IBAN { get; }
        void printData ();
    }
    class Mitarbeiter : Person
    {
        public string EmployeeName { get; private set; }
        public int EmployeeAge { get; }
        public int EmployeeID { get; private set; }
        public string EmployeeIBAN { get; private set; }
        public int EmployeeSalary { get; private set; }
         

        public Mitarbeiter(string empl_name, int performance_progress, string empl_iban, int empl_id, int empl_gehalt, int dienstjahre)
        {
            if (empl_name.Length <= 4) throw new ArgumentException("Please enter a valid name.\n", nameof(empl_name));
            EmployeeSalary = empl_gehalt;
            EmployeeIBAN = empl_iban;
            EmployeeID = empl_id;
            EmployeeName = empl_name;
            
            if (dienstjahre >= 2 &&  performance_progress >= 90)
            {
                UpdateSalary(EmployeeSalary, EmployeeName);
            }
            else Console.WriteLine($"Herr/Frau {empl_name} wird dieses Jahr leider keine Gehaltserhöhung erhalten.\n");
        }
        public Mitarbeiter()
        {
            this.EmployeeName = EmployeeName;
            this.EmployeeAge = EmployeeAge;
        }

        #region Person implementation

        public string Name => EmployeeName;
        public int Alter => EmployeeAge;
        public int MitarbeiterID => EmployeeID;
        public string IBAN => EmployeeIBAN;    

        public void printData()
        {
            Console.WriteLine($"Name: {EmployeeName}\nGehalt: {EmployeeSalary}EUR\nID: {EmployeeID}\nIBAN: {EmployeeIBAN}\n--------------------\n");
        }

        #endregion

        public void UpdateSalary(int salary, string name)
        {
            salary = salary + 300;
            EmployeeSalary = salary;
            EmployeeName = name;
            Console.WriteLine($"Herr/Frau {name} hat eine Gehaltserhöhung erhalten.\n>> Neues Gehalt beträgt: {EmployeeSalary}EUR.\n");
        }
    }
    class Manager : Person
    {
        public string ManagerName { get; private set; }
        public int ManagerAge { get; }
        public int ManagerID { get; private set; }
        public string ManagerIBAN { get; private set; }
        public int ManagerSalary { get; private set; }

        public Manager(string mgr_name, int mgr_age, string mgr_iban, int mgr_id, int mgr_gehalt)
        {
            if (mgr_name.Length <= 4) throw new ArgumentException("Please enter a valid name.\n", nameof(mgr_name));
            ManagerIBAN = mgr_iban;
            ManagerSalary = mgr_gehalt;
            ManagerID = mgr_id;
            ManagerName = mgr_name;
            ManagerAge = mgr_age;
        }
        public Manager()
        {
            this.ManagerName = ManagerName;
            this.ManagerAge = ManagerAge;
        }

        #region Person implementation

        public string Name => ManagerName;
        public int Alter => ManagerAge;
        public int MitarbeiterID => ManagerID;
        public string IBAN => ManagerIBAN;

        public void printData()
        {
            Console.WriteLine($"Name: {ManagerName}\nAlter: {ManagerAge}\nID: {ManagerID}\nIBAN: {ManagerIBAN}\n--------------------\n\n");
        }

        #endregion

        public Boolean Prämienzuschlag(bool jahresziele)
        {
            bool reached = false;
                if (jahresziele == true)
                {

                }
            return reached;

        }

        public static void Main(string[] args)
        {
            var members = new Person[]
            {
                //new Manager(),
                //new Mitarbeiter (),
                new Manager("Max Mustermann", 21, "AT50120031254", 2008, 3800),
                new Manager("Bill Gates", 28, "AT50120024701", 2448, 5200),
                new Manager( "Daniel Johnson", 34,"AT502538925741", 1022, 4000),
                new Mitarbeiter ("Markus Schmidt", 91, "AT50120024701", 2448, 1900,4),
                new Mitarbeiter ("M", 92, "AT50120024701", 2448, 2700,2),
            };
            foreach (var i in members)
            {
                i.printData();
                
            }
        }
    }
}
