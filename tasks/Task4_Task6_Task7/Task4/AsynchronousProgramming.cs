using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace Task4
{
    class AsynchronousProgramming
    {
        public static void Run(Mitarbeiter[] person)
        {
            foreach (var x in person)
            {
                
                var task1 = Task.Run(() =>
                {
                    Console.WriteLine($"Employee's salary received: {x.EmployeeSalary}");
                    Console.WriteLine($"employee's name: {x.EmployeeName}");
                    x.EmployeeSalary = x.EmployeeSalary+100;
                    //Console.WriteLine($"Employee's salary increased to (+100 EUR): {x.EmployeeSalary}");
                });
                task1.ContinueWith(y => Console.WriteLine($"Employee's salary increased to (+100 EUR): {x.EmployeeSalary}\n"));
            }
            Console.ReadLine();
            Console.WriteLine("Doing something else .. \n");
            var task2 = Task.Run(() =>
            {
                int i = 10;
                Console.WriteLine($"Received value: [{i}]\n");
                while (i >= 0)
                {
                    i--;
                    Task.Delay(1000).Wait();
                    //Console.WriteLine($"Returned value: [{i}]\n");          
                }
                return i;

            });
            task2.ContinueWith(r => Console.WriteLine($"The final value is {r.Result}"));

            Task<int> futureLength = GetEmployeesNameLengthAsync(person);
            Console.ReadLine();

        }   
        public static async Task<int> GetEmployeesNameLengthAsync(Mitarbeiter[]person)
        {
            int value=0;
            foreach(var x in person)
            {
                value = x.EmployeeName.Length;
                await Task.Delay(2000);
                Console.WriteLine($"Total length of the employee's name is: {value}");
            }
            return value;
        }   
    }
}


